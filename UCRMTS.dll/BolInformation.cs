using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UCRMTS.dll
{
    public class BolInformation
    {

        public string IssuerID { get; set; }

        public string UCR { get; set; }
        public string ShipperTaxID { get; set; }

        public string ShippingLineCode { get; set; }
        public string CarrierID { get; set; }

        public string CarrierName { get; set; }

        public string ConsgineeTaxCode { get; set; }

        public string ConsgineeName { get; set; }

        public string ConsigneeCity { get; set; }

        public string ConsigneeCountryCode { get; set; }

        public string PortOfLoadingCode { get; set; }

        public string PortOfLoadingName { get; set; }


        public string PortOfDischargeCode { get; set; }
        public string PortOfDischargeName { get; set; }

        public string VesselImo { get; set; }

        public string VesselTitle { get; set; }

        public string TotalGrossWeight { get; set; }

        public string FinalDestinationCountry { get; set; }

        public string TotalQuantity { get; set; }


        public string ExporterTradCountry { get; set; }

        public List<GrossWeightBOL> GrossWeights { get; set; }

        public List<GrossVolumnBOL> GrossVolumn { get; set; }

        public List<ShippingOrderInformation> ShippingOrderInformation { get; set; }


        public List<ContainerInformation>  ContainerInformation { get; set; }
        public string TotalCBM { get; set; }
        public string UnitTypeOfCBM { get; set; }

        public string BolNumber { get; set; }

        public BolType BolType { get; set; }

        public string BolTypeString { get
            {

                switch (BolType)
                {
                    case BolType.Draft:
                        return "68";
                     
                    case BolType.Final:
                        return "359";
                    default:
                        throw new Exception("Please specifiy the BOL Type Enum");
                }
            }
        }





        public DateTime ETA { get; set; }
        public DateTime ATA { get; set; } 



    }
    public enum BolType
    {
        Draft,
       Final
    }

public class GrossWeightBOL
    {
        public string TotalGrossWeight { get; set; }

        public string UnitTypeGrossWeight { get; set; }
    }

    public class GrossVolumnBOL
    {
        public string Value { get; set; }

        public string UnitCode { get; set; }
    }
    public class ContainerInformation
        {

        public string ContainerNo { get; set; }
        public string ContainerType { get; set; }

        public string Description { get; set; }

        public string GrossWeight { get; set; }
        public string UnitTypeOfGrossWeight { get; set; }



        public string GrossWeightUnitType { get; set; }

        public string GrossVolumn { get; set; }


        public string GrossVolumnUnitType { get; set; }

        public string CommodityCode { get; set; }
        public List<ContainerSeals>  ContainerSeals { get; set; }


    }

    public class ContainerSeals
    {
        public string Serial { get; set; }

        public string Condition { get; set; }
    }

    public class ShippingOrderInformation
    {
        public int Sequance { get; set; }
        public string CargoDescription { get; set; }
        public string NOS { get; set; }

        public string Title { get; set; }

        public string PackageNumber { get; set; }

        public string PackageType { get; set; }


        public string GrossWeight { get; set; }

        public string GrossWeightUnitType { get; set; }

        public string GrossVolumn { get; set; }


        public string GrossVolumnUnitType { get; set; }

        public string  CommodityCode { get; set; }


        override public string ToString()
        {
            return $"{NOS} - {Title}";
        }

    }
}
