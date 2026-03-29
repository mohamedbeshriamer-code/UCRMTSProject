using indice.Edi.Serialization;

namespace UCRMTS.dll.Models
{
    [EdiSegment, EdiPath("SEL")]
    public class SealSegment
    {
        [EdiValue("X(17)", Path = "SEL/0")]
        public string SealNumber { get; set; }  // 062726

        [EdiValue("X(3)", Path = "SEL/1")]
        public string SealCondition { get; set; }  // CA
    }

}
