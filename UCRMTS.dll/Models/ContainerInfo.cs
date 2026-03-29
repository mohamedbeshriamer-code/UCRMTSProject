using indice.Edi.Serialization;

namespace UCRMTS.dll.Models
{
    [EdiSegment, EdiPath("SGP")]

    public class ContainerInfo

    {

        [EdiValue("X(30)", Path = "SGP/0/0", Mandatory = true)]
        public string ContainerNumber { get; set; }

        public override string ToString()
        {
            return ContainerNumber;
        }

    }
    [EdiSegment, EdiPath("RFF")]
    public class Reference
    {
        [EdiValue("X(3)", Path = "RFF/0/0")]
        public string Qualifier { get; set; }

        [EdiValue("X(35)", Path = "RFF/0/1")]
        public string Number { get; set; }
    }
}
