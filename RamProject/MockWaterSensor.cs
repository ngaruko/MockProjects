using Model.Components.Sensors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RamProject
{
  
   public class MockWaterSensor:IWaterSensor
    {   
        public bool waterLevel; // made public to be able to mock test
        public bool CurrentValue
        {
            get { return this.waterLevel; }
        }
    }
}
