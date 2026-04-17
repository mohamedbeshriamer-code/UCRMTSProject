using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UCRMTS.dll;
using UCRMTS.dll.Form;
using UCRMTS.dll.Models;

namespace UCRMTS.dll.Forms
{
    public partial class EditView : System.Windows.Forms.Form
    {
        CuscarInterchange data;
        public EditView()
        {
            InitializeComponent();
            gridContainers.ReadOnly = true;
        }

        public EditView(CuscarInterchange cuscar)
        {
            InitializeComponent();
            this.data = cuscar;
            this.btnUpload.Enabled = false;
            this.SeedData();
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    EDIService eDIService = new EDIService();
                    var file = File.ReadAllText(ofd.FileName);
                    data = eDIService.Deserialize(file);
                    var x = JsonConvert.SerializeObject(data);
                    gridContainers.DataSource = data.Equipments.ToList();
                    txtSender.Text = data.SenderId;
                    txtReciver.Text = data.ReciverID;
                    txtDate.Text = data.Date.Date.ToString("yyyy/MM/dd");
                    txtPodCode.Text = data?.TransportInformation.PortOfDischarge?.LocationCode;
                    txtCarrierCode.Text = data?.TransportInformation?.CarrierCode;
                    txtCarrierId.Text = data?.TransportInformation?.CarrierID;
                    txtTradeCountry.Text = data?.TransportInformation?.TradeCountry;
                    txtVessel.Text = data?.TransportInformation?.Vessel;
                    txtImo.Text = data?.TransportInformation?.IMO;
                    txtVoage.Text = data?.TransportInformation?.Voage;
                    txtPortOfReceiptCode.Text = data?.TransportInformation.PortOfReceipt?.LocationName;
                    txtPolName.Text = data?.TransportInformation.PortOfLoading?.LocationName;
                    txtPolCode.Text = data?.TransportInformation.PortOfLoading?.LocationCode;
                    txtPod.Text = data?.TransportInformation.PortOfDischarge?.LocationName;
                    if(data.TransportInformation.ArrivalDate != null)
                    {
                        ArrivelDatePicker.Value = data.TransportInformation.ArrivalDate.Date;
                    }
                
                    if(data.TransportInformation.DepartureDate != null)
                    {
                        DepartureDatepicker.Value = data.TransportInformation.DepartureDate.Date;
                    }
                  


                    foreach (var item in data.Consignments)
                    {
                        ConsigmentGridView consigmentGridView = new ConsigmentGridView(item);
                        consigmentGridView.GoodsItemRemoved += (ob, args) =>
                        {
                            var selected = data.Consignments.FirstOrDefault(a => a.BillOfLadingNumber == args.BillOfLading);
                            this.data.Consignments.Remove(selected);

                            flowPanelControl.Controls.Remove((ConsigmentGridView)ob);


                        };
                        flowPanelControl.Controls.Add(consigmentGridView);
                    }








                }
            }
        }
        private void SeedData()
        {
            try
            {

           
            gridContainers.DataSource = data.Equipments.ToList();
            txtSender.Text = data.SenderId;
            txtReciver.Text = data.ReciverID;
            txtDate.Text = data.Date.Date.ToString("yyyy/MM/dd");
            txtPodCode.Text = data?.TransportInformation.PortOfDischarge?.LocationCode;
            txtCarrierCode.Text = data?.TransportInformation?.CarrierCode;
            txtCarrierId.Text = data?.TransportInformation?.CarrierID;
            txtTradeCountry.Text = data?.TransportInformation?.TradeCountry;
            txtVessel.Text = data?.TransportInformation?.Vessel;
            txtImo.Text = data?.TransportInformation?.IMO;
            txtVoage.Text = data?.TransportInformation?.Voage;
            txtPortOfReceiptCode.Text = data?.TransportInformation.PortOfReceipt?.LocationName;
            txtPolName.Text = data?.TransportInformation.PortOfLoading?.LocationName;
            txtPolCode.Text = data?.TransportInformation.PortOfLoading?.LocationCode;
            txtPod.Text = data?.TransportInformation.PortOfDischarge?.LocationName;
            ArrivelDatePicker.Value = data.TransportInformation.ArrivalDate.Date;
            if (data.TransportInformation.DepartureDate != null)
            {
                DepartureDatepicker.Value = data.TransportInformation.DepartureDate.Date;
            }



            foreach (var item in data.Consignments)
            {
                ConsigmentGridView consigmentGridView = new ConsigmentGridView(item);
                consigmentGridView.GoodsItemRemoved += (ob, args) =>
                {
                    var selected = data.Consignments.FirstOrDefault(a => a.BillOfLadingNumber == args.BillOfLading);
                    this.data.Consignments.Remove(selected);

                    flowPanelControl.Controls.Remove((ConsigmentGridView)ob);


                };
                flowPanelControl.Controls.Add(consigmentGridView);
            }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message ,"Error Getting data" , MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            EDIService eDIService = new EDIService();
            string file = eDIService.Selialize(data);
            ProcessData();
            ProccessUCRS();
            ProcessHeaderData();
            using (SaveFileDialog fileDialog = new SaveFileDialog())
            {
                fileDialog.Filter = "EDI files (*.edi)|*.edi";
                fileDialog.DefaultExt = "edi";
                fileDialog.AddExtension = true;
                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    eDIService.Selialize(fileDialog.FileName, data);
                    MessageBox.Show("The File Save","Save Data",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
            }


             
        }

        private void ProccessUCRS()
        {
            foreach (Control item in flowPanelControl.Controls)
            {
               if(item is ConsigmentGridView)
                {

                 var consigment =   data.Consignments.FirstOrDefault(a => a.BillOfLadingNumber == (item as ConsigmentGridView).BillOfLadingNumber);
                    if (consigment != null)
                    {
                        if(consigment.References == null)
                        {
                            consigment.References = new List<Reference>();
                        }
                       var afm =  consigment.References.FirstOrDefault(a => a.Qualifier == "AFM");
                        if(afm != null)
                        {
                            afm.Number =(item as ConsigmentGridView).UCR;
                        }
                        else
                        {

                            consigment.References.Add(new Reference()
                            {
                                Number = (item as ConsigmentGridView).UCR,
                                Qualifier = "AFM"
                            });
                        }

                        var bn = consigment.References.FirstOrDefault(a => a.Qualifier == "BN");
                        if(bn != null)
                        {
                            bn.Number = (item as ConsigmentGridView).BookingReference;
                        }
                        else
                        {
                            consigment.References.Add(new Reference()
                            {
                                Number = (item as ConsigmentGridView).BookingReference,
                                Qualifier = "BN"
                            });
                        }


                           
                    }

                }
            }
        }
        private void ProcessData()
        {
            foreach (Control item in flowPanelControl.Controls)
            {
                if (item is ConsigmentGridView)
                {

                    var consigment = data.Consignments.FirstOrDefault(a => a.BillOfLadingNumber == (item as ConsigmentGridView).BillOfLadingNumber);
                    consigment.BookingDate = new DtmSegment()
                    {
                         Date = (item as ConsigmentGridView).BookingDate,
                         FormatQualifier = "201",
                         Qualifier = "95"
                    };

                    consigment.BillOfLadingDate = new DtmSegment()
                    {
                        Date = (item as ConsigmentGridView).BookingDate,
                        FormatQualifier = "201",
                        Qualifier = "179"
                    };

                }
            }
        }

        private void ProcessHeaderData()
        {
       
                if(data.TransportInformation.ArrivalDate == null)
                {
                    data.TransportInformation.ArrivalDate = new DtmSegment();
                }

                if (data.TransportInformation.DepartureDate == null)
                {
                    data.TransportInformation.DepartureDate = new DtmSegment()
                    {
                        Date = DepartureDatepicker.Value,
                        FormatQualifier = "102",
                        Qualifier = "133"
                    };
                }
         
            data.TransportInformation.ArrivalDate.FormatQualifier = "102";
            


            data.TransportInformation.PortOfDeparture = new LocationSegment()
            {
                LocationCode = data.TransportInformation.PortOfLoading.LocationCode,
                LocationName = data.TransportInformation.PortOfLoading.LocationName,
                Qualifier = "5",
                
            };
        }

        private async void btnSendMTS_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog fileDialog = new OpenFileDialog())
                {
                    if (fileDialog.ShowDialog() == DialogResult.OK)
                    {
                        var result = await MTSRequests.UploadMainfest(fileDialog.FileName);
                        if (result)
                        {
                            MessageBox.Show("Mainfest Uploaded to MTS Correctly", "Successful Operation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }

                }
            }
            catch (HttpRequestException ex)
            {

                MessageBox.Show(ex.Message,"Error" ,MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
           
        }
    }
}
