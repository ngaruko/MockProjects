using Model.Components;
using Model.Components.Inputs;
using Model.Components.Outputs;
using Model.Components.Sensors;
using Model.Components.Workers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RamProject
{
    public class KettleController
    {
        #region Public Properties
        
       
        public int BoilingTemp 
        { 
            get { return this.boilingTemp; } 
            set { this.boilingTemp = value; } 
        }
        public IPowerSwitch PowerSwitch
        {
            get{
               return this.powerSwitch;
               
               }

            set
           {
               
               this.powerSwitch = value;
               
           }
        }
        public IHeatingElement HeatingElement
        {
            get
            {
                return this.heatingElement;
            }

            set
            {
                this.heatingElement = value;
            }
        }
        public ITemperatureSensor TemperatureSensor
        {
            get { return this.temperatureSensor; }
            set { this.temperatureSensor = value; } 
        }
        public IWaterSensor WaterSensor
        {
            get { return this.waterSensor; }
            set { this.waterSensor = value; }
        }
        public IPowerLamp PowerLamp
        {
            get { return this.powerLamp; }
            set { this.powerLamp = value; }
        }

        #endregion


        private IPowerSwitch powerSwitch;
        private IHeatingElement heatingElement;
        private ITemperatureSensor temperatureSensor;
        private IWaterSensor waterSensor;
        private IPowerLamp powerLamp;
        private int boilingTemp;

        #region Constructor

        public KettleController( IPowerSwitch ps, IPowerLamp pl, IHeatingElement he, ITemperatureSensor ts, IWaterSensor ws)        //constructor
        {
            this.powerSwitch = ps;
            this.powerSwitch.SwitchedOn+=new EventHandler( powerSwitch_SwitchedOn);
            this.powerSwitch.SwitchedOff+=new EventHandler( powerSwitch_SwitchedOff);
            
      
            this.powerLamp = pl;
            this.powerLamp.SwitchedOn+=new EventHandler (powerLamp_SwitchedOn);
           this.powerLamp.SwitchedOff+=new EventHandler (powerLamp_SwitchedOff);

           this.heatingElement = he;
           this.temperatureSensor = ts;
           this.waterSensor = ws;

            
        }

        #endregion

        #region Private Methods

        private void powerLamp_SwitchedOff(object sender, EventArgs e)
        {
            this.powerLamp.SwitchOff();
        }

        private void powerLamp_SwitchedOn(object sender, EventArgs e)
        {
            this.powerLamp.SwitchOn();
        }

        

        private void powerSwitch_SwitchedOn(object sender, EventArgs e)
        {
           this.TurnOn();
            while(this.temperatureSensor.CurrentValue<this.BoilingTemp && this.waterSensor.CurrentValue)
            {
                

            }
            this.TurnOff();
         }
        private void powerSwitch_SwitchedOff(object sender, EventArgs e)
        {
            this.TurnOff();
        }

        #endregion

        public void TurnOn()
        {

            this.powerSwitch.SwitchOn();
            this.powerLamp.SwitchOn();
            this.heatingElement.SwitchOn();

            
        }

        public void TurnOff()
        {
            this.heatingElement.SwitchOff();
            this.powerLamp.SwitchOff();
            this.powerSwitch.SwitchOff();
        }
    }
}
