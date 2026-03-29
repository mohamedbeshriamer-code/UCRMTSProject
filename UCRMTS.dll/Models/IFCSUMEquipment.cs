using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace UCRMTS.dll.Models
{
    public class IFCSUMManifestInterchange
    {

        public string MessageType { get; set; }
        public string DocumentType { get; set; }
        public string SyntaxVersion { get; set; }
        public string SenderId { get; set; }
        public string ReceiverRole { get; set; }
        public string InterchangeControl { get; set; }


        public VoyageInformation Voyage { get; set; }


        public string CarrierCode { get; set; }
        public string CarrierName { get; set; }


        public List<IFCSUMConsignment> Consignments { get; set; } = new List<IFCSUMConsignment>();


        public int? ControlCount { get; set; }
    }


    public class VoyageInformation
    {
        public string VesselCode { get; set; }
        public string VesselName { get; set; }
        public string VoyageNumber { get; set; }
        public DateTime? DepartureDate { get; set; }
        public DateTime? ArrivalDate { get; set; }
        public string PortOfCallCode { get; set; }
        public string PortOfCallName { get; set; }
        public string SequenceNumber { get; set; }
    }


    public class IFCSUMConsignment
    {

        public string BillOfLadingNumber { get; set; }
        public string OriginPortCode { get; set; }
        public string OriginPortName { get; set; }
        public string PlaceOfReceiptCode { get; set; }
        public string PlaceOfReceiptName { get; set; }
        public string ServiceType { get; set; }
        public string FreightPayment { get; set; }
        public DateTime? BookingDate { get; set; }


        public string DischargePortCode { get; set; }
        public string DischargePortName { get; set; }
        public string FinalDestCode { get; set; }
        public string FinalDestName { get; set; }


        public List<ChargeItem> Charges { get; set; } = new List<ChargeItem>();


        public IFCSUMParty Shipper { get; set; }
        public IFCSUMParty Consignee { get; set; }
        public IFCSUMParty NotifyParty { get; set; }


        public GoodsSummary Goods { get; set; }

        public string Marks { get; set; }


        public List<string> DescriptionLines { get; set; } = new List<string>();


        public List<IFCSUMEquipment> Equipments { get; set; } = new List<IFCSUMEquipment>();


        public string AcidNumber { get; set; }
        public string EgyptianImporterTaxId { get; set; }
        public string HsCode { get; set; }
        public string ForeignExporterId { get; set; }
        public string ForeignExporterCountry { get; set; }
        public string ForeignExporterCountryCode { get; set; }
        public string ForeignExporterRegistrationType { get; set; }
        public string EdNumber { get; set; }


        public decimal NetWeight { get; set; }



        public void ProcessDescription()
        {
            string fullText = string.Join(" ", DescriptionLines);

            AcidNumber = ExtractAfter(fullText, @"ACID[:\s]+(\d+)");
            EgyptianImporterTaxId = ExtractAfter(fullText, @"EGYPTIAN IMPORTER TAX ID[:\s]+(\d+)");
            HsCode = ExtractAfter(fullText, @"H\.?S\.?\s*CODE[:\s]+([\d.]+)");
            ForeignExporterId = ExtractAfter(fullText, @"FOREIGN EXPORTER ID[:\s]+([\w]+)");
            ForeignExporterCountry = ExtractAfter(fullText, @"FOREIGN EXPORTER COUNTRY[:\s]+([A-Z\s]+?)(?=FOREIGN|$)");
            ForeignExporterCountryCode = ExtractAfter(fullText, @"FOREIGN EXPORTER COUNTRY CODE[:\s]+([A-Z]{2})");
            ForeignExporterRegistrationType = ExtractAfter(fullText, @"FOREIGN EXPORTER REGISTRATION TYPE[:\s]+([\w\s]+?)(?=FOREIGN|VAT|$)");
            EdNumber = ExtractAfter(fullText, @"ED[:\s]+([\d\-]+)");

            var netWeightStr = ExtractAfter(fullText, @"NETT?\s*WEIGHT\s*[:\s]+([\d,]+(?:\.\d+)?)");
            if (netWeightStr != null)
            {
                var clean = netWeightStr.Replace(",", "");
                if (decimal.TryParse(clean, NumberStyles.Any, CultureInfo.InvariantCulture, out var nw))
                    NetWeight = nw;
            }
            var netWeightPerContainer = NetWeight / this.Equipments.Count;
            foreach (var item in this.Equipments)
            {
                item.NetWeight = netWeightPerContainer;

            }
        }

        private static string ExtractAfter(string text, string pattern)
        {
            var m = Regex.Match(text, pattern, RegexOptions.IgnoreCase);
            return m.Success ? m.Groups[1].Value.Trim() : null;
        }
    }


    public class ChargeItem
    {
        public string ChargeCode { get; set; }
        public string ChargeName { get; set; }
        public string LocationCode { get; set; }
        public string LocationName { get; set; }
        public decimal? Quantity { get; set; }
        public string Currency { get; set; }
        public decimal? UnitRate { get; set; }
        public string RateBasis { get; set; }
        public decimal? TotalAmount { get; set; }
        public string PaymentIndicator { get; set; }
    }


    public class IFCSUMParty
    {

        public string PartyRole { get; set; }
        public string PartyId { get; set; }
        public string PartyName { get; set; }
        public string Address { get; set; }
    }


    public class GoodsSummary
    {
        public string ItemNumber { get; set; }
        public string CargoType { get; set; }
        public int? NumberOfPackages { get; set; }
        public string PackageTypeCode { get; set; }
        public string PackageTypeName { get; set; }
        public decimal? GrossWeight { get; set; }
        public decimal? Volume { get; set; }
    }


    public class IFCSUMEquipment
    {
        public int SequenceNumber { get; set; }
        public string ContainerNumber { get; set; }
        public string SealNumber { get; set; }
        public string SizeType { get; set; }
        public string FullEmptyIndicator { get; set; }
        public int? PackageCount { get; set; }
        public decimal? GrossWeight { get; set; }

        public decimal? NetWeight { get; set; }
        public decimal? VgmWeight { get; set; }
    }
}
