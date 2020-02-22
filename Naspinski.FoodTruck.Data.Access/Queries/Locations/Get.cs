using Naspinski.Data.CommandQuery.Base;
using Naspinski.FoodTruck.Data.Models.Events;
using System.Linq;

namespace Naspinski.FoodTruck.Data.Access.Queries.Locations
{
    public class Get : ResultQueryBase<FoodTruckContext, Location>
    {
        private readonly int _id;

        public Get(FoodTruckContext context, int id) : base(context)
        {
            _id = id;
        }

        protected override Location InternalExecute()
        {
            return _context.Locations.SingleOrDefault(x => x.Id == _id);
        }
    }
}
