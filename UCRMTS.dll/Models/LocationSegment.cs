using indice.Edi.Serialization;

namespace UCRMTS.dll.Models
{
    [EdiSegment, EdiPath("LOC")]
    public class LocationSegment
    {
        [EdiValue("X(3)", Path = "LOC/0")]
        public string Qualifier { get; set; }

        [EdiValue("X(17)", Path = "LOC/1/0")]
        public string LocationCode { get; set; }  // USSAV / EGALY

        [EdiValue("X(3)", Path = "LOC/1/1")]
        public string CodeListQualifier { get; set; }  // 139

        [EdiValue("X(3)", Path = "LOC/1/2")]
        public string CodeListResponsible { get; set; }  // 6

        [EdiValue("X(35)", Path = "LOC/1/3")]
        public string LocationName { get; set; }  // Savannah Garden CIty TermInal
    }
}
