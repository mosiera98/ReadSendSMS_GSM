using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using static SMSPDULib.SMS;
using System.Threading;
using GsmComm.GsmCommunication;

namespace Rs232
{
    public partial class frmModem : Form
    {
        public Modem mod = null;
        public Modem.SetCallback call;
        public bool init = true;
       ShortMessage sm = new ShortMessage();
        
        

        public frmModem()
        {
            InitializeComponent();
            call = new Modem.SetCallback(this.TakeControl);
            
        }

        public void TakeControl(Modem modcall)
        {
            if (this.InvokeRequired)
            {
                Modem.SetCallback d = new Modem.SetCallback(TakeControl);
                this.Invoke(d, new object[] { modcall });
            }
            else
            {
                if (this.init)
                    this.txtInicializavimas.Text = modcall.ModemAnswer;
                else
                {
                    this.txtAtsakymas.Text = this.txtAtsakymas.Text + "\r\n" + modcall.ModemAnswer;
                    this.txtAtsakymas.SelectionStart = this.txtAtsakymas.TextLength;
                    this.txtAtsakymas.ScrollToCaret();
                }
                    


            }
        }

        private void cmbModelis_SelectedIndexChanged(object sender, EventArgs e)
        {
            init = true;
            this.cmbKomandos.SelectedIndex = -1;
            this.txtInicializavimas.Text = "";
            this.txtAtsakymas.Text = "";
            if (mod != null) mod.CloseModem();

            switch (this.cmbModelis.Text)
            {
                case "Basic":
                    mod = new Modem(new SerialPort(), this.cmbPortas.Text, this.call);
                    break;
                case "Model1":
                    mod = new ModemModel1(new SerialPort(), this.cmbPortas.Text, this.call);
                    break;
                case "Model2":
                    mod = new ModemModel2(new SerialPort(), this.cmbPortas.Text, this.call);
                    break;
                default:
                    break;
            }
        }

        private void cmbKomandos_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SMSContent.Visible = false;
                this.SendSMS.Visible = false;
            this.SendNumber.Visible = false;
            if (this.cmbKomandos.Text.Length > 0)
            {
                init = false;
                //this.txtAtsakymas.Text = "";
            }

            switch (this.cmbKomandos.Text)
            {
                case "Manufacturer":
                    mod.GetManufacturer();
                    break;
                case "ProductId":
                    mod.GetProductId();
                    break;
                case "SMS Center":
                    mod.GetSmsCenter();
                    break;
                case "MSISDN":
                    mod.GetMSISDN();
                    break;
                case "IMEI":
                    mod.GetIMEI();
                    break;
                case "IMSI":
                    mod.GetIMSI();
                    break;
                case "SoftwareVersion":
                    mod.GetSoftwareVersion();
                    break;                    
                case "SetPDU_mode":
                    mod.SetPDU_Mode();
                    break;
                case "SetTEXT_mode":
                    mod.SetTEXT_Mode();
                    break;
                case "READ_All_SMS":
                    mod.GetREADSMS("AT+CMGL=\"ALL\"");
                    break;
                case "SendSMS":
                    {
                        mod.GetREADSMS("AT+CMGF=0");
                        this.SMSContent.Visible = true;
                        this.SendSMS.Visible = true;
                        this.SendNumber.Visible = true;
                        break;
                    }
                case "Send_Ctrl+Z":
                    mod.GetREADSMS("\x1A");
                    break;
                case "Enable_Delivery":
                    mod.GetREADSMS("AT+CNMI=2,1,0,1,0\n");//octet 4 for sms delivy 1:enable 0 disable when enable  reture this sample message like this after sms delivered (+CDS: 25  079189390500410006270C81891942345447228013023041812280130230718100)
                    break;
                case "Disable_Delivery":
                    mod.GetREADSMS("AT+CNMI=2,1,0,0,0\n");//octet 4 for sms delivy 1:enable 0 disable when enable  reture this sample message like this after sms delivered (+CDS: 25  079189390500410006270C81891942345447228013023041812280130230718100)
                    break;
                case "Send_Enter":
                    mod.GetREADSMS("\n\r");
                    break;
                case "Read_Config":
                    mod.GetREADSMS("AT&V\r");
                    break;
                case "Delete_all_SIM_SMS":
                    {
                        for (int i = 1; i < 16; i++)
                        {
                            mod.GetREADSMS("AT+CMGD="+i.ToString()+"\r");
                            Thread.Sleep(200);
                        }
                       
                        break;
                    }
                   
                default:
                    break;
            }
        }

        private void frmModemas_Shown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            this.cmbModelis.Focus();
            this.statusLabel.Text = "Searching modem, please wait...";
            this.Refresh();
            Modem.AttachedModem am = Modem.FirstAttachedModem();
            if (am.Port != null)
            {
                this.statusLabel.ForeColor = Color.DarkBlue;
                this.statusLabel.Text = "MODEM: " + am.ModemModel;
                this.cmbPortas.Text = am.Port;
                this.cmbModelis.SelectedIndex = 1;
            }
            else
            {
                this.statusLabel.ForeColor = Color.Red;
                this.statusLabel.Text = "No modem found attached to COM port!";
            }
            this.Cursor = Cursors.Default;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            //SMSContent.Text = "It is easy to send text messages.";

