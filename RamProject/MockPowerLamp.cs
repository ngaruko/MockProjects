using Model.Components.Outputs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RamProject
{
   public class MockPowerLamp:IPowerLamp

    {

       public bool switchValue;

        public void SwitchOff()
        {
            this.switchValue=false;
        }

        public void SwitchOn()
        {
            this.switchValue=true;
        }

        public bool IsOn
        {
            get { return this.switchValue; }
        }

        public event EventHandler SwitchedOff;

        public event EventHandler SwitchedOn;


       public MockPowerLamp()
        {
           SwitchedOff+=MockPowerLamp_SwitchedOff;
        }

       private void MockPowerLamp_SwitchedOff(object sender, EventArgs e)
       {
           throw new NotImplementedException();
       }
    }
}
