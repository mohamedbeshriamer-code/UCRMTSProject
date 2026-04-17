using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UCRMTS.dll;


namespace UCRMTSProject
{
    public partial class AddingConsigmentForm : Form
    {
        public AddingConsigmentForm()
        {
            InitializeComponent();
        }

        private async void btnTest_Click(object sender, EventArgs e)
        {
            var bolInformation = new BolInformation
            {
                IssuerID = "204829305",
                BolType = BolType.Final,           // BolType: 0 → Final
                UCR = null,
                CarrierID = "166",
                CarrierName = "Turkon",
                ShipperTaxID = null,
                BolNumber = "10003052",
                ConsgineeName = "MIKROLITE MINERAL SANAYI BE TICARET A.S",
                ConsigneeCity = "",
                ConsigneeCountryCode = "",
                ConsgineeTaxCode = "",
                PortOfLoadingCode = "EGALY",
                PortOfLoadingName = "ALEXANDRIA",
                PortOfDischargeCode = "TRALI",
                PortOfDischargeName = "ALIAGA",
                VesselImo = "9315927",
                VesselTitle = "SASKIA A",
                TotalGrossWeight = "212208",
                TotalCBM = null,
                UnitTypeOfCBM = null,
                TotalQuantity = "80",
                FinalDestinationCountry = null,
                ExporterTradCountry = "",
                ETA = DateTime.Parse("0001-01-01T00:00:00"),
                ATA = DateTime.Parse("0001-01-01T00:00:00"),

                GrossWeights = new List<GrossWeightBOL>
    {
        new GrossWeightBOL { TotalGrossWeight = "212208", UnitTypeGrossWeight = "KGs" },
        new GrossWeightBOL { TotalGrossWeight = "212208", UnitTypeGrossWeight = "KGs" },
        new GrossWeightBOL { TotalGrossWeight = "212208", UnitTypeGrossWeight = "KGs" },
        new GrossWeightBOL { TotalGrossWeight = "212208", UnitTypeGrossWeight = "KGs" },
        new GrossWeightBOL { TotalGrossWeight = "212208", UnitTypeGrossWeight = "KGs" },
        new GrossWeightBOL { TotalGrossWeight = "212208", UnitTypeGrossWeight = "KGs" },
        new GrossWeightBOL { TotalGrossWeight = "212208", UnitTypeGrossWeight = "KGs" },
        new GrossWeightBOL { TotalGrossWeight = "212208", UnitTypeGrossWeight = "KGs" }
    },

                GrossVolumn = new List<GrossVolumnBOL>
    {
        new GrossVolumnBOL { UnitCode = "CBM", Value = "200" },
        new GrossVolumnBOL { UnitCode = "CBM", Value = "200" },
        new GrossVolumnBOL { UnitCode = "CBM", Value = "200" },
        new GrossVolumnBOL { UnitCode = "CBM", Value = "200" },
        new GrossVolumnBOL { UnitCode = "CBM", Value = "200" },
        new GrossVolumnBOL { UnitCode = "CBM", Value = "200" },
        new GrossVolumnBOL { UnitCode = "CBM", Value = "200" },
        new GrossVolumnBOL { UnitCode = "CBM", Value = "200" }
    },

                ShippingOrderInformation = null,

                ContainerInformation = new List<ContainerInformation>
    {
        new ContainerInformation
        {
            ContainerNo           = "CAXU 684483 0",
            ContainerType         = "20DV",
            GrossWeight           = "26525.625",
            UnitTypeOfGrossWeight = "212208",
            GrossWeightUnitType   = "212208",
            GrossVolumn           = "0",
            GrossVolumnUnitType   = "CBM",
            CommodityCode         = "TALC LUMPS",
            Description           = "",
            ContainerSeals = new List<ContainerSeals>
            {
                new ContainerSeals { Serial = "", Condition = "CN" }
            }
        },
        new ContainerInformation
        {
            ContainerNo           = "WFHU 137845 8",
            ContainerType         = "20DV",
            GrossWeight           = "26525.625",
            UnitTypeOfGrossWeight = "212208",
            GrossWeightUnitType   = "212208",
            GrossVolumn           = "0",
            GrossVolumnUnitType   = "CBM",
            CommodityCode         = "TALC LUMPS",
            Description           = "TALC LUMPS IN 168 BIG BAGS",
            ContainerSeals = new List<ContainerSeals>
            {
                new ContainerSeals { Serial = "", Condition = "CN" }
            }
        },
        new ContainerInformation
        {
            ContainerNo           = "CAXU 627065 0",
            ContainerType         = "20DV",
            GrossWeight           = "26525.625",
            UnitTypeOfGrossWeight = "212208",
            GrossWeightUnitType   = "212208",
            GrossVolumn           = "0",
            GrossVolumnUnitType   = "CBM",
            CommodityCode         = "TALC LUMPS",
            Description           = "",
            ContainerSeals = new List<ContainerSeals>
            {
                new ContainerSeals { Serial = "", Condition = "CN" }
            }
        },
        new ContainerInformation
        {
            ContainerNo           = "WFHU 136367 4",
            ContainerType         = "20DV",
            GrossWeight           = "26525.625",
            UnitTypeOfGrossWeight = "212208",
            GrossWeightUnitType   = "212208",
            GrossVolumn           = "0",
            GrossVolumnUnitType   = "CBM",
            CommodityCode         = "TALC LUMPS",
            Description           = "",
            ContainerSeals = new List<ContainerSeals>
            {
                new ContainerSeals { Serial = "", Condition = "CN" }
            }
        },
        new ContainerInformation
        {
            ContainerNo           = "TRKU 203366 2",
            ContainerType         = "20DV",
            GrossWeight           = "26525.625",
            UnitTypeOfGrossWeight = "212208",
            GrossWeightUnitType   = "212208",
            GrossVolumn           = "0",
            GrossVolumnUnitType   = "CBM",
            CommodityCode         = "TALC LUMPS",
            Description           = "",
            ContainerSeals = new List<ContainerSeals>
            {
                new ContainerSeals { Serial = "", Condition = "CN" }
            }
        },
        new ContainerInformation
        {
            ContainerNo           = "WFHU 137490 9",
            ContainerType         = "20DV",
            GrossWeight           = "26525.625",
            UnitTypeOfGrossWeight = "212208",
            GrossWeightUnitType   = "212208",
            GrossVolumn           = "0",
            GrossVolumnUnitType   = "CBM",
            CommodityCode         = "TALC LUMPS",
            Description           = "",
            ContainerSeals = new List<ContainerSeals>
            {
                new ContainerSeals { Serial = "", Condition = "CN" }
            }
        },
        new ContainerInformation
        {
            ContainerNo           = "WFHU 137595 2",
            ContainerType         = "20DV",
            GrossWeight           = "26525.625",
            UnitTypeOfGrossWeight = "212208",
            GrossWeightUnitType   = "212208",
            GrossVolumn           = "0",
            GrossVolumnUnitType   = "CBM",
            CommodityCode         = "TALC LUMPS",
            Description           = "",
            ContainerSeals = new List<ContainerSeals>
            {
                new ContainerSeals { Serial = "", Condition = "CN" }
            }
        },
        new ContainerInformation
        {
            ContainerNo           = "TRKU 205101 2",
            ContainerType         = "20DV",
            GrossWeight           = "26525.625",
            UnitTypeOfGrossWeight = "212208",
            GrossWeightUnitType   = "212208",
            GrossVolumn           = "0",
            GrossVolumnUnitType   = "CBM",
            CommodityCode         = "TALC LUMPS",
            Description           = "",
            ContainerSeals = new List<ContainerSeals>
            {
                new ContainerSeals { Serial = "", Condition = "CN" }
            }
        }
    }
            };

            bolInformation.ShippingOrderInformation = new List<ShippingOrderInformation>();


            bolInformation.ShippingOrderInformation.Add(new ShippingOrderInformation
            {

                Sequance = 1,
                CargoDescription = "TALC LUMPS",
                NOS = "250510",
                Title = "8 X 20DV DRY CARGO CONTAINER",
                PackageNumber = "80",
                PackageType = "BG",
                CommodityCode = "250510",
                GrossVolumn = "200",
                GrossVolumnUnitType = "CBM",
                GrossWeight = "212208",
                GrossWeightUnitType = "KGM"
            });


            var result = await MTSRequests.BOL(bolInformation);
            if (result)
            {
                MessageBox.Show("BOL information sent successfully!");
            }

            //var cascare = new UCRMTS.dll.Models.CuscarInterchange();

            //// we will do mappings
            //cascare.Equipments = new List<UCRMTS.dll.Models.EquipmentGroup>();
            //cascare.Consignments = new List<UCRMTS.dll.Models.Consignment>();
            //cascare.Date = new UCRMTS.dll.Models.DtmSegment
            //{
            //    Date = DateTime.Now,
            //    FormatQualifier = "203",
            //    Qualifier = "137"
            //};
            //cascare.TransportInformation = new UCRMTS.dll.Models.TransportInformation();
            //cascare.TransportInformation.ArrivalDate = new UCRMTS.dll.Models.DtmSegment() {  Date =DateTime.Now};
            //cascare.TransportInformation.Vessel = "VV"; // "VVV"

            //var edi = new EDIForm(cascare);
            //edi.ShowDialog();


        }

    }

}

