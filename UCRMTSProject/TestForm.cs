using Newtonsoft.Json;
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
using static UCRMTS.dll.MTSRequests;

namespace UCRMTSProject
{
    public partial class TestForm : Form
    {
        public TestForm()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var result = await UCRMTS.dll.MTSRequests.UCRVerification( "5158724741006820013", "515872474");
                string data = JsonConvert.SerializeObject(result, Formatting.Indented);
                txtResult.Text = data;
                MessageBox.Show("Success");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        

        }

        private async void button2_Click(object sender, EventArgs e)
        {

            try
            {


                var baseTime = DateTime.UtcNow;

                var booking = new BookingDetails
                {
                    IssuerTax = "204829305",
                    UCR = "5158724741006820013",
                    ShipperTaxCode = "515872474",

                    LoadingTime = baseTime.AddDays(2),
                    DepatureTime = baseTime.AddDays(3),
                    ArrivalTime = baseTime.AddDays(5),
                    UnLoadingTime = baseTime.AddDays(6),

                    PortOfLoadingCode = "EGALY",
                    PortOfDeschargeCode = "TRIST",

                    VesselImo = "9491848",
                    VesselTitle = "VIVIEN A",
                    TradingCountry = "EG",
                    ShippingLineID = "TURKON",
                    ShippingLineCode = "TRKU",
                    FinalTradingCountryCode = "TR",

                    TranspoContractReferencedDocument = "CONTRACT12345",

                    Details = new List<BookingDetailsItems>
                    {
                        new BookingDetailsItems
                        {
                            CommodityCode = "852580",
                            NoOfPackages = 10,
                            GrossWieght = 1500.5m,
                            MeasurmentID = "KGM",
                            CargoDescription = "Electronics",
                            ContainerType = "20FT",
                            Nos = 2
                        }
                    }
                };

                var result = await UCRMTS.dll.MTSRequests.ConfirmOrCancelBooking(booking, UCRMTS.dll.MTSRequests.BookingStatus.Confirm);


                string data = JsonConvert.SerializeObject(result);
                txtResult.Text = data;

            }
            catch (Exception ex)
            {

                txtErrors.Text = ex.Message;
            }
        }

        private async void button3_Click(object sender, EventArgs e)
        {

            try
            {
                var mockEmptyContainerRequest = new EmptyContainerRequest
                {
                    UCR = "5158724741006820013",
                    IssuedDatetime = DateTime.UtcNow,

                    IssuerID = "204829305",        //
                    ReciverID = "515872474",
                    POL = "EGALY",
                    POD = "TRIST",
                    POLEvent = DateTime.UtcNow.AddDays(10),
                    PODEvent = DateTime.UtcNow.AddDays(10).AddDays(10),
                    TransportContractReferencedDocument = "CONTRACT12345",
                    ShippingOrderNumber = "SO-2024-00123",
                    TradingCountryIsoCode = "EG",
                    ContainerDetails = new List<EmptyContainerDetails>
                {
                        new EmptyContainerDetails
                        {
                            ContainerNumber       = "TCKU3456789",
                            ContainerType         = "22G1",   // 20ft General Purpose
                            TareWeight            = "2200",
                            TareWeightType        = "KGM",    // kilograms
                            GrossWeight           = "2200",   // empty = gross equals tare
                            GrossWeightType       = "KGM",
                            UsedCapacityCode      = "1",      // Empty
                            OperationalStatusCode = "3",      // Released
                            ContainerSeals = new List<ContainerSeal>
                            {
                                new ContainerSeal
                                {
                                    Serial        = "SEAL001234",
                                    ConditionCode = "1",   // Ok
                                    RoleCode      = "SH"  // Shipper
                                }
                            }
                        },
                    new EmptyContainerDetails
                    {
                        ContainerNumber       = "MSCU7654321",
                        ContainerType         = "42G1",   // 40ft General Purpose
                        TareWeight            = "3800",
                        TareWeightType        = "KGM",
                        GrossWeight           = "3800",
                        GrossWeightType       = "KGM",
                        UsedCapacityCode      = "1",      // Empty
                        OperationalStatusCode = "3",      // Released
                        ContainerSeals = new List<ContainerSeal>
                        {
                            new ContainerSeal
                            {
                                Serial        = "SEAL005678",
                                ConditionCode = "1",
                                RoleCode      = "SH"
                            },
                            new ContainerSeal
                            {
                                Serial        = "SEAL005679",  // second seal on 40ft
                                ConditionCode = "1",
                                RoleCode      = "CA"           // Carrier
                            }
                        }
                    }
                }
                };



                var result = await UCRMTS.dll.MTSRequests.AddingEmptyContainer(mockEmptyContainerRequest);
                txtResult.Text = JsonConvert.SerializeObject(result, Formatting.Indented);
            }
            catch (Exception ex)
            {

                txtErrors.Text = ex.Message;
               
            }
         


        }

