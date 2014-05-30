using Model.Components.Inputs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RamProject.Mocks
{
    public class MockPowerSwitch: IPowerSwitch
    {
        public bool switchVal;
        public void SwitchOff()
        {
            this.switchVal = false; ;
        }

        public void SwitchOn()
        {
            this.switchVal=true;
        }

        public bool IsOn
        {
            get { return this.switchVal; }
        }

        public event EventHandler SwitchedOff;

        public event EventHandler SwitchedOn;

        public MockPowerSwitch()
        {
            SwitchedOff += MockPowerSwitch_SwitchedOff;
        }

        void MockPowerSwitch_SwitchedOff(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

    }// End of class MockPowerSitch
}
