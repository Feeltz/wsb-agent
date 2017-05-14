using System;
using System.Collections.Generic;

namespace wsb
{

    public class VendingMachine
    {
        // unikatowy kod maszyny
        public string Code { get; set; }

        // adres miejsca gidze jest postawiona
        public string Adress { get; set; }

        public string Producent { get; set; }
        public VendingMachineType Type { get; set; }

        // ilosc miejsc na produkty, np jak ma 10 to moze byc 5 batonikow i 5 roznych napoi
        public int NumberOfSlots { get; set; }

        // ile miesci sie produktow w jednym slocie
        public int SlotDepthness { get; set; }

        public Stack<Product>[] Slots { get; set; }
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
            this.Slots = new Stack<Product>[this.NumberOfSlots];
            for ( int i = 0; i < NumberOfSlots; i++ )
            {
                Stack<Product> slot = new Stack<Product>();
                this.Slots[i] = slot;
            }

            transactionList = new List<Transaction>();
        }

        public void FillSlotWithProductToFull(int slotNumber, Product product)
        {
            for ( int i = 0; i < this.SlotDepthness; i++ )
            {
                this.Slots[slotNumber].Push(product);
            }
        }

        public void FillSlotWithCustomNumberOfProduct(int slotNumber, Product product, int productCount)
        {
            for ( int i = 0; i < productCount; i++ )
            {
                this.Slots[slotNumber].Push(product);
            }
        }

        public void BuyProduct(int productCode)
        {
            if ( Slots[productCode].Count != 0 )
            {
                Slots[productCode].Pop();
                transactionList.Add(new Transaction(productCode, DateTime.Now));

                if ( Slots[productCode].Count <= SlotDepthness / 10 )
                    SendWarning("10% warning");
            }
            else
                SendWarning("empty");

        }

        public void SendWarning(string Type)
        {
            //TODO: Wysłanie do serwera ostrzeżenia
            //Oproznienie cache transakcji, przy okazji
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