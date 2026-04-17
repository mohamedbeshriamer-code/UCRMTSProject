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

            //    IssuerID = "204829305",

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

            //    BolType = BolType.Final,


            //    UCR = "3742795351004720042",
            //    CarrierID = "YML",
            //    CarrierName = "YANG MING",
            //    ShipperTaxID = "CON123456",
            //    BolNumber = "MAEU123456789",


            //    ConsgineeName = "XYZ IMPORTS BV",
            //    ConsigneeCity = "Rotterdam",
            //    ConsigneeCountryCode = "NL",
            //    ConsgineeTaxCode = "",


            //    PortOfLoadingCode = "EGEDK",
            //    PortOfLoadingName = "El Dekheila Port, Egypt",
            //    PortOfDischargeCode = "NLRTM",
            //    PortOfDischargeName = "Rotterdam, Netherlands",


            //    VesselImo = "9270476",
            //    VesselTitle = "XIN XIA MEN",


            //    TotalGrossWeight = "25000",
            //    TotalCBM = "55",
            //    UnitTypeOfCBM = "MTQ",
            //    TotalQuantity = "100",


            //    FinalDestinationCountry = "NL",
            //    ExporterTradCountry = "EG",


            //    ETA = DateTime.Parse("2024-10-15T08:00:00Z"),
            //    ATA = DateTime.Parse("2024-10-01T12:00:00Z"), // departureEvent actualOccurrenceDateTime


            //    GrossWeights = new List<GrossWeightBOL>
            //    {
            //        new GrossWeightBOL
            //        {
            //            TotalGrossWeight    = "25000",
            //            UnitTypeGrossWeight = "KGM"
            //        }
            //    },
            //    GrossVolumn = new List<GrossVolumnBOL>()
            //    {
            //        new GrossVolumnBOL()
            //        {
            //            UnitCode = "MTQ",
            //            Value = "55"
            //        }
            //    }
            //    ,



            bolInformation.ShippingOrderInformation = new List<ShippingOrderInformation>();

            //    ShippingOrderInformation = new List<ShippingOrderInformation>
            //        {
            //            new ShippingOrderInformation
            //            {
            //                Sequance         = 1,
            //                CargoDescription = "Clove Seeds",
            //                NOS              = "120922",       // typeCode
            //                Title            = "1 X 20DC DRY CARGO CONTAINER", // physicalLogisticsShippingMarks
            //                PackageNumber    = "50",           // transportLogisticsPackage.itemQuantity
            //                PackageType      = "TV"            // transportLogisticsPackage.typeCode,
            //                ,
            //                CommodityCode = "120922",
            //                GrossVolumn = "55",
            //                GrossVolumnUnitType = "MTQ",
            //                 GrossWeight = "25000",
            //                 GrossWeightUnitType = "KGM",

            bolInformation.ShippingOrderInformation.Add(new ShippingOrderInformation
            {

            //            }
            //        },

            //    // Container — from utilizedLogisticsTransportEquipment
            //    ContainerInformation = new List<ContainerInformation>
            //    {
            //    {
            //        new ContainerInformation
            //        {
            //            ContainerNo           = "MSCU7654321",
            //            ContainerType         = "22G1",        // characteristicCode
            //            GrossWeight           = "28000",
            //            UnitTypeOfGrossWeight = "KGM",
            //             GrossVolumn           = "60",
            //             GrossVolumnUnitType = "MTQ",
            //             CommodityCode         = "120922",       // typeCode
            //               Description  = "Clove Seeds",
            //                GrossWeightUnitType = "KGM",
            //            ContainerSeals = new List<ContainerSeals>
            //            {
            //                new ContainerSeals
            //                {
            //                    Serial    = "SEAL12345",
            //                    Condition = "CA"               // sealingPartyRoleCode
            //                }
            //            }
            //            }

            //        }
            //    }
            //};

            //var cascare = new UCRMTS.dll.Models.CuscarInterchange();

            //var result = await MTSRequests.BOL(bolInformation);
            //if (result)
            //{
            //    MessageBox.Show("BOL information sent successfully!");
            //}

            var cascare = new UCRMTS.dll.Models.CuscarInterchange();

            // we will do mappings
            cascare.Equipments = new List<UCRMTS.dll.Models.EquipmentGroup>();
            cascare.Consignments = new List<UCRMTS.dll.Models.Consignment>();
            cascare.Date = new UCRMTS.dll.Models.DtmSegment
            {
                Date = DateTime.Now,
                FormatQualifier = "203",
                Qualifier = "137"
            };
            cascare.TransportInformation = new UCRMTS.dll.Models.TransportInformation();
            cascare.TransportInformation.ArrivalDate = new UCRMTS.dll.Models.DtmSegment() {  Date =DateTime.Now};
            cascare.TransportInformation.Vessel = "VV"; // "VVV"
            
            var edi = new EDIForm(cascare);
            edi.ShowDialog();


        }

    }

}

