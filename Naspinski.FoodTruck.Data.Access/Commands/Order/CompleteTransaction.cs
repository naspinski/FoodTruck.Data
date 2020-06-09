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
        private readonly string _squareOrderId;

        public CompleteTransaction(FoodTruckContext context, int orderId, string transactionId, string squareOrderId) : base(context, "system")
        {
            _orderId = orderId;
            _transactionId = transactionId;
            _squareOrderId = squareOrderId;
        }

        protected override Order InternalExecute()
        {
            var order = _context.Orders.First(x => x.Id == _orderId);
            order.TransactionId = _transactionId;
            order.SquareOrderId = _squareOrderId;
            order.Update(_user);
            _context.SaveChanges();
            return order;
        }
    }
}
