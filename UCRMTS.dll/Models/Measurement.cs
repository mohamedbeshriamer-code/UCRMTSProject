using indice.Edi.Serialization;

namespace UCRMTS.dll.Models
{
    [EdiSegmentGroup("MEA")]
    public class Measurement
    {
        // AAE (always measurement)
        [EdiValue("X(3)", Path = "MEA/0")]
        public string Purpose { get; set; }

        // G or T (dimension)
        [EdiValue("X(3)", Path = "MEA/1/0")]
        public string Dimension { get; set; }

        // KGM (unit)
        [EdiValue("X(3)", Path = "MEA/2/0")]
        public string Unit { get; set; }

        // numeric value

        [EdiValue("9(10)", Path = "MEA/2/1")]
        public decimal? Value { get; set; }


        public override string ToString()
        {
            return $"Value : {this.Value} Unit {this.Unit}";
        }

    }
}
