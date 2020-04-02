using System.Collections.Generic;

namespace Naspinski.FoodTruck.Data.Access.AdditionalModels
{
    public class PaymentModel
    {
        public string OrderType { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Nonce { get; set; }
        public string BuyerVerificationToken { get; set; }
        public IEnumerable<PaymentModelItem> Items { get; set; }
    }

    public class PaymentModelItem
    {
        public int Quantity { get; set; }
        public string Name { get; set; }
        public string PriceTypeName { get; set; }
        public int PriceId { get; set; }
        public string Note { get; set; }
    }
}
