using System;
using System.Collections.Generic;
using System.Text;
using System.IO.Ports;

namespace Rs232
{
    /// <summary>
    /// Sub-class of modem model. Lets assume, that we have
    /// some modem of type 'Model1' and we need to override
    /// base class DefaultBoudrate property, modem initialization
    /// method and some other methods.
    /// </summary>
    public class ModemModel1 : Modem
    {
        #region constructors

        public ModemModel1() : base() { }
        public ModemModel1(SerialPort prt, SetCallback c) : base(prt,c) { }
        public ModemModel1(SerialPort prt, string prtnum, SetCallback c) : base(prt, prtnum, c) { }

        #endregion

        #region overriden properties

        // Will be other DefaultBoudrate than in base class
        public override int DefaultBoudrate
        {
            get {return 460800;}
        }

        #endregion

        #region overriden methods

        // Other modem initialization than in base class
        protected override void InitializeModem()
        {
            base.SendCommandToModem("ATE1L2S3?\r");
        }
        // Other command for geting manufacturer. Actually command is the
        // same - I4, but for simulating other behavior, just added additional
        // command I1.
        public override void GetManufacturer()
        {
            base.SendCommandToModem("ATI4I1\r");
        }
        // Also overriden command for getting modem product Id.
        // Added aditional command I3.
        public override void GetProductId()
        {
            base.SendCommandToModem("ATI0I3\r");
        }

        #endregion
    }
}
