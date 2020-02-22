using Naspinski.Data.CommandQuery.Base;
using Naspinski.FoodTruck.Data.Access.Queries.Prices;
using Naspinski.FoodTruck.Data.Models.Menu;

namespace Naspinski.FoodTruck.Data.Access.Commands.Prices
{
    public class Delete : ResultCommandBase<FoodTruckContext, Price>
    {
        private readonly Price _price;
        private readonly int _id;

        public Delete(FoodTruckContext context, string user, Price price) : base(context, user)
        {
            _price = price;
        }
        public Delete(FoodTruckContext context, string user, int id) : base(context, user)
        {
            _id = id;
        }

        protected override Price InternalExecute()
        {
            var delete = _price == null ? new Get(_context, _id).ExecuteAndReturnResults() : _price;
            delete.Delete(_user);
            if (_id > 0) _context.SaveChanges();
            return delete;
        }
    }
}
