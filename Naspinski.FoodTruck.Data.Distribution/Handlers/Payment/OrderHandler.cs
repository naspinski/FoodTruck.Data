using Naspinski.Data.Interfaces;
using Naspinski.FoodTruck.Data.Access.AdditionalModels;
using Naspinski.FoodTruck.Data.Access.Commands.Orders;
using Naspinski.FoodTruck.Data.Access.Queries.Orders;
using Naspinski.FoodTruck.Data.Distribution.Models.Orders;
using Naspinski.FoodTruck.Data.Models.Payment;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Naspinski.FoodTruck.Data.Distribution.Handlers.Payment
{
    public class OrderHandler: ICrudHandler<OrderModel, FoodTruckContext, OrderModel>
    {
        private FoodTruckContext _context;
        private string _user;

        public OrderHandler(FoodTruckContext context, string user)
        {
            _context = context;
            _user = user;
        }

        public void Delete(int id)
        {
            new Delete(_context, _user, id).Execute();
        }

        public OrderModel Get(int id) { throw new NotImplementedException(); }


        public OrderModel Get(int id, int timezoneOffset)
        {
            return new OrderModel(new Get(_context, id).ExecuteAndReturnResults(), timezoneOffset);
        }

        public IEnumerable<OrderModel> GetAll(DateTimeOffset begins, DateTimeOffset? ends = null, bool isDeleted = false, bool isSandbox = false, bool showMade = false, int timezoneOffset = 0)
        {
            begins = begins.AddHours(0 - timezoneOffset);
            if (ends.HasValue) ends = ends.Value.AddHours(6);

            return new GetAll(_context, begins, ends, isDeleted, isSandbox, showMade).ExecuteAndReturnResults()
                .Select(x => new OrderModel(x, timezoneOffset)).OrderByDescending(x => x.Created);
        }

        public IEnumerable<OrderModel> GetAll(bool isDeleted = false)
        {
            throw new NotImplementedException();
        }

        [Obsolete("use new constructor now utilizing PriceAndQuantity")]
        public Order Submit(string orderType, string name, string email, string phone, string address, string note, IEnumerable<PriceAndQuantity> priceAndQuantity, decimal tax, bool isProduction, bool deferSave = false)
        {
            return new Submit(_context, orderType, name, email, phone, address, note, priceAndQuantity, tax, isProduction, deferSave).ExecuteAndReturnResults();    
        }

        public Order Submit(string orderType, string name, string email, string phone, string note, IEnumerable<PaymentModelItem> items, decimal tax, bool isProduction, string address = "", bool deferSave = false)
        {
            return new Submit(_context, orderType, name, email, phone, address, note, items, tax, isProduction, deferSave).ExecuteAndReturnResults();
        }

        public Order TransactionApproved(int orderId, string transactionId)
        {
            return new CompleteTransaction(_context, orderId, transactionId).ExecuteAndReturnResults();
        }

        public OrderModel Upsert(OrderModel model)
        {
            throw new NotImplementedException();
        }

        public Order Made(int id)
        {
            return Made(new Get(_context, id).ExecuteAndReturnResults());
        }

        public Order Made(Order order)
        {
            order.Made = DateTime.UtcNow;
            _context.SaveChanges();
            return order;
        }

        public Order Notify(int id)
        {
            return Notify(new Get(_context, id).ExecuteAndReturnResults());
        }

        public Order Notify(Order order)
        {
            order.Notified = DateTime.UtcNow;
            _context.SaveChanges();
            return order;
        }

        public void Restore(int id)
        {
            throw new NotImplementedException();
        }
    }
}
