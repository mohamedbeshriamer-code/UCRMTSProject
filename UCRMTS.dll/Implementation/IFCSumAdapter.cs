using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static UCRMTS.dll.Models.Consignment;
using UCRMTS.dll.Models;

namespace UCRMTS.dll.Implementation
{
    public interface ICuscar95BAdapter
    {
        CuscarInterchange GetEDI();
    }
    public class IFCSumAdapter : ICuscar95BAdapter
    {
        private readonly IFCSUMManifestInterchange _manifest;


        public IFCSumAdapter(IFCSUMManifestInterchange manifest)
        {
            _manifest = manifest ?? throw new ArgumentNullException(nameof(manifest));
        }

        public CuscarInterchange GetEDI()
        {
            var cuscar = new CuscarInterchange
            {

                SenderId = _manifest.SenderId,
                MessageType = _manifest.MessageType,
                DocumentNumber = _manifest.InterchangeControl,
                DocumentNameCode = _manifest.DocumentType,
                Date = new DtmSegment() { Date = DateTime.Now.Date},


                TransportInformation = MapTransport(),

                //PortOfLoading = MapPortOfLoading(),
                //PortOfDischarge = MapPortOfDischarge(),
                //PortOfReceipt = MapPortOfReceipt(),


                Equipments = MapEquipments(),


                Consignments = MapConsignments(),
            };

            return cuscar;
        }


        private TransportInformation MapTransport()
        {
            var v = _manifest.Voyage;
            if (v == null) return null;

            return new TransportInformation
            {

                Voage = v.VoyageNumber,
                IMO = v.VesselCode,
                CarrierCode = _manifest.CarrierCode,
                Vessel = v.VesselName,
                PortOfLoading = MapPortOfLoading(),
                PortOfDischarge = MapPortOfDischarge(),
                PortOfReceipt = MapPortOfReceipt()
            };
        }


        private LocationSegment MapPortOfLoading()
        {
            var first = _manifest.Consignments.FirstOrDefault();
            if (first == null) return null;
            return new LocationSegment
            {
                Qualifier = "11",
                LocationCode = first.OriginPortCode,
                LocationName = first.OriginPortName,
            };
        }

        private LocationSegment MapPortOfDischarge()
        {
            var first = _manifest.Consignments.FirstOrDefault();
            if (first == null) return null;
            return new LocationSegment
            {
                Qualifier = "9",
                LocationCode = first.DischargePortCode,
                LocationName = first.DischargePortName,
            };
        }

        private LocationSegment MapPortOfReceipt()
        {
            var v = _manifest.Voyage;
            if (v == null) return null;
            return new LocationSegment
            {
                Qualifier = "60",
                LocationCode = v.PortOfCallCode,
                LocationName = v.PortOfCallName,
            };
        }


        private List<EquipmentGroup> MapEquipments()
        {
            var result = new List<EquipmentGroup>();

            foreach (var consignment in _manifest.Consignments)
            {
                foreach (var eq in consignment.Equipments)
                {
                    result.Add(new EquipmentGroup
                    {
                        EquipmentQualifier = "CN",
                        ContainerNumber = eq.ContainerNumber,
                        SizeAndType = eq.SizeType,
                        FullEmptyIndicator = eq.FullEmptyIndicator == "F" ? "4" : "1",

                        // Gross weight → GrossWeight measurement segment
                        GrossWeight = eq.GrossWeight.HasValue
                            ? new MeasurementSegment
                            {
                                MeasurementPurpose = "AAE",
                                MeasurementAttribute = "G",
                                MeasurementUnit = "KGM",
                                Value = eq.GrossWeight,
                            }
                            : null,
                        TareWeight = new MeasurementSegment()
                        {
                            MeasurementPurpose = "AAE",
                            MeasurementAttribute = "T",
                            MeasurementUnit = "KGM",
                            Value = eq.GrossWeight - eq.NetWeight,
                        },


                        // Seal
                        SealSegments = string.IsNullOrWhiteSpace(eq.SealNumber)
                            ? null
                            : new List<SealSegment>
                              {
                                  new SealSegment { SealNumber = eq.SealNumber }
                              },
                    });
                }
            }

            return result;
        }

  
        private List<Consignment> MapConsignments()
        {
            var result = new List<Consignment>();
            int seq = 1;

            foreach (var src in _manifest.Consignments)
            {
                var consignment = new Consignment
                {
                    ConsignmentNumber = seq++.ToString(),
                    BillOfLadingNumber = src.BillOfLadingNumber,


                    Shipper = MapParty(src.Shipper, "CZ"),
                    Consignee = MapParty(src.Consignee, "CN"),
                    NotifyParty = MapParty(src.NotifyParty, "N1"),


                    GoodsItems = MapGoodsItems(src),


                    Locations = MapConsignmentLocations(src),
                };


                consignment.ACCID = src.AcidNumber ?? string.Empty;


                if (consignment.Consignee != null
                    && string.IsNullOrWhiteSpace(consignment.Consignee.PartyId)
                    && !string.IsNullOrWhiteSpace(src.EgyptianImporterTaxId))
                {
                    consignment.Consignee.PartyId = src.EgyptianImporterTaxId;
                }

                result.Add(consignment);
            }

            return result;
        }

