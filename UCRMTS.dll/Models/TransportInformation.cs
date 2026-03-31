using indice.Edi.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace UCRMTS.dll.Models
{
    [EdiSegmentGroup("TDT", "LOC", "DTM")]
    public class TransportInformation
    {
        [EdiValue("X(3)", Path = "TDT/0")]
        public string TransportStageCode { get; set; }

        [EdiValue("X(35)", Path = "TDT/1")]
        public string Voage { get; set; }

        [EdiValue("X(3)", Path = "TDT/2")]
        public string TransportStageIndicator { get; set; }

        [EdiValue("X(6)", Path = "TDT/4/0")]
        public string CarrierCode { get; set; }

        [EdiValue("X(3)", Path = "TDT/4/1")]
        public string CarrierQualifier { get; set; }

        [EdiValue("X(3)", Path = "TDT/4/2")]
        public string CarrierID { get; set; }



        [EdiValue("X(3)", Path = "TDT/7/1")]
        public string JourneyQualifier { get; set; }

        [EdiValue("X(3)", Path = "TDT/7/2")]
        public string TradeCountry { get; set; }

        [EdiValue("X(35)", Path = "TDT/7/3")]
        public string Vessel { get; set; }

        [EdiValue("X(10)", Path = "TDT/7/0")]
        public string IMO { get; set; }

        [EdiCondition("9", Path = "LOC/0")]
        public LocationSegment PortOfLoading { get; set; }

        [EdiCondition("60", Path = "LOC/0")]
        public LocationSegment PortOfReceipt { get; set; }

        [EdiCondition("11", Path = "LOC/0")]
        public LocationSegment PortOfDischarge { get; set; }

        [EdiCondition("5", Path = "LOC/0")]
        public LocationSegment PortOfDeparture { get; set; }

        [EdiCondition("132", Path = "DTM/0/0")]
        public DtmSegment ArrivalDate { get; set; }


        [EdiCondition("133", Path = "DTM/0/0")]
        public DtmSegment DepartureDate { get; set; }


  
    }
 
   


    public class LocationData
    {
        public string PortCode { get; set; }
        public string PortName { get; set; }
    }

    [EdiSegmentGroup("CNI")]

    public partial class Consignment

    {

        [EdiValue("X(30)", Path = "CNI/0")]

        public string ConsignmentNumber { get; set; }

        [EdiValue("X(35)", Path = "CNI/1")]

        public string BillOfLadingNumber { get; set; }

        [EdiSegment, EdiPath("RFF")]
        public List<Reference> References { get; set; }

        [EdiValue("X(3)", Path = "GIS/0")]

        public string GeneralIndicator { get; set; }


        [EdiCondition("179", Path = "DTM/0")]
        public DtmSegment BookingDate { get; set; }

        [EdiCondition("2005", Path = "DTM/0")]
        public DtmSegment BillOfLadingDate { get; set; }

     

        public LocationData PortOfLoading
        {
            get
            {
                var loc = Locations?.FirstOrDefault(a => a.Qualifier == "9");
                if (loc != null)
                {
                    return new LocationData()
                    {
                        PortCode = loc.LocationCode,
                        PortName = loc.LocationName,
                    };

                }
                return new LocationData();


            }
        }

        public LocationData PortOfDischarge
        {
            get
            {
                var loc = Locations?.FirstOrDefault(a => a.Qualifier == "11");
                return new LocationData()
                {
                    PortCode = loc.LocationCode,
                    PortName = loc.LocationName,
                };


            }
        }



        public List<LocationSegment> Locations { get; set; }

        [EdiCondition("CZ", Path = "NAD/0")]

        public NadSegment Shipper { get; set; }

        [EdiCondition("CN", Path = "NAD/0")]

        public NadSegment Consignee { get; set; }

        [EdiCondition("N1", Path = "NAD/0")]

        public NadSegment NotifyParty { get; set; }



        // GID

        [EdiSegmentGroup("GID")]

        public List<GoodsItem> GoodsItems { get; set; }

        public string ACCID { get; set; } = string.Empty;

        public void ProcessDescriptionItem()
        {
            if (GoodsItems == null) return;

            foreach (var item in GoodsItems)
            {



                if (string.IsNullOrWhiteSpace(this.ACCID))
                {
                    this.ACCID = TryMapACID(item.Description);
                }


                if (string.IsNullOrWhiteSpace(this.Shipper.PartyId))
                {
                    this.Shipper.PartyId = TryMapExporterID(item.Description);
                }

                if (string.IsNullOrWhiteSpace(this.Consignee.PartyId))
                {
                    this.Consignee.PartyId = TryMapImporterTaxID(item.Description);
                }



            }
        }
        public string TryMapACID(string description)
        {

            Match match = Regex.Match(description,
                @"ACID(?:\s+NO)?\s*:?\s*(\d{19,})",
                RegexOptions.IgnoreCase);

            if (match.Success)
                return match.Groups[1].Value.Trim();


            Match secondTry = Regex.Match(description,
                @"ACID\s+NO\s*:\s*(\d{19,})",
                RegexOptions.IgnoreCase);
            if (secondTry.Success)
                return secondTry.Groups[1].Value.Trim();

            Match thirdTry = Regex.Match(description,
                 @"ACID(?:\s+NO)?\s*:?\s*(\d{15,})",
                 RegexOptions.IgnoreCase);

            if (thirdTry.Success)
                return thirdTry.Groups[1].Value.Trim();

            return null;
        }
        public string TryMapHSCode(string description)
        {
            Match match = Regex.Match(description, @"H\.?S\s*CODE\s*:\s*([\d.]+)");

            return match.Success ? match.Groups[1].Value.Trim() : null;

        }
        public string TryMapImporterTaxID(string description)
        {

            Match match = Regex.Match(description,
                @"(?:EGYPTIAN\s+)?IMPORTER\s+TAX\s+ID\s*:?\s*(\d+)",
                RegexOptions.IgnoreCase);
            return match.Success ? match.Groups[1].Value.Trim() : null;
        }


        public string TryMapExporterID(string description)
        {
            // First try: "FOREIGN EXPORTER ID:", "FOREIGN EXPORTER ID. :", "Foreign Exporter ID"
            Match match = Regex.Match(description,
                @"FOREIGN\s+EXPORTER\s+ID\.?\s*:?\s*(\d+)",
                RegexOptions.IgnoreCase);

            if (match.Success)
                return match.Groups[1].Value.Trim();

            // Second try: "EXPORTER TAX ID", "EXPORTER TAX ID:"
            Match secondTry = Regex.Match(description,
                @"EXPORTER\s+TAX\s+ID\s*:?\s*(\d+)",
                RegexOptions.IgnoreCase);

            return secondTry.Success ? secondTry.Groups[1].Value.Trim() : null;
        }

        




    }

}
