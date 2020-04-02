using Naspinski.Data.CommandQuery.Base;
using Naspinski.Data.Helpers;
using Naspinski.FoodTruck.Data.Access.AdditionalModels;
using Naspinski.FoodTruck.Data.Models.Payment;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using static Naspinski.FoodTruck.Data.Constants;

namespace Naspinski.FoodTruck.Data.Access.Commands.Orders
{
    public class Submit : ResultCommandBase<FoodTruckContext, Order>
    {
        private readonly string _orderType;
        private readonly string _email;
        private readonly string _phone;
        private readonly string _address;
        private readonly string _note;
        private readonly bool _isSandbox;
        private readonly bool _deferSave;
        private readonly decimal _taxRate;
        private readonly IEnumerable<PriceAndQuantity> _priceAndQuantity;
        private readonly IEnumerable<PaymentModelItem> _items;

        [Obsolete("use new constructor now utilizing PriceAndQuantity")]
        public Submit(FoodTruckContext context, string orderType, string name, string email, string phone, string address, string note, IEnumerable<PriceAndQuantity> priceAndQuantity, decimal tax, bool isProduction, bool defereSave = false) : base(context, name)
        {
            _orderType = orderType;
            _email = email;
            _phone = string.IsNullOrEmpty(phone) ? string.Empty : Regex.Match(phone, "^[0-9]+$").Value;
            _address = address;
            _note = note;
            _taxRate = tax / 100;
            _isSandbox = !isProduction;
            _deferSave = defereSave;
            _priceAndQuantity = priceAndQuantity.OrderByDescending(x => x.Quantity);
        }

        public Submit(FoodTruckContext context, string orderType, string name, string email, string phone, string address, string note, IEnumerable<PaymentModelItem> items, decimal tax, bool isProduction, bool defereSave = false) : base(context, name)
        {
            _orderType = orderType;
            _email = email;
            _phone = string.IsNullOrEmpty(phone) ? string.Empty : Regex.Match(phone, "^[0-9]+$").Value;
            _address = string.Empty;
            _note = note;
            _taxRate = tax / 100;
            _isSandbox = !isProduction;
            _deferSave = defereSave;
            _items = items;
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
                IsSandbox = _isSandbox
            };
            order.Create(_user);
            _context.Orders.Add(order);


            var priceIds = _items.Any() ? _items.Select(x => x.PriceId).Distinct().ToList() : _priceAndQuantity.Select(x => x.PriceId).Distinct().ToList();
            var prices = _context.Prices
                .Include(x => x.MenuItem)
                .Include(x => x.PriceType)
                .Where(x => priceIds.Contains(x.Id)).ToList();


            if (_items.Any())
            {
                foreach (var item in _items)
                {
                    var pq = _items.First(x => x.PriceId == item.PriceId);
                    var price = prices.First(x => x.Id == pq.PriceId);
                    order.TotalInCents += Convert.ToInt32(price.Amount * pq.Quantity * 100);
                    var priceTypeString = price.PriceType != null && !string.IsNullOrWhiteSpace(price.PriceType.Name) ? $": {price.PriceType.Name}" : string.Empty;
                    var orderItem = new OrderItem()
                    {
                        Order = order,
                        Quantity = pq.Quantity,
                        PriceId = pq.PriceId,
                        Price = price,
                        Description = $"[{pq.Quantity}] {price.MenuItem.Name}{priceTypeString} - ${price.Amount * pq.Quantity}"
                    };
                    if (!string.IsNullOrWhiteSpace(item.Note))
                        orderItem.Description += Environment.NewLine + $"   > {item.Note}"; 
                    _context.OrderItems.Add(orderItem);
                }
            }
            else //deprecated method
            {
                foreach (var pAndQ in _priceAndQuantity)
                {
                    var pq = _priceAndQuantity.First(x => x.PriceId == pAndQ.PriceId);
                    var price = prices.First(x => x.Id == pq.PriceId);
                    order.TotalInCents += Convert.ToInt32(price.Amount * pq.Quantity * 100);
                    var priceTypeString = price.PriceType != null && !string.IsNullOrWhiteSpace(price.PriceType.Name) ? $": {price.PriceType.Name}" : string.Empty;
                    var orderItem = new OrderItem()
                    {
                        Order = order,
                        Quantity = pq.Quantity,
                        PriceId = pq.PriceId,
                        Price = price,
                        Description = $"[{pq.Quantity}] {price.MenuItem.Name}{priceTypeString} - ${price.Amount * pq.Quantity}",
                        ComboParts = pAndQ.ComboParts
                    };
                    _context.OrderItems.Add(orderItem);
                }
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
