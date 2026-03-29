using indice.Edi.Serialization;
using System.Collections.Generic;
using System.Linq;

namespace UCRMTS.dll.Models
{
    [EdiSegmentGroup("EQD")]
    public class EquipmentGroup
    {

        [EdiValue("X(3)", Path = "EQD/0")]
        public string EquipmentQualifier { get; set; }  // CN

        [EdiValue("X(17)", Path = "EQD/1/0")]
        public string ContainerNumber { get; set; }  // TRKU4447126

        [EdiValue("X(4)", Path = "EQD/2/0")]
        public string SizeAndType { get; set; }  // 45G1

        [EdiValue("X(3)", Path = "EQD/5")]
        public string FullEmptyIndicator { get; set; }  // 6 = Full

        [EdiValue("X(3)", Path = "EQD/6")]
        public string EquipmentStatusCode { get; set; }  // 5

        [EdiCondition("G", Path = "MEA/1")]
        public MeasurementSegment GrossWeight { get; set; }  // 20839

        [EdiCondition("T", Path = "MEA/1")]
        public MeasurementSegment TareWeight { get; set; }   // 3820

        public List<SealSegment> SealSegments { get; set; }

        public string SealDescription {
            get
            {
                if(SealSegments == null)
                {
                    return "";
                }
                return string.Join(", ", SealSegments.Select(s => string.Concat("Seal Number : ", s.SealNumber, " ", "Seal Condtion :", s.SealCondition)));
            }
            
        }


    }

}
