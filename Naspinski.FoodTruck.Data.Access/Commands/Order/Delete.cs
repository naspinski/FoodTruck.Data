using Naspinski.Data.CommandQuery.Base;
using Naspinski.FoodTruck.Data.Access.Queries.Orders;
using Naspinski.FoodTruck.Data.Models.Payment;

namespace Naspinski.FoodTruck.Data.Access.Commands.Orders
{
    public class Delete : ResultCommandBase<FoodTruckContext, Order>
    {
        private readonly Order _order;
        private readonly int _id;

        public Delete(FoodTruckContext context, string user, Order order) : base(context, user)
        {
            _order = order;
        }
        public Delete(FoodTruckContext context, string user, int id) : base(context, user)
        {
            _id = id;
        }

        protected override Order InternalExecute()
        {
            var delete = _order == null ? new Get(_context, _id).ExecuteAndReturnResults() : _order;
            delete.Delete(_user);
            if (_id > 0) _context.SaveChanges();
            return delete;
        }
    }
}
