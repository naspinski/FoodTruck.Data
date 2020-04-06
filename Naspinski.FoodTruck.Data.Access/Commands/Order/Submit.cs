using Microsoft.EntityFrameworkCore;
using Naspinski.Data.CommandQuery.Base;
using Naspinski.FoodTruck.Data.Access.AdditionalModels;
using Naspinski.FoodTruck.Data.Models.Payment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Naspinski.FoodTruck.Data.Access.Commands.Orders
{
    public class Submit : ResultCommandBase<FoodTruckContext, Order>
    {
        private readonly string _orderType;
        private readonly string _email;
        private readonly string _phone;
        private readonly string _address;
        private readonly string _note;
        private readonly string _pickUpInMinutes;
        private readonly bool _isSandbox;
        private readonly bool _deferSave;
        private readonly decimal _taxRate;
        private readonly IEnumerable<PaymentModelItem> _items;

        public Submit(FoodTruckContext context, string orderType, PaymentModel model, decimal tax, bool isProduction, string address = "", bool defereSave = false) : base(context, model.Email)
        {
            _orderType = orderType;
            _email = model.Email;
            _phone = string.IsNullOrEmpty(model.Phone) ? string.Empty : Regex.Match(model.Phone, "^[0-9]+$").Value;
            _address = string.Empty;
            _note = model.Note;
            _pickUpInMinutes = model.PickUpInMinutes;
            _taxRate = tax / 100;
            _isSandbox = !isProduction;
            _deferSave = defereSave;
            _items = model.Items;
        }

        protected override Order InternalExecute()
        {
            var order = new Order()
            {
                OrderType = _orderType,
                Email = _email,
                Phone = _phone,                
                Address = _address,
                Note = _note,
                PickUpInMinutes = _pickUpInMinutes,
                IsSandbox = _isSandbox
            };
            order.Create(_user);
            _context.Orders.Add(order);


            var priceIds = _items.Select(x => x.PriceId).Distinct().ToList();
            var prices = _context.Prices
                .Include(x => x.MenuItem)
                .Include(x => x.PriceType)
                .Where(x => priceIds.Contains(x.Id)).ToList();

            foreach (var item in _items)
            {
                var price = prices.First(x => x.Id == item.PriceId);
                order.TotalInCents += Convert.ToInt32(price.Amount * item.Quantity * 100);
                var priceTypeString = price.PriceType != null && !string.IsNullOrWhiteSpace(price.PriceType.Name) ? $": {price.PriceType.Name}" : string.Empty;
                var orderItem = new OrderItem()
                {
                    Order = order,
                    Quantity = item.Quantity,
                    PriceId = item.PriceId,
                    Price = price,
                    Description = $"{price.MenuItem.Name}{priceTypeString}",
                    Note = item.Note
                };
                _context.OrderItems.Add(orderItem);
            }
            
            order.TaxInCents = Convert.ToInt32(Convert.ToDecimal(order.TotalInCents) * _taxRate);
            
            order.SetFullText();

            order.TaxRate = _taxRate;
            if(!_deferSave)
                _context.SaveChanges();
            
            return order;
        }
    }
}
