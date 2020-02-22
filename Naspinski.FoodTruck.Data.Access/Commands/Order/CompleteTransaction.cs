using Naspinski.Data.CommandQuery.Base;
using Naspinski.FoodTruck.Data.Models.Payment;
using System;
using System.Linq;

namespace Naspinski.FoodTruck.Data.Access.Commands.Orders
{
    public class CompleteTransaction : ResultCommandBase<FoodTruckContext, Order>
    {
        private readonly int _orderId;
        private readonly string _transactionId;

        public CompleteTransaction(FoodTruckContext context, int orderId, string transactionId) : base(context, "system")
        {
            _orderId = orderId;
            _transactionId = transactionId;
        }

        protected override Order InternalExecute()
        {
            var order = _context.Orders.First(x => x.Id == _orderId);
            order.TransactionId = _transactionId;
            order.Update(_user);
            _context.SaveChanges();
            return order;
        }
    }
}
