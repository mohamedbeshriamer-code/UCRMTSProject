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

                var booking = new BookingDetails
                {
                    IssuerTax = "204829305",
                    UCR = "5158724741006820013",
                    ShipperTaxCode = "515872474",
                    LoadingTime = DateTime.Now.Date,
                    PortOfLoadingCode = "EGALY",           // Alexandria, Egypt
                    PortOfDeschargeCode  = "TRIST",         // Istanbul, Turkey
                    UnLoadingTime = DateTime.Now.Date,
                    VesselImo = "9491848",
                    VesselTitle = "VIVIEN A",
                    TradingCountry = "EG",                 // Egypt (origin)
                    ShippingLineID = "TURKON",
                    ShippingLineCode = "TRKU",
                    FinalTradingCountryCode = "TR",        // Turkey (destination)
                    Details = new List<BookingDetailsItems>
                    {
                        new BookingDetailsItems
                        {
                            CommodityCode = "852580",       // Digital cameras / electronics
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

                MessageBox.Show(ex.Message, "message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

      
    }
}
