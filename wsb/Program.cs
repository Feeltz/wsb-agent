using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wsb
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();

            int ileSlotow = 18;
            var maszyna = new VendingMachine(ileSlotow);
            for (int i = 0; i < ileSlotow; i=i+3)
            {
                maszyna.FillSlotWithCustomNumberOfProduct(i, ProductGenerator.GetCisowiankaStill(), rand.Next(maszyna.SlotDepthness));
                maszyna.FillSlotWithCustomNumberOfProduct(i+1, ProductGenerator.GetLajkonikSalted(), rand.Next(maszyna.SlotDepthness));
                maszyna.FillSlotWithCustomNumberOfProduct(i+2, ProductGenerator.GetSnickers(), rand.Next(maszyna.SlotDepthness));
            }
           


            Console.ReadLine();
        }
    }
}