        // ── NadSegment mapping ───────────────────────────────────────
        private static NadSegmentQ MapParty(IFCSUMParty src, string qualifier)
        {
            if (src == null) return null;

            string street = null;
            string city = null;

            if (!string.IsNullOrWhiteSpace(src.Address))
            {
                var commaIdx = src.Address.IndexOf(',');
                if (commaIdx > 0)
                {
                    street = src.Address.Substring(0, commaIdx).Trim();
                    city = src.Address.Substring(commaIdx + 1).Trim();
                }
                else
                {
                    street = src.Address.Trim();
                }
            }

            return new NadSegmentQ
            {
                PartyQualifier = qualifier,
                PartyId = src.PartyId,
                PartyName = src.PartyName,
                Street = street,
                City = city,
            };
        }

        private static List<GoodsItem> MapGoodsItems(IFCSUMConsignment src)
        {
            if (src.Goods == null) return null;


            string description = string.Join(" ", src.DescriptionLines);

            var item = new GoodsItem
            {
                GoodsItemNumber = src.Goods.ItemNumber,
                NumberOfPackages = Convert.ToString(src.Goods.NumberOfPackages),
                PackageType = src.Goods.PackageTypeCode,
                HsCode = src.HsCode,                  // from ProcessDescription()
                Description = description,


                Measurement = src.Goods.GrossWeight.HasValue
                    ? new Measurement
                    {
                        Purpose = "AAE",
                        Dimension = "G",
                        Unit = "KGM",
                        Value = src.Goods.GrossWeight,
                    }
                    : null,
            };


            var firstEq = src.Equipments.FirstOrDefault();
            if (firstEq != null)
            {
                item.ContainerInfo = new ContainerInfo()
                {
                    ContainerNumber = firstEq.ContainerNumber
                };

                item.PackageCount = Convert.ToString(firstEq.PackageCount);
            }

            return new List<GoodsItem> { item };
        }


        private static List<LocationSegment> MapConsignmentLocations(IFCSUMConsignment src)
        {
            var locs = new List<LocationSegment>();

            if (!string.IsNullOrWhiteSpace(src.OriginPortCode))
                locs.Add(new LocationSegment
                {
                    Qualifier = "60",   // port of loading
                    LocationCode = src.OriginPortCode,
                    LocationName = src.OriginPortName,
                });

            if (!string.IsNullOrWhiteSpace(src.DischargePortCode))
                locs.Add(new LocationSegment
                {
                    Qualifier = "11",   // port of discharge
                    LocationCode = src.DischargePortCode,
                    LocationName = src.DischargePortName,
                });

            if (!string.IsNullOrWhiteSpace(src.FinalDestCode))
                locs.Add(new LocationSegment
                {
                    Qualifier = "7",    // place of delivery
                    LocationCode = src.FinalDestCode,
                    LocationName = src.FinalDestName,
                });

            return locs.Count > 0 ? locs : null;
        }
    }
}
