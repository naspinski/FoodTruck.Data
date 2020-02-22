using Naspinski.Data.CommandQuery.Base;
using Naspinski.FoodTruck.Data.Models.Menu;
using System.Linq;

namespace Naspinski.FoodTruck.Data.Access.Queries.Prices
{
    public class Get : ResultQueryBase<FoodTruckContext, Price>
    {
        private readonly int _id;

        public Get(FoodTruckContext context, int id) : base(context)
        {
            _id = id;
        }

        protected override Price InternalExecute()
        {
            return _context.Prices.SingleOrDefault(x => x.Id == _id);
        }
    }
}
