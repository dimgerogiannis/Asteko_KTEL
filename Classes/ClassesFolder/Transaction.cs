using System;

namespace ClassesFolder
{
    public class Transaction
    {
        private decimal _price;
#nullable enable
        private Ticket? _ticket;
        private DateTime _purchaseDatetime;

        public decimal Price => _price;
        public Ticket? Ticket => _ticket;
        public DateTime PurchaseDatetime => _purchaseDatetime;

        public Transaction(decimal price, 
                           Ticket? ticket, 
                           DateTime purchaseDatetime)
        {
            _price = price;
            _ticket = ticket;
            _purchaseDatetime = purchaseDatetime;
        }
    }
}
