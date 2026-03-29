using indice.Edi.Serialization;

namespace UCRMTS.dll.Models
{
    [EdiSegment, EdiPath("MEA")]
    public class MeasurementSegment
    {
        [EdiValue("X(3)", Path = "MEA/0")]
        public string MeasurementPurpose { get; set; }  // AAE

        [EdiValue("X(3)", Path = "MEA/1")]
        public string MeasurementAttribute { get; set; }  // G or T

        [EdiValue("X(3)", Path = "MEA/2/0")]
        public string MeasurementUnit { get; set; }  // KGM

        [EdiValue("9(10)", Path = "MEA/2/1")]
        public decimal? Value { get; set; }  // 20839 or 3820

        public override string ToString()
        {
            return $"{Value} {MeasurementUnit}";
        }

    }

}
