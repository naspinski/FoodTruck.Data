using Naspinski.Data.Interfaces;
using Naspinski.FoodTruck.Data.Models.Payment;
using square = Square.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Naspinski.FoodTruck.Data.Distribution.Models.Orders
{
    public class OrderModel : IToModel<Order>
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Email { get; set; }
        public string Address { get; set; }
        public string OrderType { get; set; }

        public string Name { get; set; }
        public string TransactionId { get; set; }        
        public bool IsTransactionComplete { get { return TransactionId != null && !string.IsNullOrEmpty(TransactionId); } }
        public int TotalInCents { get; set; }
        public int TaxInCents { get; set; }

        public string PriceAsCurrency
        {
            get
            {
                return string.Format("{0:C}", (TotalInCents + TaxInCents) / 100);
            }
        }
        public string SubtotalAsCurrency
        {
            get
            {
                return string.Format("{0:C}", TotalInCents / 100);
            }
        }
        public string TaxAsCurrency
        {
            get
            {
                return string.Format("{0:C}", TaxInCents / 100);
            }
        }
        
        public DateTimeOffset Created { get; set; }
        public string CreatedString { get { return Created.DateTime.ToString(); } }

        public DateTimeOffset? Made { get; set; }
        public bool IsMade { get { return Made.HasValue; } }
        public string MadeString { get { return Made.HasValue ? Made.Value.DateTime.ToString() : string.Empty; } }

        public DateTimeOffset? Notified { get; set; }
        public bool IsNotified { get { return Notified.HasValue; } }
        public string NotifiedString { get { return IsNotified ? Notified.Value.DateTime.ToString() : string.Empty; } }

        public bool IsSandbox { get; set; }
        public string Phone { get; set; }

        public string FullText { get; set; }

        public string Note { get; set; }

        public List<square.OrderLineItem> LineItems = new List<square.OrderLineItem>();
        

        public OrderModel() { }

        public OrderModel(Order model, int timezoneOffset = 0)
        {
            Id = model.Id;
            OrderType = model.OrderType;
            Name = model.CreatedBy;
            Email = model.Email;
            Phone = model.Phone;
            Address = model.Address;
            TransactionId = model.TransactionId;
            TotalInCents = model.TotalInCents;
            TaxInCents = model.TaxInCents;
            IsSandbox = model.IsSandbox;
            FullText = model.FullText;
            Created = model.Created;
            Made = model.Made;
            Notified = model.Notified;

            AdjustTimeZone(timezoneOffset);
        }

        public void AdjustTimeZone(int hours)
        {
            Created = Created.AddHours(hours);
            if (Made.HasValue) Made = Made.Value.AddHours(hours);
            if (Notified.HasValue) Notified = Notified.Value.AddHours(hours);
        }

        public Order ToModel()
        {
            throw new NotImplementedException();
        }
    }
}
