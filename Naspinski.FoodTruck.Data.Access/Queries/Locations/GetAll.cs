using Naspinski.Data.CommandQuery.Base;
using Naspinski.FoodTruck.Data.Models.Events;
using System.Collections.Generic;
using System.Linq;

namespace Naspinski.FoodTruck.Data.Access.Queries.Locations
{
    public class GetAll : ResultQueryBase<FoodTruckContext, List<Location>>
    {
        private readonly bool _isDeleted;

        public GetAll(FoodTruckContext context, bool isDeleted = false) : base(context)
        {
            _isDeleted = isDeleted;
        }

        protected override List<Location> InternalExecute()
        {
            return _context.Locations.Where(x => x.Deleted.HasValue == _isDeleted).ToList();
        }
    }
}
