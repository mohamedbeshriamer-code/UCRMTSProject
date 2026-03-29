using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UCRMTS.dll.Models;

namespace UCRMTS.dll.Form
{
    public partial class ConsigmentGridView : UserControl
    {
        public delegate void GoodsItemRemovedEventHandler(object sender, GoodsItemRemovedEventArgs e);
        public event GoodsItemRemovedEventHandler GoodsItemRemoved;
        public string BillOfLadingNumber { get => txtBillOfLadingNumber.Text; }
        public string UCR { get => txtUcr.Text; }

        public string BookingReference { get => txtBookingReference.Text; }
        public DateTime BookingDate { get => bookingDatePicker.Value; }

        public DateTime BillOfLadingDate { get =>billOfLadingDatePicker.Value ; }
        public ConsigmentGridView(Consignment consignment)
        {
            InitializeComponent();
            txtAcID.Text = consignment.ACCID;
            txtBillOfLadingNumber.Text = consignment.BillOfLadingNumber;
            txtPortOd.Text = consignment.PortOfDischarge.PortCode;
            txtPortOfLoading.Text = consignment.PortOfLoading.PortCode;
         
            this.dataGridView1.DataSource = consignment.GoodsItems;
            
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            GoodsItemRemoved.Invoke(this, new GoodsItemRemovedEventArgs() { BillOfLading = BillOfLadingNumber });
        }
    }
    public class GoodsItemRemovedEventArgs : EventArgs
    {
        public string BillOfLading { get; set; }


    }
}
