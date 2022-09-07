using System;
using System.Collections.Generic;
using System.Text;
using System.IO.Ports;
using System.Threading;
using SMSPDULib;

namespace Rs232
{
    /// <summary>
    /// Base class for communication with modem. 
    /// All concrete model modem sub-classes should inherit this base class.
    /// </summary>
    public class Modem
    {
        #region structs

        public struct AttachedModem
        {
            public string Port;
            public string ModemModel;
        }

        #endregion

        #region private fields
        public static  string Pdu;
        private SerialPort _port;
        private string _pname = "";
        private int _boudrate = 0;
        private string _answer;
        private SetCallback _call = null;

        #endregion

        #region delegates

        public delegate void SetCallback(Modem modcall);

        #endregion

        #region properties

        // COM port name
        public string PortNumber
        {
            get { return _pname; }
            set { _pname = value; }
        }

        // Port Boudrate
        public string PortBoudrate
        {
            get { return _boudrate.ToString(); }
            set { _boudrate = int.Parse(value); }
        }

        // Default boudrate read-only
        public virtual int DefaultBoudrate
        {
            get { return 9600; }
        }

        // Modem answer to command, field only read-only
        public string ModemAnswer
        {
            get { return _answer; }
        }

        #endregion

        #region constructors

        // First constructor
        public Modem(SerialPort prt, SetCallback c)
        {
            _call = c;
            _port = prt;
            _port.DataReceived += new SerialDataReceivedEventHandler(this.DataReceived);
            if (_pname == "") _pname = Modem.FirstAttachedModem().Port;
            if (_boudrate == 0) _boudrate = this.DefaultBoudrate;
            OpenModem();
        }
        // Second constructor
        public Modem(SerialPort prt, string prtnum, SetCallback c)
        {
            _call = c;
            _port = prt;
            _port.DataReceived += new SerialDataReceivedEventHandler(this.DataReceived);
            this.PortNumber = prtnum;
            this.PortBoudrate = this.DefaultBoudrate.ToString();
            OpenModem();
        }


        /*
Third constructor parameterless - this means that there will be no
modem answer delegate (null). This in turn results that UI will not 
see modem initialization and answer events.
*/
        public Modem() : this(new SerialPort(), null) { }

        #endregion

        #region non-virtual methods

        // Method which will call delegate. This delegate 
        // can be fired not on every DataReceived event.
        private void AnalyzeAnswer()
        {
            if (_answer.Length > 0 && _call != null)
            {
                _call(this);
            }
        }

        // Opening modem port
        private void OpenModem()
        {
            this.CloseModem();
            _port.PortName = _pname;
            _port.BaudRate = _boudrate;
            _port.Open();
            this.InitializeModem();
        }

        

        // Closing modem port
        public void CloseModem()
        {
            if (_port.IsOpen) _port.Close();
        }

        // Sending command to modem port, needs to be marked as 'protected'
        // for being seen in sub-classes
        protected void SendCommandToModem(string command)
        {
           // _answer = "";
            if (!_port.IsOpen) this.OpenModem();
            _port.Write(command);
            Thread.Sleep(200);
        }

        #endregion

        #region virtual methods

        // Modem initialization, basic AT commands. E0 means echo off.
        protected virtual void InitializeModem()
        {
            this.SendCommandToModem("ATE0\r");
        }

        // Finding modem manufacturer, AT command I4.
        public virtual void GetManufacturer()
        {
            this.SendCommandToModem("ATI4\r");
        }

        // Finding modem product Id, AT command I0.
        public virtual void GetProductId()
        {
            this.SendCommandToModem("ATI0\r");
        }
        public virtual void GetSmsCenter()
        {
            this.SendCommandToModem("AT+CSCA?\r");

        }
        public void GetMSISDN()
        {
            this.SendCommandToModem("AT+CNUM\r");
        }

        public void GetIMEI()
        {
            this.SendCommandToModem("AT+CGSN\r");
        }

        public void GetIMSI()
        {
            this.SendCommandToModem("AT+CIMI\r");
        }
        public void GetSoftwareVersion()
        {
            this.SendCommandToModem("AT+CGMR\r");
        }
        public void GetREADSMS()
        {
            this.SendCommandToModem("AT+CMGL;+CGMI\r");
        }

        public void GetREADSMS(string command)
        {
            this.SendCommandToModem(command+"\r");
        }
        internal void SetPDU_Mode()
        {
            this.SendCommandToModem("AT+CMGF=0\r");
        }

