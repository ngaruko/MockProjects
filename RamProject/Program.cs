using Model.Components.Inputs;
using RamProject.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace RamProject
{
    class Program
    {
        static void Main(string[] args)
        {

            #region Instantiators

            MockPowerSwitch powerSwitch = new MockPowerSwitch();
            powerSwitch.switchVal = false;

            
            MockPowerLamp lampSwitch = new MockPowerLamp();
            
            lampSwitch.switchValue = false;
            
            
            MockWaterSensor waterSensor = new MockWaterSensor();
            Console.WriteLine("Is there any water in kettle: y or n ?");
            string isThereWater=Console.ReadLine().ToUpper();
            
            if(isThereWater=="Y")

            waterSensor.waterLevel = true;
            else if(isThereWater == "N")
                waterSensor.waterLevel = false;
            else
                Console.WriteLine ("Try again....");

            MockHeatingElement heatSwitch=new MockHeatingElement();
            heatSwitch.heatSwitchVal=false;

            MockTemperatureSensor tempSensor = new MockTemperatureSensor();
            tempSensor.curVal=24 ;

            

            KettleController kc = new KettleController(powerSwitch, lampSwitch, heatSwitch,tempSensor, waterSensor);
           // kc.BoilingTemp = 100;
            Console.WriteLine("Enter boiling temperature:");
            kc.BoilingTemp = Convert.ToInt32(Console.ReadLine());

            #endregion 

            // run kettle

           //Checking initial states 

            Console.WriteLine("Everything is set to go....\n");
            Console.WriteLine("Current temperature: {0}\n", tempSensor.curVal);
            Console.WriteLine("Water in kettle: {0}", waterSensor.waterLevel);
            Console.WriteLine("Boiling temperature: {0}", kc.BoilingTemp);
            Console.WriteLine("Power switch is OFF: {0}", !powerSwitch.switchVal);
            Console.WriteLine("Lamp OFF:{0}", !lampSwitch.switchValue);
            Console.WriteLine("Heating Element OFF:{0}\n",!heatSwitch.heatSwitchVal );

            Console.WriteLine("Now press Enter to switch kettle on!");
            
            Console.ReadLine();
            Console.Clear();

            
           // Turning on kettle, checking ON states
            kc.TurnOn();

            Console.WriteLine(" Kettle turned ON!....\n");
            Console.WriteLine("Checking components.....!\n");
            Console.WriteLine("Water in kettle: {0}\n", waterSensor.waterLevel);
            Console.WriteLine("Current temperature: {0}", tempSensor.curVal);
            Console.WriteLine("Boiling temperature: {0}\n", kc.BoilingTemp);
            Console.WriteLine("Power switch is ON: {0}", powerSwitch.switchVal);
            Console.WriteLine("Lamp ON:{0}", lampSwitch.IsOn);
            Console.WriteLine("Heating Element ON:{0}\n", heatSwitch.heatSwitchVal);

            

            Console.WriteLine("Now press Enter to switch start heating!");

            Console.ReadLine();
            Console.Clear();

            

            Console.WriteLine("\nNOW HEATING: PLEASE DON'T TOUCH KETTLE METAL!\n");
            
            //Running kettle with all components on (conditional)

            while (tempSensor.curVal < kc.BoilingTemp && waterSensor.waterLevel)
            {
                Console.Write("..");
                Console.Beep(100, 300);
                Console.Beep(100, 300);
                tempSensor.curVal+=2;
            }

            Console.Clear();

            //kc.TurnOff();

            // Turned off confirmation ---Checking final states
            Console.WriteLine("\n\nTURNED OFF\n\n");

            Console.WriteLine("Everything went well....\n");
            Console.WriteLine("Current temperature: {0}\n", tempSensor.curVal);
            Console.WriteLine("Boiling temperature: {0}", kc.BoilingTemp);
            Console.WriteLine("Power switch is OFF: {0}", powerSwitch.switchVal);
            Console.WriteLine("Lamp OFF:{0}", lampSwitch.switchValue);
            Console.WriteLine("Heating Element OFF:{0}\n", heatSwitch.heatSwitchVal);
            

                     
            Console.ReadLine();
        } // End of main
    }// End of Class Program
} // End of Namespace
