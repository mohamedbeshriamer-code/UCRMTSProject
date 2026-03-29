using indice.Edi.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UCRMTS.dll.Models
{
    [EdiMessage]
    public class CuscarInterchange
    {
        private DtmSegment _arrivelSegment = null;

        [EdiValue("X(35)", Path = "UNB/1/0")]
        public string SenderId { get; set; }

        [EdiValue("X(35)", Path = "UNB/2/0")]
        public string ReciverID { get; set; }

[EdiValue("9(8)", Path = "UNB/3/0", Format = "yyyyMMdd")]
        public DateTime InterchangeDate { get; set; }

       
        //[EdiCondition("132", Path = "DTM/0/0")]
        //public DtmSegment ArrivalDate { get; set; }

        [EdiValue("X(14)", Path = "UNH/0")]
        public string MessageReferenceNumber { get; set; }

        [EdiValue("X(6)", Path = "UNH/1/0")]
        public string MessageType { get; set; }

        [EdiValue("X(3)", Path = "UNH/1/1")]
        public string Version { get; set; }

        [EdiValue("X(3)", Path = "UNH/1/2")]
        public string Release { get; set; }

        [EdiValue("X(2)", Path = "UNH/1/3")]
        public string ControllingAgency { get; set; }

        [EdiValue("X(6)", Path = "UNH/1/4")]
        public string AssociationCode { get; set; }

        [EdiValue("X(3)", Path = "BGM/0")]
        public string DocumentNameCode { get; set; }

        [EdiValue("X(35)", Path = "BGM/1")]
        public string DocumentNumber { get; set; }

        [EdiValue("X(3)", Path = "BGM/2")]
        public string MessageFunctionCode { get; set; }

   
        [EdiCondition("137",Path ="DTM/0")]
        public DtmSegment Date { get; set; }

  

        public string FormatCode { get; set; }



        public NADSegment Nad { get; set; }


        // public TransportInformation TransportInformation { get; set; }

        [EdiSegmentGroup("TDT", "LOC", "DTM")]
        public TransportInformation TransportInformation { get; set; }


        [EdiSegmentGroup("EQD")]
        public List<EquipmentGroup> Equipments { get; set; } = new List<EquipmentGroup>();

        [EdiSegmentGroup("CNI")]
        public List<Consignment> Consignments { get; set; }


        [EdiSegment, EdiPath("UNT")]
        public MessageTrailer Trailer { get; set; }

   
        [EdiSegment, EdiPath("UNZ")]
        public InterchangeTrailer InterchangeTrailer { get; set; }
    }

    [EdiSegment, EdiPath("UNZ")]
    public class InterchangeTrailer
    {
       
        [EdiValue("9(6)", Path = "UNZ/0")]
        public int MessageCount { get; set; }


        [EdiValue("X(14)", Path = "UNZ/1")]
        public string ControlReference { get; set; }
    }
    [EdiSegment, EdiPath("UNT")]
    public class MessageTrailer
    {

        [EdiValue("9(6)", Path = "UNT/0")]
        public int SegmentCount { get; set; }


        [EdiValue("X(14)", Path = "UNT/1")]
        public string MessageReference { get; set; }
    }
    [EdiSegment,EdiPath("NAD")]
    public class NADSegment
    {
        [EdiValue("X(3)", Path = "NAD/0")]
        public string PartyQualifier { get; set; }

        [EdiValue("X(35)", Path = "NAD/1")]
        public string PartyId { get; set; }
      
    }

    [EdiSegment, EdiPath("DTM")]
    public class DtmSegment
    {
      
        
        [EdiValue("X(3)", Path = "DTM/0/0")]
        public string Qualifier { get; set; }


        [EdiValue("9(8)", Path = "DTM/0/1", Format = "yyyyMMdd")]
        public DateTime Date { get; set; }

       



        [EdiValue("X(3)", Path = "DTM/0/2")]
        public string FormatQualifier { get; set; }


    }
   

}
