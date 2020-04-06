using Naspinski.Data.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Naspinski.FoodTruck.Data.Models.Payment
{
    public class Order : AuditCreateUpdateDeleteBase
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Email { get; set; }
        public string Address { get; set; }
        public string TransactionId { get; set; }

        [NotMapped]
        public bool IsTransactionComplete { get { return TransactionId != null && !string.IsNullOrWhiteSpace(TransactionId); } }

        [Required]
        public int TotalInCents { get; set; }
        
        public int TaxInCents { get; set; }

        public DateTimeOffset? Made { get; set; }
        public DateTimeOffset? Notified { get; set; }

        public string OrderType { get; set; }

        [NotMapped] public bool IsDelivery { get { return OrderType == Constants.OrderType.Delivery; } }
        [NotMapped] public bool IsCarryout { get { return OrderType == Constants.OrderType.Carryout; } }
        [NotMapped] public bool IsTruck { get { return OrderType == Constants.OrderType.FoodTruck; } }

        [NotMapped]
        public decimal TaxRate { get; set; }
        [NotMapped]
        public double Price { get { return Convert.ToDouble(TotalInCents + TaxInCents) / 100d; } }

        [NotMapped]
        public string PriceAsCurrency
        {
            get
            {
                return string.Format("{0:C}", Convert.ToDouble(TotalInCents + TaxInCents) / 100d);
            }
        }
        [NotMapped]
        public string SubtotalAsCurrency
        {
            get
            {
                return string.Format("{0:C}", Convert.ToDouble(TotalInCents) / 100d);
            }
        }
        [NotMapped]
        public string TaxAsCurrency
        {
            get
            {
                var val = Convert.ToDouble(TaxInCents) / 100d;
                return string.Format("{0:C}", val);
            }
        }

        [Required]
        public bool IsSandbox { get; set; }

        [Required]
        public string Phone { get; set; }

        public string FullText { get; set; }

        [NotMapped]
        public string Note { get; set; }

        public IEnumerable<OrderItem> Items { get; set; }

        [NotMapped]
        public bool IsValid
        {
            get
            {
                if (IsDelivery && string.IsNullOrWhiteSpace(Address))
                    return false;

                return true;
            }
        }

        [NotMapped]
        public string PickUpInMinutes { get; set; }


        public void SetFullText()
        {
            var n = Environment.NewLine;

            if (!string.IsNullOrWhiteSpace(PickUpInMinutes) && PickUpInMinutes != "0")
                FullText += $"We will try to have it ready in {PickUpInMinutes} minutes as requested{n}{n}";

            FullText += $"{OrderType} Order [ID: {Id}]{n}{n}";

            if (IsDelivery)
                FullText += $"{Address}{n}{n}";

            foreach (var line in Items)
            {
                FullText += $" - {line.Description} {n}";
                if(!string.IsNullOrWhiteSpace(line.Note))
                    FullText += $"   > {line.Note} {n}";
            }
            if (TaxInCents > 0)
            {
                FullText += $"{n}Subtotal: {SubtotalAsCurrency}";
                FullText += $"{n}Tax: {TaxAsCurrency}";
            }
            FullText += $"{n}Total: {PriceAsCurrency}";

            if (!string.IsNullOrWhiteSpace(Note))
                FullText += $"{n}{n}{Note}";
        }
    }
}
