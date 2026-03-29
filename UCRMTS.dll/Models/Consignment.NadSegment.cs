using indice.Edi.Serialization;

namespace UCRMTS.dll.Models
{

        [EdiSegment, EdiPath("NAD")]
        public class NadSegment
        {
            [EdiValue("X(3)", Path = "NAD/0")]
            public string PartyQualifier { get; set; }

            [EdiValue("X(17)", Path = "NAD/1/0")]
            public string PartyId { get; set; }

            [EdiValue("X(35)", Path = "NAD/2/0")]
            public string PartyName { get; set; }

            [EdiValue("X(35)", Path = "NAD/3")]
            public string Street { get; set; }

            [EdiValue("X(35)", Path = "NAD/4")]
            public string City { get; set; }

            [EdiValue("X(9)", Path = "NAD/6")]
            public string PostalCode { get; set; }

            [EdiValue("X(3)", Path = "NAD/7")]
            public string CountryCode { get; set; }

            //[EdiCondition("AFM", Path = "NAD/8")]
            //public string UcrNumber { get; set; }
      }
   






}


