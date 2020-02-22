using Naspinski.Data.CommandQuery.Base;
using Naspinski.FoodTruck.Data.Access.Queries.PriceTypes;
using Naspinski.FoodTruck.Data.Models.Menu;

namespace Naspinski.FoodTruck.Data.Access.Commands.PriceTypes
{
    public class Delete : ResultCommandBase<FoodTruckContext, PriceType>
    {
        private readonly int _id;

        public Delete(FoodTruckContext context, string user, int id) : base(context, user)
        {
            _id = id;
        }

        protected override PriceType InternalExecute()
        {
            var delete = new Get(_context, _id).ExecuteAndReturnResults();
            delete.Delete(_user);
            _context.SaveChanges();
            return delete;
        }
    }
}
