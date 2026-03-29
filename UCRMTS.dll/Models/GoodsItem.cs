using indice.Edi.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UCRMTS.dll.Models
{
    [EdiSegmentGroup("GID", SequenceEnd = "GID")]
    public class GoodsItem
    {
        // GID
        [EdiValue("X(3)", Path = "GID/0")]
        public string GoodsItemNumber { get; set; }

        [EdiValue("X(10)", Path = "GID/1/0")]
        public string NumberOfPackages { get; set; }

        [EdiValue("X(3)", Path = "GID/1/1")]
        public string PackageType { get; set; }


        [EdiValue("X(35)", Path = "GID/2/0")]
        public string HsCode { get; set; }


        [EdiValue("X(512)", Path = "FTX/3")]
        public string Description { get; set; }

        [EdiValue("X(30)", Path = "SGP/1/1", Mandatory = true)]
        public ContainerInfo ContainerInfo { get; set; }

        [EdiValue("X(10)", Path = "PCI/0")]
        public string PackageCount { get; set; }

        public Measurement Measurement { get; set; }


        [EdiValue("X(3)", Path = "PCI/0")]
        public string PackingCode { get; set; }


        [EdiValue("X(3)", Path = "CST/0")]
        public string CustomsStatus { get; set; }

        [EdiValue("X(35)", Path = "CST/1/0")]
        public string CommodityCode { get; set; }


    }
}
