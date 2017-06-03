using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using System.Timers;

namespace wsb
{
    static class Program
    {
        static VendingMachine machine;
        static void Main(string[] args)
        {
            Timer timer = new Timer(100);


            if ( File.Exists("data.json") )
            {
                machine = JsonConvert.DeserializeObject<VendingMachine>(File.ReadAllText("data.json"));
            }
            else
                machine = ProductGenerator.Generate();

            timer.Elapsed += Timer_Elapsed;
            timer.Enabled = true;
            timer.AutoReset = true;

            Console.ReadLine();
            File.WriteAllText("data.json", JsonConvert.SerializeObject(machine, Formatting.Indented));
        }

        private static void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Random rnd = new Random();

            machine.BuyProduct(rnd.Next(0, machine.NumberOfSlots));
        }
    }
}
