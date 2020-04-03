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

        [NotMapped]
        public IEnumerable<string> ComboParts;

        public OrderLineItem ToOrderLineItem(decimal additiveTax, decimal includedTax)
        {
            var additiveTaxRate = additiveTax / 100;
            var includedTaxRate = includedTax / 100;
            var usd = "USD";

            var baseInCents = Convert.ToInt32((Price?.Amount ?? 0) * 100);
            var baseWithoutTaxInCents = Convert.ToInt32(baseInCents / (1 + includedTaxRate));
            var subtotalInCents = baseInCents * Quantity;

            var taxAdditiveInCents = Convert.ToInt32(subtotalInCents * additiveTaxRate);
            var totalInCents = subtotalInCents + taxAdditiveInCents;

            var totalWithoutTaxInCents = Convert.ToInt32(subtotalInCents / (1 + includedTaxRate));
            var taxIncludedInCents = subtotalInCents - totalWithoutTaxInCents;

            return new OrderLineItem(
                quantity: Quantity.ToString(),
                name: Price?.MenuItem?.Name ?? "[name]",
                basePriceMoney: new Money(baseInCents, usd),
                totalTaxMoney: new Money(taxAdditiveInCents + taxIncludedInCents, usd),
                totalMoney: new Money(totalInCents, usd),
                catalogObjectId: Price?.MenuItem?.ItemId ?? string.Empty);
        }

        //public CreateOrderRequestLineItem ToCreateOrderRequestLineItem(decimal additiveTax, decimal includedTax)
        //{
        //    var li = ToOrderLineItem(additiveTax, includedTax);
        //    return new CreateOrderRequestLineItem(li.Name, li.Quantity, li.BasePriceMoney);
        //}
    }
}