            if (SMSContent.Text.Length > 70)
            {
                var messages = BatchMessage(SMSContent.Text.Trim());
                int j = 0;
                var sms = new SMSPDULib.SMS()
                {

                    //Message = message,//SMSContent.Text.Trim(),
                    UserDataStartsWithHeader = false,
                    PhoneNumber = SendNumber.Text.Trim(),// "989124434574",
                    ServiceCenterNumber = "989034015019",
                    StatusReportIndication = true,
                    Direction = SMSPDULib.SMSDirection.Submited,// if bit 5th of first octet set to 1 means that the request delivery report


                };
                foreach (var message in messages)
                {
                    
                    if (j == 0)
                    {
                        sms.Message = message;
                        sms.MoreMessagesToSend = true;
                        //  sms.MessageReference = 0;
                    }

                    if (j == 1)
                    {
                        sms.Message = message;
                        sms.MoreMessagesToSend = false;
                    }
                    var part = sms.Part;
                    var part2 = sms.InParts;
                    var part3 = sms.InPartsID;
                    sms.Message = message.Trim();
                   // sms.MessageReference = 1;
                    string resultt = sms.Compose(SMSEncoding._7bit);
                    string resultt2 = resultt.Substring(10, resultt.Length - 10);
                    string resull3 = "01000C91" + resultt2;
                    int PduLenn = resull3.Length;
                    string pdu_cmdd = (PduLenn / 2).ToString();
                    string end_pduu = "0791890943100591" + resull3;
                    // mod.GetSendSMS(SMSContent.Text.Trim());
                    if (j==0)
                    mod.GetSendSMS(end_pduu, pdu_cmdd,false);
                    else
                        mod.GetSendSMS(end_pduu, pdu_cmdd, true);
                    j++;
                }
                return;
            }
            var sms1 = new SMSPDULib.SMS()
            {
                Message = SMSContent.Text.Trim(),
                UserDataStartsWithHeader = false,
                PhoneNumber = SendNumber.Text.Trim(),// "989124434574",
                //ServiceCenterNumber = "989034015019",
                StatusReportIndication = false,
                Direction = SMSPDULib.SMSDirection.Submited,
            };

            // sms1.MessageReference = 1;
            //sms1.Message=SMSContent.Text.Trim();
            sms1.StatusReportIndication = true;
            string result = sms1.Compose(SMSEncoding._7bit);//.Remove(4, 1).Insert(4, "1");


            string result2 = result.Substring(10, result.Length - 10);
            string resul3;
            if (sms1.StatusReportIndication)
                resul3 = "21000C91" + result2;//bit 1 2 for enable delivery and 0 for not delivery
            else
                resul3 = "01000C91" + result2;
            if(sms1.Direction.ToString() == SMSPDULib.SMSDirection.Submited.ToString())
                resul3 = "21000C91" + result2;//bit 2=1 for submit  and 0 for receive
            else
                resul3 = "20000C91" + result2;

            int PduLen = resul3.Length;
            string pdu_cmd = (PduLen / 2).ToString();
            string end_pdu = "0791890943100591" + resul3;
            //mod.GetSendSMS(SMSContent.Text.Trim());
            mod.GetSendSMS(end_pdu, pdu_cmd);





            //base64 Sample Sms From M.Esmaeili :
            //3moAqk2huYerjDELXsCu/dCqkweYXLfSk6QIhhAqw3/VwMpW3N5+oA40dGUwVfy3U7BGxk3a0vNQ5zXhOAZfGh4GnOtqk0KDVPvJvq/UJuY=

            //  0791893905004100240C9189094310059100002250707165438107C7F7FBFC9EA301
            //                          0030000CA189094310059100007307C7F7FBFC9EA301
            //  0020000CA1            89094310059100000              7C7F7FBFC9EA301


        }
        public static IEnumerable<string> BatchMessage(string message ,int batchSize=70)
        {
            /*
            if(string.IsNullOrEmpty(message))
            {
                //empty
            }
            if (batchSize <message.Length)
            {
                //message smaller than message
            }
            */
            for (int i = 0; i <message.Length; i += batchSize)
            {
                yield return message.Substring(i, Math.Min(batchSize, message.Length - i));
            }

        }

        private void SendATcommand_Click(object sender, EventArgs e)
        {
            mod.GetREADSMS(this.ATcommand.Text);
        }

        private void FrmModem_Load(object sender, EventArgs e)
        {
           // cmbModelis.SelectedIndex = 1;
        }

        private void Button1_Click_1(object sender, EventArgs e)
        {

            mod.GetSendSMSText(SMSContent.Text, SendNumber.Text);
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            txtAtsakymas.Text = "";
        }
    }
}