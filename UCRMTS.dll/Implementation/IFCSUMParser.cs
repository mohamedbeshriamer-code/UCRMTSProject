using indice.Edi;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using UCRMTS.dll.Interfaces;
using UCRMTS.dll.Models;

namespace UCRMTS.dll.Implementation
{
    public class IFCSUMParser : IEDIParser
    {
        IEdiGrammar grammar = EdiGrammar.NewEdiFact();
        EdiSerializer serializer = new EdiSerializer();
        public CuscarInterchange Deserilize(string interchange)
        {
            IFCSUMManifestInterchange elements = Parse(interchange);
            var adapter = new IFCSumAdapter(elements);
            return adapter.GetEDI();
        }


        public string Serilize<T>(T value)
        {
            if (!(value is IFCSUMManifestInterchange))
            {
                throw new Exception("The Edi is not Compatiable");
            }
            var interchange = value as IFCSUMManifestInterchange;
            var adapter = new IFCSumAdapter(interchange);
            var cuscare = adapter.GetEDI();
            using (var writer = new StringWriter())
            {
                serializer.Serialize(writer, grammar, cuscare);
                return writer.ToString();
            }

        }



        private IFCSUMManifestInterchange Parse(string rawManifest)
        {
            if (string.IsNullOrWhiteSpace(rawManifest))
                throw new ArgumentNullException(nameof(rawManifest));

            var interchange = new IFCSUMManifestInterchange();
            IFCSUMConsignment currentConsignment = null;

            var lines = rawManifest
                .Split(new[] { "'\r\n", "'\n", "'" }, StringSplitOptions.RemoveEmptyEntries)
                .Select(l => l.Trim())
                .Where(l => l.Length > 0);

            foreach (var line in lines)
            {
                var colonIdx = line.IndexOf(':');
                if (colonIdx < 0) continue;

                var tag = line.Substring(0, colonIdx).Trim();
                var payload = line.Substring(colonIdx + 1).Trim();
                var fields = SplitFields(payload);

                switch (tag)
                {
                    case "00":
                        ParseInterchangeHeader(interchange, fields);
                        break;

                    case "10":
                        interchange.Voyage = ParseVoyage(fields);
                        break;

                    case "11":
                        interchange.CarrierCode = fields.ElementAtOrDefault(0);
                        interchange.CarrierName = fields.ElementAtOrDefault(1);
                        break;

                    case "12":
                        if (currentConsignment != null)
                        {
                            currentConsignment.ProcessDescription();
                            interchange.Consignments.Add(currentConsignment);
                        }
                        currentConsignment = ParseBillOfLading(fields);
                        break;

                    case "13":
                        if (currentConsignment != null)
                            ParseDischarge(currentConsignment, fields);
                        break;

                    case "15":
                        currentConsignment?.Charges.Add(ParseCharge(fields));
                        break;

                    case "16":
                        if (currentConsignment != null)
                            currentConsignment.Shipper = ParseParty("16", fields);
                        break;

                    case "17":
                        if (currentConsignment != null)
                            currentConsignment.Consignee = ParseParty("17", fields);
                        break;

                    case "18":
                        if (currentConsignment != null)
                            currentConsignment.NotifyParty = ParseParty("18", fields);
                        break;

                    case "41":
                        if (currentConsignment != null)
                            currentConsignment.Goods = ParseGoodsSummary(fields);
                        break;

                    case "44":
                        if (currentConsignment != null)
                            currentConsignment.Marks = string.Join(" ", fields).Trim('"');
                        break;

                    case "47":
                        currentConsignment?.DescriptionLines
                            .Add(string.Join(" ", fields).Replace("\"", "").Trim());
                        break;

                    case "51":
                        currentConsignment?.Equipments.Add(ParseEquipment(fields));
                        break;

                    case "99":
                        if (currentConsignment != null)
                        {
                            currentConsignment.ProcessDescription();
                            interchange.Consignments.Add(currentConsignment);
                            currentConsignment = null;
                        }
                        if (int.TryParse(fields.ElementAtOrDefault(0), out int count))
                            interchange.ControlCount = count;
                        break;
                }
            }

            // Safety flush for files that end without tag 99
            if (currentConsignment != null)
            {
                currentConsignment.ProcessDescription();
                interchange.Consignments.Add(currentConsignment);
            }

            return interchange;
        }

   



    


        private void ParseInterchangeHeader(IFCSUMManifestInterchange ic, List<string> f)
        {
            ic.MessageType = f.ElementAtOrDefault(0);
            ic.DocumentType = f.ElementAtOrDefault(1);
            ic.SyntaxVersion = f.ElementAtOrDefault(2);
            ic.SenderId = f.ElementAtOrDefault(3);
            ic.ReceiverRole = f.ElementAtOrDefault(4);
            ic.InterchangeControl = f.ElementAtOrDefault(5);
        }

        private VoyageInformation ParseVoyage(List<string> f)
        {
            return new VoyageInformation
            {
                VesselCode = f.ElementAtOrDefault(0),
                VesselName = f.ElementAtOrDefault(1),
                VoyageNumber = f.ElementAtOrDefault(3),
                DepartureDate = ParseDate8(f.ElementAtOrDefault(6)),
                ArrivalDate = ParseDate8(f.ElementAtOrDefault(7)),
                PortOfCallCode = f.ElementAtOrDefault(8),
                PortOfCallName = f.ElementAtOrDefault(9),
                SequenceNumber = f.ElementAtOrDefault(12),
            };
        }