        private async void button4_Click(object sender, EventArgs e)
        {


            try
            {
                var mockBolInformation = new BolInformation
                {
                    IssuerID = "204829305",
                    UCR = "5158724741006820013",
                    ShipperTaxID = "515872474",
                    ShippingLineCode = "MSC",
                    CarrierID = "MSCEGYPT01",
                    CarrierName = "Mediterranean Shipping Company",
                    ConsgineeTaxCode = "444555666",
                    ConsgineeName = "Istanbul Trade Co.",
                    ConsigneeCity = "Istanbul",
                    ConsigneeCountryCode = "TR",
                    PortOfLoadingCode = "EGALY",
                    PortOfLoadingName = "Alexandria",
                    PortOfDischargeCode = "TRIST",
                    PortOfDischargeName = "Istanbul",
                    VesselImo = "9234567",
                    VesselTitle = "MSC ALLEGRA",
                    TotalGrossWeight = "24000",
                    FinalDestinationCountry = "TR",
                    TotalQuantity = "2",
                    ExporterTradCountry = "EG",
                    TotalCBM = "67.50",
                    UnitTypeOfCBM = "MTQ",       // cubic metres UN/ECE rec 20
                    BolNumber = "MSCEGY2024001",
                    BolType = BolType.Draft,
                    ETA = DateTime.UtcNow.AddDays(10),
                    ATA = DateTime.UtcNow.AddDays(10).AddDays(1), // ATA always after ETA
                  GrossWeights = new List<GrossWeightBOL>
                        {
                            new GrossWeightBOL
                            {
                                TotalGrossWeight    = "24000",
                                UnitTypeGrossWeight = "KGM"
                            }
                        },

                                        GrossVolumn = new List<GrossVolumnBOL>
                        {
                            new GrossVolumnBOL
                            {
                                Value    = "67.50",
                                UnitCode = "MTQ"
                            }
                        },

                                        ShippingOrderInformation = new List<ShippingOrderInformation>
                        {
                            new ShippingOrderInformation
                            {
                                Sequance            = 1,
                                CargoDescription    = "COTTON FABRICS",
                                NOS                 = "200",
                                Title               = "ROLLS OF COTTON FABRIC",
                                PackageNumber       = "200",
                                PackageType         = "RL",      // Reel/Roll
                                GrossWeight         = "12000",
                                GrossWeightUnitType = "KGM",
                                GrossVolumn         = "33.75",
                                GrossVolumnUnitType = "MTQ",
                                CommodityCode       = "520811"   // HS code - Woven cotton fabrics
                            },
                            new ShippingOrderInformation
                            {
                                Sequance            = 2,
                                CargoDescription    = "CERAMIC TILES",
                                NOS                 = "500",
                                Title               = "BOXES OF CERAMIC TILES",
                                PackageNumber       = "500",
                                PackageType         = "BX",      // Box
                                GrossWeight         = "12000",
                                GrossWeightUnitType = "KGM",
                                GrossVolumn         = "33.75",
                                GrossVolumnUnitType = "MTQ",
                                CommodityCode       = "690721"   // HS code - Ceramic tiles
                            }
                        },

                                        ContainerInformation = new List<ContainerInformation>
                        {
                            new ContainerInformation
                            {
                                ContainerNo          = "TCKU3456789",
                                ContainerType        = "22G1",       // 20ft General Purpose
                                Description          = "COTTON FABRICS",
                                GrossWeight          = "12000",
                                UnitTypeOfGrossWeight = "KGM",
                                GrossWeightUnitType  = "KGM",
                                GrossVolumn          = "33.75",
                                GrossVolumnUnitType  = "MTQ",
                                CommodityCode        = "520811",
                                ContainerSeals = new List<ContainerSeals>
                                {
                                    new ContainerSeals
                                    {
                                        Serial    = "SEAL001234",
                                        Condition = "1"            // Ok
                                    }
                                }
                            },
                            new ContainerInformation
                            {
                                ContainerNo          = "MSCU7654321",
                                ContainerType        = "42G1",       // 40ft General Purpose
                                Description          = "CERAMIC TILES",
                                GrossWeight          = "12000",
                                UnitTypeOfGrossWeight = "KGM",
                                GrossWeightUnitType  = "KGM",
                                GrossVolumn          = "33.75",
                                GrossVolumnUnitType  = "MTQ",
                                CommodityCode        = "690721",
                                ContainerSeals = new List<ContainerSeals>
                                {
                                    new ContainerSeals
                                    {
                                        Serial    = "SEAL005678",
                                        Condition = "1"
                                    },
                                    new ContainerSeals
                                    {
                                        Serial    = "SEAL005679",
                                        Condition = "1"
                                    }
                                }
                            }
                        }
                                    };

                var result = await UCRMTS.dll.MTSRequests.BOL(mockBolInformation);
                txtResult.Text =result.ToString();



            }
            catch (Exception ex)
            {

                txtErrors.Text = ex.Message;

            }
        }
    }
}
