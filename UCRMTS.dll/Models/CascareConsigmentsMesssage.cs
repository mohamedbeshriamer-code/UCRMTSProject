using indice.Edi.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UCRMTS.dll.Models
{
    public class CascareConsigmentsMesssage
    {
        [EdiSegmentGroup("CNI")]
        public List<Consignment> Consignments { get; set; } = new List<Consignment>();
    }
}
