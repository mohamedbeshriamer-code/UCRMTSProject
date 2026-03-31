namespace UCRMTS.dll.Forms
{
    partial class EditView
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnUpload = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSendMTS = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.DepartureDatepicker = new System.Windows.Forms.DateTimePicker();
            this.ArrivelDatePicker = new System.Windows.Forms.DateTimePicker();
            this.txtPod = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPortOfReceiptCode = new System.Windows.Forms.TextBox();
            this.txtSender = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPortOfRecipt = new System.Windows.Forms.TextBox();
            this.txtCarrierCode = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtPodCode = new System.Windows.Forms.TextBox();
            this.txtVessel = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtPolCode = new System.Windows.Forms.TextBox();
            this.txtReciver = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtCarrierId = new System.Windows.Forms.TextBox();
            this.txtPolName = new System.Windows.Forms.TextBox();
            this.txtImo = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtVoage = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTradeCountry = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtDate = new System.Windows.Forms.TextBox();
            this.flowPanelControl = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gridContainers = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridContainers)).BeginInit();
            this.SuspendLayout();
            // 
            // btnUpload
            // 
            this.btnUpload.Location = new System.Drawing.Point(3, 7);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(204, 30);
            this.btnUpload.TabIndex = 0;
            this.btnUpload.Text = "Convert";
            this.btnUpload.UseVisualStyleBackColor = true;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnSendMTS);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.btnUpload);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1242, 45);
            this.panel1.TabIndex = 1;
            // 
            // btnSendMTS
            // 
            this.btnSendMTS.Location = new System.Drawing.Point(423, 6);
            this.btnSendMTS.Name = "btnSendMTS";
            this.btnSendMTS.Size = new System.Drawing.Size(204, 33);
            this.btnSendMTS.TabIndex = 2;
            this.btnSendMTS.Text = "SendMTS";
            this.btnSendMTS.UseVisualStyleBackColor = true;
            this.btnSendMTS.Click += new System.EventHandler(this.btnSendMTS_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(213, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(204, 33);
            this.button1.TabIndex = 1;
            this.button1.Text = "Generate EDI Cascare 95 B";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Controls.Add(this.flowPanelControl);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 45);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1242, 850);
            this.panel2.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.DepartureDatepicker);
            this.groupBox2.Controls.Add(this.ArrivelDatePicker);
            this.groupBox2.Controls.Add(this.txtPod);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txtPortOfReceiptCode);
            this.groupBox2.Controls.Add(this.txtSender);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtPortOfRecipt);
            this.groupBox2.Controls.Add(this.txtCarrierCode);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtPodCode);
            this.groupBox2.Controls.Add(this.txtVessel);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.txtPolCode);
            this.groupBox2.Controls.Add(this.txtReciver);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.txtCarrierId);
            this.groupBox2.Controls.Add(this.txtPolName);
            this.groupBox2.Controls.Add(this.txtImo);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtVoage);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtTradeCountry);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.txtDate);
            this.groupBox2.Location = new System.Drawing.Point(15, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1221, 175);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Basic information";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(901, 47);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(86, 13);
            this.label17.TabIndex = 22;
            this.label17.Text = "Departure Date :";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(919, 16);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(68, 13);
            this.label16.TabIndex = 21;
            this.label16.Text = "Arrivel Date :";
            // 
            // DepartureDatepicker
            // 
            this.DepartureDatepicker.Location = new System.Drawing.Point(987, 44);
            this.DepartureDatepicker.Name = "DepartureDatepicker";
            this.DepartureDatepicker.Size = new System.Drawing.Size(200, 20);
            this.DepartureDatepicker.TabIndex = 20;
            // 
            // ArrivelDatePicker
            // 
            this.ArrivelDatePicker.Location = new System.Drawing.Point(987, 12);
            this.ArrivelDatePicker.Name = "ArrivelDatePicker";
            this.ArrivelDatePicker.Size = new System.Drawing.Size(200, 20);
            this.ArrivelDatePicker.TabIndex = 19;
            // 
            // txtPod
            // 
            this.txtPod.Location = new System.Drawing.Point(698, 113);
            this.txtPod.Name = "txtPod";
            this.txtPod.ReadOnly = true;
            this.txtPod.Size = new System.Drawing.Size(222, 20);
            this.txtPod.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "SenderID :";
            // 
            // txtPortOfReceiptCode
            // 
            this.txtPortOfReceiptCode.Location = new System.Drawing.Point(748, 87);
            this.txtPortOfReceiptCode.Name = "txtPortOfReceiptCode";
            this.txtPortOfReceiptCode.ReadOnly = true;
            this.txtPortOfReceiptCode.Size = new System.Drawing.Size(222, 20);
            this.txtPortOfReceiptCode.TabIndex = 18;
            // 
            // txtSender
            // 
            this.txtSender.Location = new System.Drawing.Point(79, 19);
            this.txtSender.Name = "txtSender";
            this.txtSender.ReadOnly = true;
            this.txtSender.Size = new System.Drawing.Size(222, 20);
            this.txtSender.TabIndex = 2;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(622, 90);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(120, 13);
            this.label15.TabIndex = 17;
            this.label15.Text = "Port Of Receipt Code   :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(314, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "CarrierCode :";
            // 
            // txtPortOfRecipt
            // 
            this.txtPortOfRecipt.Location = new System.Drawing.Point(394, 91);
            this.txtPortOfRecipt.Name = "txtPortOfRecipt";
            this.txtPortOfRecipt.ReadOnly = true;
            this.txtPortOfRecipt.Size = new System.Drawing.Size(222, 20);
            this.txtPortOfRecipt.TabIndex = 16;
            // 
            // txtCarrierCode
            // 
            this.txtCarrierCode.Location = new System.Drawing.Point(394, 19);
            this.txtCarrierCode.Name = "txtCarrierCode";
            this.txtCarrierCode.ReadOnly = true;
            this.txtCarrierCode.Size = new System.Drawing.Size(222, 20);
            this.txtCarrierCode.TabIndex = 2;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(307, 90);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(89, 13);
            this.label14.TabIndex = 15;
            this.label14.Text = "Port Of Receipt  :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(622, 19);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "Vessel :";
            // 
            // txtPodCode
            // 
            this.txtPodCode.Location = new System.Drawing.Point(79, 87);
            this.txtPodCode.Name = "txtPodCode";
            this.txtPodCode.ReadOnly = true;
            this.txtPodCode.Size = new System.Drawing.Size(222, 20);
            this.txtPodCode.TabIndex = 14;
            // 
            // txtVessel
            // 
            this.txtVessel.Enabled = false;
            this.txtVessel.Location = new System.Drawing.Point(672, 12);
            this.txtVessel.Name = "txtVessel";
            this.txtVessel.ReadOnly = true;
            this.txtVessel.Size = new System.Drawing.Size(222, 20);
            this.txtVessel.TabIndex = 2;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 94);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(67, 13);
            this.label13.TabIndex = 13;
            this.label13.Text = "POD  Code :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "ReciverID :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(314, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Carrier ID :";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(622, 116);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(70, 13);
            this.label10.TabIndex = 11;
            this.label10.Text = "POD  Name :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(622, 44);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(30, 13);
            this.label8.TabIndex = 3;
            this.label8.Text = "Imo :";
            // 
            // txtPolCode
            // 
            this.txtPolCode.Location = new System.Drawing.Point(394, 113);
            this.txtPolCode.Name = "txtPolCode";
            this.txtPolCode.ReadOnly = true;
            this.txtPolCode.Size = new System.Drawing.Size(222, 20);
            this.txtPolCode.TabIndex = 10;
            // 
            // txtReciver
            // 
            this.txtReciver.Location = new System.Drawing.Point(79, 41);
            this.txtReciver.Name = "txtReciver";
            this.txtReciver.ReadOnly = true;
            this.txtReciver.Size = new System.Drawing.Size(222, 20);
            this.txtReciver.TabIndex = 4;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(309, 116);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(62, 13);
            this.label11.TabIndex = 9;
            this.label11.Text = "POL Code :";
            // 
            // txtCarrierId
            // 
            this.txtCarrierId.Location = new System.Drawing.Point(394, 44);
            this.txtCarrierId.Name = "txtCarrierId";
            this.txtCarrierId.ReadOnly = true;
            this.txtCarrierId.Size = new System.Drawing.Size(222, 20);
            this.txtCarrierId.TabIndex = 4;
            // 
            // txtPolName
            // 
            this.txtPolName.Location = new System.Drawing.Point(80, 113);
            this.txtPolName.Name = "txtPolName";
            this.txtPolName.ReadOnly = true;
            this.txtPolName.Size = new System.Drawing.Size(222, 20);
            this.txtPolName.TabIndex = 8;
            // 
            // txtImo
            // 
            this.txtImo.Location = new System.Drawing.Point(672, 41);
            this.txtImo.Name = "txtImo";
            this.txtImo.ReadOnly = true;
            this.txtImo.Size = new System.Drawing.Size(222, 20);
            this.txtImo.TabIndex = 4;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(9, 118);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(65, 13);
            this.label12.TabIndex = 7;
            this.label12.Text = "POL Name :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Date :";
            // 
            // txtVoage
            // 
            this.txtVoage.Location = new System.Drawing.Point(672, 64);
            this.txtVoage.Name = "txtVoage";
            this.txtVoage.ReadOnly = true;
            this.txtVoage.Size = new System.Drawing.Size(222, 20);
            this.txtVoage.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(308, 67);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Trade Country :";
            // 
            // txtTradeCountry
            // 
            this.txtTradeCountry.Location = new System.Drawing.Point(394, 67);
            this.txtTradeCountry.Name = "txtTradeCountry";
            this.txtTradeCountry.ReadOnly = true;
            this.txtTradeCountry.Size = new System.Drawing.Size(222, 20);
            this.txtTradeCountry.TabIndex = 6;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(622, 67);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(44, 13);
            this.label9.TabIndex = 5;
            this.label9.Text = "Voage :";
            // 
            // txtDate
            // 
            this.txtDate.Location = new System.Drawing.Point(79, 64);
            this.txtDate.Name = "txtDate";
            this.txtDate.ReadOnly = true;
            this.txtDate.Size = new System.Drawing.Size(222, 20);
            this.txtDate.TabIndex = 6;
            // 
            // flowPanelControl
            // 
            this.flowPanelControl.AutoScroll = true;
            this.flowPanelControl.Location = new System.Drawing.Point(15, 512);
            this.flowPanelControl.Name = "flowPanelControl";
            this.flowPanelControl.Size = new System.Drawing.Size(1197, 317);
            this.flowPanelControl.TabIndex = 19;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.gridContainers);
            this.groupBox1.Location = new System.Drawing.Point(9, 187);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(10);
            this.groupBox1.Size = new System.Drawing.Size(1221, 302);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Containers";
            // 
            // gridContainers
            // 
            this.gridContainers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridContainers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridContainers.Location = new System.Drawing.Point(10, 23);
            this.gridContainers.Name = "gridContainers";
            this.gridContainers.Size = new System.Drawing.Size(1201, 269);
            this.gridContainers.TabIndex = 0;
            // 
            // EditView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1242, 895);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EditView";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridContainers)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView gridContainers;
        private System.Windows.Forms.TextBox txtSender;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtVoage;
        private System.Windows.Forms.TextBox txtTradeCountry;
        private System.Windows.Forms.TextBox txtDate;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtImo;
        private System.Windows.Forms.TextBox txtCarrierId;
        private System.Windows.Forms.TextBox txtReciver;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtVessel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtCarrierCode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPortOfRecipt;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtPodCode;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtPod;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtPolCode;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtPolName;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtPortOfReceiptCode;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.FlowLayoutPanel flowPanelControl;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnSendMTS;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.DateTimePicker DepartureDatepicker;
        private System.Windows.Forms.DateTimePicker ArrivelDatePicker;
    }
}