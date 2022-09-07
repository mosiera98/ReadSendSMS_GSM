using System;
using System.Collections.Generic;
using System.Text;
using System.IO.Ports;

namespace Rs232
{
    /// <summary>
    /// Sub-class of modem model. Lets assume, that we have
    /// some modem of type 'Model2' and we need to override
    /// base class DefaultBoudrate property, modem initialization
    /// method and some other methods.
    /// </summary>
    public class ModemModel2 : Modem
    {
        #region constructors

        public ModemModel2() : base() { }
        public ModemModel2(SerialPort prt, SetCallback c) : base(prt,c) { }
        public ModemModel2(SerialPort prt, string prtnum, SetCallback c) : base(prt, prtnum, c) { }

        #endregion

        #region overriden properties

        // Will be overriden DefaultBoudrate - will be bigger than in 'Model1' modem.
        public override int DefaultBoudrate
        {
            get { return 460800; }
        }

        #endregion

        #region overriden methods

        // Other modem initialization than in base class.
        protected override void InitializeModem()
        {
            base.SendCommandToModem("ATE0S3?S2?\r");
        }
        // Other command for geting manufacturer - also simulated
        // by adding additional AT commands (S1?S2?S3?) 
        // for reading 3 modem registers.
        public override void GetManufacturer()
        {
            base.SendCommandToModem("ATI4S1?S2?S3?\r");
        }
        // Overriding modem product Id lookup. Different
        // behavior simulated by adding additional modem
        // AT commands (I3&V) - for reading chipset version and user profile.
        public override void GetProductId()
        {
            base.SendCommandToModem("ATI0I3&V\r");
        }

        #endregion
    }
}
