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
        static List<VendingMachine> vList = new List<VendingMachine>();
        static void Main(string[] args)
        {
            Timer timer = new Timer(100);
            

            //if ( !File.Exists("data.json") )
            //{
                for ( int i = 0; i < 5; i++ )
                    vList.Add(ProductGenerator.Generate());

                File.WriteAllText("data.json", JsonConvert.SerializeObject(vList, Formatting.Indented));
            //}
            //else
            //{
                //vList = JsonConvert.DeserializeObject<List<VendingMachine>>(File.ReadAllText("data.json"));
            //}

            timer.Elapsed += Timer_Elapsed;
            timer.Enabled = true;
            timer.AutoReset = true;


            //for (int i = 0; i < ileSlotow; i=i+3)
            //{
            //    maszyna.FillSlotWithCustomNumberOfProduct(i, ProductGenerator.GetCisowiankaStill(), rand.Next(maszyna.SlotDepthness));
            //    maszyna.FillSlotWithCustomNumberOfProduct(i+1, ProductGenerator.GetLajkonikSalted(), rand.Next(maszyna.SlotDepthness));
            //    maszyna.FillSlotWithCustomNumberOfProduct(i+2, ProductGenerator.GetSnickers(), rand.Next(maszyna.SlotDepthness));
            //}



            Console.ReadLine();
        }

        private static void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Random rnd = new Random();
            int machine = rnd.Next(0, 5);
            vList[machine].BuyProduct(rnd.Next(0, vList[machine].NumberOfSlots));
        }
    }
}
