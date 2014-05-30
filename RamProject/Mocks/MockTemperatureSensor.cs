using Model.Components.Sensors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RamProject.Mocks
{
    public class MockTemperatureSensor:ITemperatureSensor
    {
        
        public int curVal ;
        
        
        public int CurrentValue
        {
            get { return this.curVal; }
            
            
        }

        
        
    }
}
