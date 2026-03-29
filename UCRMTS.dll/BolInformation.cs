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

        public string PortOfLoadingCode { get; set; }

        public string PortOfLoadingName { get; set; }


        public string PortOfDischargeCode { get; set; }
        public string PortOfDischargeName { get; set; }

        public string VesselImo { get; set; }

        public string VesselTitle { get; set; }

        public string TotalGrossWeight { get; set; }

        public string UnitTypeGrossWeight { get; set; }

        




        public string TotalCBM { get; set; }
        public string UnitTypeOfCBM { get; set; }

    

        public DateTime ETA { get; set; }



    }
}
