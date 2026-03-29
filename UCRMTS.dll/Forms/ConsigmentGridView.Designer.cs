namespace UCRMTS.dll.Form
{
    partial class ConsigmentGridView
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txtBillOfLadingNumber = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPortOfLoading = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPortOd = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtUcr = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtAcID = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.txtBookingReference = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.billOfLadingDatePicker = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.bookingDatePicker = new System.Windows.Forms.DateTimePicker();
            this.btnRemove = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(71, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Bill Of Lading Number";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(61, 99);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1044, 258);
            this.dataGridView1.TabIndex = 1;
            // 
            // txtBillOfLadingNumber
            // 
            this.txtBillOfLadingNumber.Location = new System.Drawing.Point(186, 14);
            this.txtBillOfLadingNumber.Name = "txtBillOfLadingNumber";
            this.txtBillOfLadingNumber.Size = new System.Drawing.Size(169, 20);
            this.txtBillOfLadingNumber.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(361, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Port Loading";
            // 
            // txtPortOfLoading
            // 
            this.txtPortOfLoading.Location = new System.Drawing.Point(434, 14);
            this.txtPortOfLoading.Name = "txtPortOfLoading";
            this.txtPortOfLoading.Size = new System.Drawing.Size(169, 20);
            this.txtPortOfLoading.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(84, 44);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Port Of Discharge";
            // 
            // txtPortOd
            // 
            this.txtPortOd.Location = new System.Drawing.Point(185, 40);
            this.txtPortOd.Name = "txtPortOd";
            this.txtPortOd.Size = new System.Drawing.Size(169, 20);
            this.txtPortOd.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(398, 43);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "UCR";
            // 
            // txtUcr
            // 
            this.txtUcr.Location = new System.Drawing.Point(434, 41);
            this.txtUcr.Name = "txtUcr";
            this.txtUcr.Size = new System.Drawing.Size(169, 20);
            this.txtUcr.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(609, 17);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "ACID";
            // 
            // txtAcID
            // 
            this.txtAcID.Location = new System.Drawing.Point(647, 14);
            this.txtAcID.Name = "txtAcID";
            this.txtAcID.Size = new System.Drawing.Size(169, 20);
            this.txtAcID.TabIndex = 10;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnRemove);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.txtBookingReference);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.billOfLadingDatePicker);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.bookingDatePicker);
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Controls.Add(this.txtAcID);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.txtBillOfLadingNumber);
            this.panel2.Controls.Add(this.txtUcr);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.txtPortOfLoading);
            this.panel2.Controls.Add(this.txtPortOd);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1146, 384);
            this.panel2.TabIndex = 11;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(822, 13);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(99, 13);
            this.label10.TabIndex = 16;
            this.label10.Text = "Booking Reference";
            // 
            // txtBookingReference
            // 
            this.txtBookingReference.Location = new System.Drawing.Point(927, 10);
            this.txtBookingReference.Name = "txtBookingReference";
            this.txtBookingReference.Size = new System.Drawing.Size(204, 20);
            this.txtBookingReference.TabIndex = 15;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(588, 72);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(99, 13);
            this.label9.TabIndex = 14;
            this.label9.Text = "Bill of Lading Date :";
            // 
            // billOfLadingDatePicker
            // 
            this.billOfLadingDatePicker.Location = new System.Drawing.Point(693, 66);
            this.billOfLadingDatePicker.Name = "billOfLadingDatePicker";
            this.billOfLadingDatePicker.Size = new System.Drawing.Size(200, 20);
            this.billOfLadingDatePicker.TabIndex = 13;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(609, 44);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(78, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "Booking Date :";
            // 
            // bookingDatePicker
            // 
            this.bookingDatePicker.Location = new System.Drawing.Point(693, 40);
            this.bookingDatePicker.Name = "bookingDatePicker";
            this.bookingDatePicker.Size = new System.Drawing.Size(200, 20);
            this.bookingDatePicker.TabIndex = 11;
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(3, 358);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 23);
            this.btnRemove.TabIndex = 17;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // ConsigmentGridView
            // 
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.panel2);
            this.Name = "ConsigmentGridView";
            this.Size = new System.Drawing.Size(1146, 384);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtBillOfLadingNumber;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPortOfLoading;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPortOd;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtUcr;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtAcID;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker billOfLadingDatePicker;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker bookingDatePicker;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtBookingReference;
        private System.Windows.Forms.Button btnRemove;
    }
}