        internal void SetTEXT_Mode()
        {
            this.SendCommandToModem("AT+CMGF=1\r");
        }
        public void GetSendSMS(string SMScontent,string lencmd)
        {
            string source = SMScontent;

            SMSType smsType = SMSBase.GetSMSType(source);

            switch (smsType)
            {
                case SMSType.SMS:
                    SMS sms = new SMS();
                    
                    SMS.Fetch(sms, ref source);
                    sms.StatusReportIndication = true;
                    ShowSMS(sms);
                    break;
                case SMSType.StatusReport:
                    SMSStatusReport statusReport = new SMSStatusReport();
                    SMSStatusReport.Fetch(statusReport, ref source);

                    ShowStatusReport(statusReport);
                    break;
            }
           // this.SendCommandToModem("AT+CMGF=0");
            string Atc= "AT+CMGS="+lencmd+"\r";
            //this.SendCommandToModem("AT+CMGS=42\r");
             this.SendCommandToModem(Atc);
            this.SendCommandToModem(SMScontent+"\n");
            //It is easy to send text messages(32 charachter)
            this.SendCommandToModem("\x1A");

        }
        public void GetSendSMS(string SMScontent, string lencmd,bool end)
        {
            string source = SMScontent;

            SMSType smsType = SMSBase.GetSMSType(source);

            switch (smsType)
            {
                case SMSType.SMS:
                    SMS sms = new SMS();

                    SMS.Fetch(sms, ref source);
                    sms.StatusReportIndication = true;
                    ShowSMS(sms);
                    break;
                case SMSType.StatusReport:
                    SMSStatusReport statusReport = new SMSStatusReport();
                    SMSStatusReport.Fetch(statusReport, ref source);

                    ShowStatusReport(statusReport);
                    break;
            }
            // this.SendCommandToModem("AT+CMGF=0");
            string Atc = "AT+CMGS=" + lencmd + "\r";
            //this.SendCommandToModem("AT+CMGS=42\r");
            this.SendCommandToModem(Atc);
            this.SendCommandToModem(SMScontent + "\n");
            //It is easy to send text messages(32 charachter)
            if (end)
            this.SendCommandToModem("\x1A");
            

        }
        public void GetSendSMSText(string SMScontent, string lencmd)
        {
            
           // this.SendCommandToModem("AT+CMGF=1");
            string Atc = "AT+CMGS=" +"\""+ lencmd + "\"" + "\r";
            //this.SendCommandToModem("AT+CMGS=42\r");
            this.SendCommandToModem(Atc);
            this.SendCommandToModem(SMScontent + "\n");
            //It is easy to send text messages(32 charachter)
            this.SendCommandToModem("\x1A");

        }
        #endregion

        #region static methods

        // Method for searching connected modem on COM ports.
        // Returns modem manufacturer, modem chipset version
        // (with AT commands I4I3) and COM port on which modem exists.
        public static AttachedModem FirstAttachedModem()
        {
            AttachedModem am = new AttachedModem();
            SerialPort sp = new SerialPort();
            string port, answer;

            for (int i = 1; i <= 8; i++)
            {
                port = "COM" + i.ToString();
                sp.PortName = port;
                sp.BaudRate = 460800;

                try
                {
                    sp.Open();
                    if (sp.IsOpen)
                    {
                        sp.Write("ATE0\r");
                        Thread.Sleep(200);
                        answer = sp.ReadExisting().Replace("ATE0", "").Trim().ToUpper();
                        if (answer == "OK")
                        {
                            sp.Write("ATI4I3\r");
                            Thread.Sleep(200);
                            answer = sp.ReadExisting().Trim().ToUpper().Replace("\r\nOK", "").Trim().Replace("\r\n", "");
                            am.Port = port;
                            am.ModemModel = answer;
                            sp.Close();
                            break;
                        }
                    }
                    if (sp.IsOpen) sp.Close();
                }
                catch (Exception) { }
            }

            return am;
        }

        #endregion

        #region events
        private void ShowSMS(SMS sms)
        {
            string format = "Service center number: {0}\r\nService center time stamp: {1}\r\nMessage reference #: {2}\r\nDirection: {3}\r\nPhone number: {4}\r\nStatus report indication: {5}\r\nMessage:\r\n{6}";

            Pdu  = string.Format(format,
                sms.ServiceCenterNumber,
                sms.ServiceCenterTimeStamp,
                sms.MessageReference,
                sms.Direction,
                sms.PhoneNumber,
                sms.StatusReportIndication,
                sms.Message);
            
        }
        private void ShowStatusReport(SMSStatusReport sms)
        {
            string format = "Service center number: {0}\r\nService center time stamp: {1}\r\nMessage reference #: {2}\r\nPhone number: {3}\r\nReport time stamp: {4}\r\nReport status: {5}";

            Pdu = string.Format(format,
                sms.ServiceCenterNumber,
                sms.ServiceCenterTimeStamp,
                sms.MessageReference,
                sms.PhoneNumber,
                sms.ReportTimeStamp,
                sms.ReportStatus);
        }


        // Event when signal is received on COM port data pins. Usually 8 pins.
        private void DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            _answer =  _port.ReadExisting().Trim().Replace("\r\n\r\n", "\r\n");
            this.AnalyzeAnswer();
        }

        #endregion
    }
}
