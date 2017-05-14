using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wsb
{
    public static class ProductGenerator
    {
        public static Product GetSnickers()
        {
            var snickers = new CandyBar();
            snickers.Name = "Snickers";
            snickers.Price = 2.50f;
            snickers.Producer = "Mars";
            snickers.Taste = "Klasyczny";
            snickers.Code = "SnickersRegular";

            return snickers;
        }

        public static Product GetCisowiankaStill()
        {
            var cisowianka = new Drink() {
                Name = "Cisowianka",
                Producer = "Cisowianka",
                DrinkType = DrinkType.StillWater,
                Price = 2.0f,
                Code = "CisowiankaStill" };
            return cisowianka;
        }

        public static Product GetLajkonikSalted()
        {
            var paluszki = new Snack()
            {
                Name = "Paluszki",
                Producer = "Lajkonik",
                SnackType = SnackType.Breadsticks,
                Price = 5.0f,
                Taste = "Solone",
                Code = "LajkonikSolone"
            };
            return paluszki;
        }
    }
}
