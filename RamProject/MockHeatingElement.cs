using Model.Components.Workers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RamProject
{
    public class MockHeatingElement:IHeatingElement
    {

        public bool heatSwitchVal;
        public bool isOn;

        public void SwitchOff()
        {
            this.heatSwitchVal=false;
        }

        public void SwitchOn()
        {
           this.heatSwitchVal=true;
        }

        public bool IsOn
        {
            get { return this.isOn; }
        }

        public event EventHandler SwitchedOff;

        public event EventHandler SwitchedOn;
    }
  }