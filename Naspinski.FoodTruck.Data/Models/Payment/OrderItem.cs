using Naspinski.FoodTruck.Data.Models.Menu;
using Square.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Naspinski.FoodTruck.Data.Models.Payment
{
    public class OrderItem
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int OrderId { get; set; }

        public Order Order { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public int PriceId { get; set; }

        public Price Price { get; set; }

        public string Description { get; set; }

        public string Note { get; set; }

        public OrderLineItem ToOrderLineItem()
        {
            var usd = "USD";

            var baseInCents = Convert.ToInt32((Price?.Amount ?? 0) * 100);
            return new OrderLineItem(
                quantity: Quantity.ToString(),
                name: Description,
                note: Note,
                basePriceMoney: new Money(baseInCents, usd));
        }
    }
}
