namespace Rs232
{
    partial class frmModem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmModem));
            this.grpModemas = new System.Windows.Forms.GroupBox();
            this.lblInicializavimas = new System.Windows.Forms.Label();
            this.txtInicializavimas = new System.Windows.Forms.TextBox();
            this.cmbModelis = new System.Windows.Forms.ComboBox();
            this.cmbPortas = new System.Windows.Forms.ComboBox();
            this.lblModelis = new System.Windows.Forms.Label();
            this.lblPortas = new System.Windows.Forms.Label();
            this.grpKomandos = new System.Windows.Forms.GroupBox();
            this.txtAtsakymas = new System.Windows.Forms.TextBox();
            this.lblAtsakymas = new System.Windows.Forms.Label();
            this.lblKomandos = new System.Windows.Forms.Label();
            this.cmbKomandos = new System.Windows.Forms.ComboBox();
            this.statusOperation = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.SMSContent = new System.Windows.Forms.TextBox();
            this.SendSMS = new System.Windows.Forms.Button();
            this.SendNumber = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ATcommand = new System.Windows.Forms.TextBox();
            this.SendATcommand = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.grpModemas.SuspendLayout();
            this.grpKomandos.SuspendLayout();
            this.statusOperation.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpModemas
            // 
            this.grpModemas.Controls.Add(this.lblInicializavimas);
            this.grpModemas.Controls.Add(this.txtInicializavimas);
            this.grpModemas.Controls.Add(this.cmbModelis);
            this.grpModemas.Controls.Add(this.cmbPortas);
            this.grpModemas.Controls.Add(this.lblModelis);
            this.grpModemas.Controls.Add(this.lblPortas);
            this.grpModemas.ForeColor = System.Drawing.SystemColors.Desktop;
            this.grpModemas.Location = new System.Drawing.Point(12, 12);
            this.grpModemas.Name = "grpModemas";
            this.grpModemas.Size = new System.Drawing.Size(350, 110);
            this.grpModemas.TabIndex = 0;
            this.grpModemas.TabStop = false;
            this.grpModemas.Text = "Modem connection";
            // 
            // lblInicializavimas
            // 
            this.lblInicializavimas.AutoSize = true;
            this.lblInicializavimas.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblInicializavimas.Location = new System.Drawing.Point(237, 16);
            this.lblInicializavimas.Name = "lblInicializavimas";
            this.lblInicializavimas.Size = new System.Drawing.Size(61, 13);
            this.lblInicializavimas.TabIndex = 5;
            this.lblInicializavimas.Text = "Initialization";
            // 
            // txtInicializavimas
            // 
            this.txtInicializavimas.Location = new System.Drawing.Point(201, 33);
            this.txtInicializavimas.Multiline = true;
            this.txtInicializavimas.Name = "txtInicializavimas";
            this.txtInicializavimas.ReadOnly = true;
            this.txtInicializavimas.Size = new System.Drawing.Size(132, 71);
            this.txtInicializavimas.TabIndex = 4;
            // 
            // cmbModelis
            // 
            this.cmbModelis.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbModelis.FormattingEnabled = true;
            this.cmbModelis.Items.AddRange(new object[] {
            "Basic",
            "Model1",
            "Model2"});
            this.cmbModelis.Location = new System.Drawing.Point(86, 72);
            this.cmbModelis.Name = "cmbModelis";
            this.cmbModelis.Size = new System.Drawing.Size(95, 21);
            this.cmbModelis.TabIndex = 3;
            this.cmbModelis.SelectedIndexChanged += new System.EventHandler(this.cmbModelis_SelectedIndexChanged);
            // 
            // cmbPortas
            // 
            this.cmbPortas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPortas.FormattingEnabled = true;
            this.cmbPortas.Items.AddRange(new object[] {
            "COM1",
            "COM2",
            "COM3",
            "COM4",
            "COM5",
            "COM6",
            "COM7",
            "COM8"});
            this.cmbPortas.Location = new System.Drawing.Point(86, 33);
            this.cmbPortas.Name = "cmbPortas";
            this.cmbPortas.Size = new System.Drawing.Size(95, 21);
            this.cmbPortas.TabIndex = 2;
            // 
            // lblModelis
            // 
            this.lblModelis.AutoSize = true;
            this.lblModelis.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblModelis.Location = new System.Drawing.Point(6, 75);
            this.lblModelis.Name = "lblModelis";
            this.lblModelis.Size = new System.Drawing.Size(73, 13);
            this.lblModelis.TabIndex = 1;
            this.lblModelis.Text = "Modem model";
            // 
            // lblPortas
            // 
            this.lblPortas.AutoSize = true;
            this.lblPortas.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblPortas.Location = new System.Drawing.Point(6, 36);
            this.lblPortas.Name = "lblPortas";
            this.lblPortas.Size = new System.Drawing.Size(52, 13);
            this.lblPortas.TabIndex = 0;
            this.lblPortas.Text = "COM port";
            // 
            // grpKomandos
            // 
            this.grpKomandos.Controls.Add(this.txtAtsakymas);
            this.grpKomandos.Controls.Add(this.lblAtsakymas);
            this.grpKomandos.Controls.Add(this.lblKomandos);
            this.grpKomandos.Controls.Add(this.button2);
            this.grpKomandos.Controls.Add(this.cmbKomandos);
            this.grpKomandos.ForeColor = System.Drawing.SystemColors.Desktop;
            this.grpKomandos.Location = new System.Drawing.Point(12, 132);
            this.grpKomandos.Name = "grpKomandos";
            this.grpKomandos.Size = new System.Drawing.Size(350, 197);
            this.grpKomandos.TabIndex = 1;
            this.grpKomandos.TabStop = false;
            this.grpKomandos.Text = "Modem sample commands";
            // 
            // txtAtsakymas
            // 
            this.txtAtsakymas.Location = new System.Drawing.Point(77, 52);
            this.txtAtsakymas.Multiline = true;
            this.txtAtsakymas.Name = "txtAtsakymas";
            this.txtAtsakymas.ReadOnly = true;
            this.txtAtsakymas.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtAtsakymas.Size = new System.Drawing.Size(256, 137);
            this.txtAtsakymas.TabIndex = 3;
            // 
            // lblAtsakymas
            // 
            this.lblAtsakymas.AutoSize = true;
            this.lblAtsakymas.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblAtsakymas.Location = new System.Drawing.Point(14, 114);
            this.lblAtsakymas.Name = "lblAtsakymas";
            this.lblAtsakymas.Size = new System.Drawing.Size(42, 26);
            this.lblAtsakymas.TabIndex = 2;
            this.lblAtsakymas.Text = "Modem\r\nanswer";
            // 
            // lblKomandos
            // 
            this.lblKomandos.AutoSize = true;
            this.lblKomandos.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblKomandos.Location = new System.Drawing.Point(14, 23);
            this.lblKomandos.Name = "lblKomandos";
            this.lblKomandos.Size = new System.Drawing.Size(59, 13);
            this.lblKomandos.TabIndex = 1;
            this.lblKomandos.Text = "Commands";
            // 
            // cmbKomandos
            // 
            this.cmbKomandos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbKomandos.FormattingEnabled = true;
            this.cmbKomandos.Items.AddRange(new object[] {
            "Manufacturer",
            "ProductId",
            "SMS Center",
            "MSISDN",
            "IMEI",
            "IMSI",
            "SoftwareVersion",
            "READ_All_SMS",
            "SendSMS",
            "SetPDU_mode",
            "SetTEXT_mode",
            "Send_Ctrl+Z",
            "Send_Enter",
            "Delete_all_SIM_SMS",
            "Enable_Delivery",
            "Disable_Delivery",
            "Read_Config"});
            this.cmbKomandos.Location = new System.Drawing.Point(77, 20);
            this.cmbKomandos.Name = "cmbKomandos";
            this.cmbKomandos.Size = new System.Drawing.Size(118, 21);
            this.cmbKomandos.TabIndex = 0;
            this.cmbKomandos.SelectedIndexChanged += new System.EventHandler(this.cmbKomandos_SelectedIndexChanged);
            // 
            // statusOperation
            // 
            this.statusOperation.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
            this.statusOperation.Location = new System.Drawing.Point(0, 387);
            this.statusOperation.Name = "statusOperation";
            this.statusOperation.Size = new System.Drawing.Size(690, 22);
            this.statusOperation.TabIndex = 2;
            this.statusOperation.Text = "statusStrip1";
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = false;
            this.statusLabel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.statusLabel.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.statusLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.statusLabel.ForeColor = System.Drawing.Color.Green;
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(350, 17);
            // 
            // SMSContent
            // 
            this.SMSContent.BackColor = System.Drawing.Color.White;
            this.SMSContent.Location = new System.Drawing.Point(351, 184);
            this.SMSContent.Multiline = true;
            this.SMSContent.Name = "SMSContent";
            this.SMSContent.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.SMSContent.Size = new System.Drawing.Size(256, 137);
            this.SMSContent.TabIndex = 3;
            this.SMSContent.Text = "THIS IS A SHORT MESSAGE SENT WITH EDGE MODEM";
            // 
            // SendSMS
            // 
            this.SendSMS.Location = new System.Drawing.Point(351, 328);
            this.SendSMS.Name = "SendSMS";
            this.SendSMS.Size = new System.Drawing.Size(256, 23);
            this.SendSMS.TabIndex = 4;
            this.SendSMS.Text = "Send SMS(PDU)";
            this.SendSMS.UseVisualStyleBackColor = true;
            this.SendSMS.Click += new System.EventHandler(this.Button1_Click);
            // 
            // SendNumber
            // 
            this.SendNumber.BackColor = System.Drawing.Color.White;
            this.SendNumber.Location = new System.Drawing.Point(398, 155);
            this.SendNumber.Name = "SendNumber";
            this.SendNumber.Size = new System.Drawing.Size(186, 20);
            this.SendNumber.TabIndex = 5;
            this.SendNumber.Text = "989124434574";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(365, 158);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "To:";
            // 
            // ATcommand
            // 
            this.ATcommand.BackColor = System.Drawing.Color.White;
            this.ATcommand.Location = new System.Drawing.Point(21, 352);
            this.ATcommand.Name = "ATcommand";
            this.ATcommand.Size = new System.Drawing.Size(186, 20);
            this.ATcommand.TabIndex = 6;
            this.ATcommand.Text = "AT+CMGL=\"ALL\" ";
            // 
            // SendATcommand
            // 
            this.SendATcommand.Location = new System.Drawing.Point(213, 350);
            this.SendATcommand.Name = "SendATcommand";
            this.SendATcommand.Size = new System.Drawing.Size(95, 23);
            this.SendATcommand.TabIndex = 4;
            this.SendATcommand.Text = "Send AT";
            this.SendATcommand.UseVisualStyleBackColor = true;
            this.SendATcommand.Click += new System.EventHandler(this.SendATcommand_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(351, 350);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(256, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Send SMS(TEXT)";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click_1);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(203, 16);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(95, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Clear Result";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // frmModem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(690, 409);
            this.Controls.Add(this.ATcommand);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SendNumber);
            this.Controls.Add(this.SendATcommand);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.SendSMS);
            this.Controls.Add(this.SMSContent);
            this.Controls.Add(this.statusOperation);
            this.Controls.Add(this.grpKomandos);
            this.Controls.Add(this.grpModemas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmModem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Modem wrapper";
            this.Load += new System.EventHandler(this.FrmModem_Load);
            this.Shown += new System.EventHandler(this.frmModemas_Shown);
            this.grpModemas.ResumeLayout(false);
            this.grpModemas.PerformLayout();
            this.grpKomandos.ResumeLayout(false);
            this.grpKomandos.PerformLayout();
            this.statusOperation.ResumeLayout(false);
            this.statusOperation.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpModemas;
        private System.Windows.Forms.ComboBox cmbModelis;
        private System.Windows.Forms.ComboBox cmbPortas;
        private System.Windows.Forms.Label lblModelis;
        private System.Windows.Forms.Label lblPortas;
        private System.Windows.Forms.GroupBox grpKomandos;
        private System.Windows.Forms.ComboBox cmbKomandos;
        private System.Windows.Forms.TextBox txtAtsakymas;
        private System.Windows.Forms.Label lblAtsakymas;
        private System.Windows.Forms.Label lblKomandos;
        private System.Windows.Forms.Label lblInicializavimas;
        private System.Windows.Forms.TextBox txtInicializavimas;
        private System.Windows.Forms.StatusStrip statusOperation;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.TextBox SMSContent;
        private System.Windows.Forms.Button SendSMS;
        private System.Windows.Forms.TextBox SendNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ATcommand;
        private System.Windows.Forms.Button SendATcommand;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}

