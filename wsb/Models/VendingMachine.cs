using System;
using System.Collections.Generic;

namespace wsb
{
    [System.Serializable]
    public class VendingMachine
    {
        // unikatowy kod maszyny
        public string Code { get; set; }

        // adres miejsca gidze jest postawiona
        public string Adress { get; set; }

        public VendingMachineType Type { get; set; }

        // ilosc miejsc na produkty, np jak ma 10 to moze byc 5 batonikow i 5 roznych napoi
        public int NumberOfSlots { get; set; }

        // ile miesci sie produktow w jednym slocie
        public int SlotDepthness { get; set; }
        public bool IsWorking { get; set; } = true;

        public List<Product> Slots { get; set; }
        public List<Transaction> transactionList;

        public VendingMachine()
        {
            this.SlotDepthness = 20;
            this.NumberOfSlots = 60;

            InitializeSlots();
        }

        public VendingMachine(int numberOfSlots)
        {
            this.SlotDepthness = 20;
            this.NumberOfSlots = numberOfSlots;

            InitializeSlots();
        }

        private void InitializeSlots()
        {
            this.Slots = new List<Product>();
            transactionList = new List<Transaction>();
        }


        public void BuyProduct(int productCode)
        {
            if ( IsWorking )
            {
                if ( Slots[productCode].Count != 0 )
                {
                    Console.WriteLine("Zakupiono " + Slots[productCode].Name + " za " + Slots[productCode].Price + " zł" + " Zostało " + (Slots[productCode].Count-1) + "/" + SlotDepthness + " Automat na ulicy: " + Adress);

                    Slots[productCode].Count--;
                    transactionList.Add(new Transaction(productCode, DateTime.Now));
                }

                CheckSlot(productCode);
            }
            // kod błedu: maszyna nie działa
            else SendErrorCode(-1);
        }


        void CheckSlot(int productCode)
        {
            if ( Slots[productCode].Count <= SlotDepthness / 10 && Slots[productCode].Count > 0)
                // kod błedu: mniej niz 10% produktu
                SendErrorCode(5);
            else if ( Slots[productCode].Count == 0)
                // kod błedu: produtku nie ma
                SendErrorCode(10);

            IsWorking = RandomBreakChance();   
        }

        bool RandomBreakChance()
        {
            Random rnd = new Random();
            if ( rnd.Next(1, 1000) == 2 )
                return false;
            return true;
        }

        public void SendErrorCode(int errCode)
        {
            //TODO: Wysłanie do serwera ostrzeżenia
            //Oproznienie cache transakcji, przy okazji
            Console.WriteLine("Wysłano Kod Błędu => " + errCode + " " + Adress + " " + Code);
            EmptyTransactionChache();
        }

        public void EmptyTransactionChache()
        {

        }
        

        public void SendStatus()
        {
        }
    }
}