        private IFCSUMConsignment ParseBillOfLading(List<string> f)
        {
            return new IFCSUMConsignment
            {
                BillOfLadingNumber = f.ElementAtOrDefault(0),
                // fields 1–3 are blank in the format
                OriginPortCode = f.ElementAtOrDefault(4),
                OriginPortName = f.ElementAtOrDefault(5),
                PlaceOfReceiptCode = f.ElementAtOrDefault(6),
                PlaceOfReceiptName = f.ElementAtOrDefault(7),
                ServiceType = f.ElementAtOrDefault(8),
                FreightPayment = f.ElementAtOrDefault(9),
                BookingDate = ParseDate8(f.ElementAtOrDefault(10)),
            };
        }

        private static void ParseDischarge(IFCSUMConsignment c, List<string> f)
        {
            c.DischargePortCode = f.ElementAtOrDefault(0);
            c.DischargePortName = f.ElementAtOrDefault(1);
            c.FinalDestCode = f.ElementAtOrDefault(2);
            c.FinalDestName = f.ElementAtOrDefault(3);
        }

        private static ChargeItem ParseCharge(List<string> f)
        {
            return new ChargeItem
            {
                ChargeCode = f.ElementAtOrDefault(0),
                ChargeName = f.ElementAtOrDefault(1),
                LocationCode = f.ElementAtOrDefault(2),
                LocationName = f.ElementAtOrDefault(3),
                Quantity = ParseDecimal(f.ElementAtOrDefault(4)),
                Currency = f.ElementAtOrDefault(5),
                UnitRate = ParseDecimal(f.ElementAtOrDefault(6)),
                RateBasis = f.ElementAtOrDefault(7),
                TotalAmount = ParseDecimal(f.ElementAtOrDefault(8)),
                PaymentIndicator = f.ElementAtOrDefault(9),
            };
        }

        private IFCSUMParty ParseParty(string role, List<string> f)
        {
            string name = null;
            int nameIdx = -1;

            for (int i = 1; i < f.Count; i++)
            {
                var v = CleanField(f[i]);
                if (!string.IsNullOrWhiteSpace(v)) { name = v; nameIdx = i; break; }
            }

            string address = nameIdx >= 0
                ? string.Join(" ", f.Skip(nameIdx + 1)
                    .Select(CleanField)
                    .Where(x => !string.IsNullOrWhiteSpace(x)))
                : string.Empty;

            string fullBlock = (name ?? "") + " " + address;

            string taxId = null;
            var taxMatch = Regex.Match(fullBlock,
                @"TAX\s*(?:ID|REGISTRATION\s*NUMBER)\s*[#]?\s*(\d{6,})",
                RegexOptions.IgnoreCase);
            if (taxMatch.Success)
                taxId = taxMatch.Groups[1].Value.Trim();

            return new IFCSUMParty
            {
                PartyRole = GetRoleName(role),
                PartyId = taxId,
                PartyName = name,
                Address = address,
            };
        }

        public static string GetRoleName(string roleId)
        {
            switch (roleId)
            {
                case "16": return "Shipper";
                case "17": return "Consignee";
                default: return "NotifyParty";
            }
        }

        private GoodsSummary ParseGoodsSummary(List<string> f)
        {
            return new GoodsSummary
            {
                ItemNumber = f.ElementAtOrDefault(0),
                CargoType = f.ElementAtOrDefault(1),
                NumberOfPackages = ParseInt(f.ElementAtOrDefault(2)),
                PackageTypeCode = f.ElementAtOrDefault(3),
                PackageTypeName = f.ElementAtOrDefault(4),
                GrossWeight = ParseDecimal(f.ElementAtOrDefault(5)),
                Volume = ParseDecimal(f.ElementAtOrDefault(7)),
            };
        }

        private IFCSUMEquipment ParseEquipment(List<string> f)
        {
            return new IFCSUMEquipment
            {
                SequenceNumber = ParseInt(f.ElementAtOrDefault(0)) ?? 0,
                ContainerNumber = f.ElementAtOrDefault(1),
                SealNumber = f.ElementAtOrDefault(2),
                SizeType = f.ElementAtOrDefault(3),
                FullEmptyIndicator = f.ElementAtOrDefault(4),
                PackageCount = ParseInt(f.ElementAtOrDefault(5)),
                GrossWeight = ParseDecimal(f.ElementAtOrDefault(6)),
                VgmWeight = ParseDecimal(f.ElementAtOrDefault(7)),
            };
        }

 

        private static List<string> SplitFields(string payload)
        {
            var result = new List<string>();
            var current = new StringBuilder();
            bool inQuote = false;

            for (int i = 0; i < payload.Length; i++)
            {
                char c = payload[i];
                if (c == '"') { inQuote = !inQuote; }
                else if (c == ':' && !inQuote) { result.Add(current.ToString()); current.Clear(); }
                else { current.Append(c); }
            }

            result.Add(current.ToString());
            return result;
        }

        private static string CleanField(string s) =>
            s?.Trim().Trim('"').Trim('*').Trim();

        private static DateTime? ParseDate8(string s)
        {
            if (s == null || s.Length != 8) return null;
            if (DateTime.TryParseExact(s, "yyyyMMdd",
                System.Globalization.CultureInfo.InvariantCulture,
                System.Globalization.DateTimeStyles.None, out var d))
                return d;
            return null;
        }

        private static decimal ParseDecimal(string s)
        {
            if (decimal.TryParse(s?.Replace(",", ""),
                System.Globalization.NumberStyles.Any,
                System.Globalization.CultureInfo.InvariantCulture, out var v))
                return v;
            return 0m;
        }

        private static int? ParseInt(string s)
        {
            if (int.TryParse(s, out var v)) return v;
            return null;
        }

        private static IEnumerable<string> ChunkText(string text, int size)
        {
            for (int i = 0; i < text.Length; i += size)
                yield return text.Substring(i, Math.Min(size, text.Length - i));
        }
    }




}
