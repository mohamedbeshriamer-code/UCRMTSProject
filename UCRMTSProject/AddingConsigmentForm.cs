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
                

                BolType = BolType.Final,


                UCR = "3742795351004720042",
                CarrierID = "YML",
                CarrierName = "YANG MING",
                ShipperTaxID = "CON123456",
                BolNumber = "MAEU123456789",


                ConsgineeName = "XYZ IMPORTS BV",
                ConsigneeCity = "Rotterdam",
                ConsigneeCountryCode = "NL",
                ConsgineeTaxCode = "",


                PortOfLoadingCode = "EGEDK",
                PortOfLoadingName = "El Dekheila Port, Egypt",
                PortOfDischargeCode = "NLRTM",
                PortOfDischargeName = "Rotterdam, Netherlands",


                VesselImo = "9270476",
                VesselTitle = "XIN XIA MEN",


                TotalGrossWeight = "25000",
                TotalCBM = "55",
                UnitTypeOfCBM = "MTQ",
                TotalQuantity = "100",


                FinalDestinationCountry = "NL",
                ExporterTradCountry = "EG",


                ETA = DateTime.Parse("2024-10-15T08:00:00Z"),
                ATA = DateTime.Parse("2024-10-01T12:00:00Z"), // departureEvent actualOccurrenceDateTime


                GrossWeights = new List<GrossWeightBOL>
                {
                    new GrossWeightBOL
                    {
                        TotalGrossWeight    = "25000",
                        UnitTypeGrossWeight = "KGM"
                    }
                },
                GrossVolumn = new List<GrossVolumnBOL>()
                {
                    new GrossVolumnBOL()
                    {
                        UnitCode = "MTQ",
                        Value = "55"
                    }
                }
                ,




                ShippingOrderInformation = new List<ShippingOrderInformation>
                    {
                        new ShippingOrderInformation
                        {
                            Sequance         = 1,
                            CargoDescription = "Clove Seeds",
                            NOS              = "120922",       // typeCode
                            Title            = "1 X 20DC DRY CARGO CONTAINER", // physicalLogisticsShippingMarks
                            PackageNumber    = "50",           // transportLogisticsPackage.itemQuantity
                            PackageType      = "TV"            // transportLogisticsPackage.typeCode,
                            ,
                            CommodityCode = "120922",
                            GrossVolumn = "55",
                            GrossVolumnUnitType = "MTQ",
                             GrossWeight = "25000",
                             GrossWeightUnitType = "KGM",
                            

                        }
                    },

                // Container — from utilizedLogisticsTransportEquipment
                ContainerInformation = new List<ContainerInformation>
                {
                {
                    new ContainerInformation
                    {
                        ContainerNo           = "MSCU7654321",
                        ContainerType         = "22G1",        // characteristicCode
                        GrossWeight           = "28000",
                        UnitTypeOfGrossWeight = "KGM",
                         GrossVolumn           = "60",
                         GrossVolumnUnitType = "MTQ",
                         CommodityCode         = "120922",       // typeCode
                           Description  = "Clove Seeds",
                            GrossWeightUnitType = "KGM",
                        ContainerSeals = new List<ContainerSeals>
                        {
                            new ContainerSeals
                            {
                                Serial    = "SEAL12345",
                                Condition = "CA"               // sealingPartyRoleCode
                            }
                        }
                        }
                   
                    }
                }
            };


            var result = await MTSRequests.BOL(bolInformation);
            if (result)
            {
                MessageBox.Show("BOL information sent successfully!");
            }
            

        }

    }

}

