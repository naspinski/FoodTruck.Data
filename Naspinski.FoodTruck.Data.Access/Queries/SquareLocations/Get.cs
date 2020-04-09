using Naspinski.Data.CommandQuery.Base;
using Naspinski.FoodTruck.Data.Models.System;
using System.Linq;

namespace Naspinski.FoodTruck.Data.Access.Queries.SquareLocations
{
    public class Get : ResultQueryBase<FoodTruckContext, SquareLocation>
    {
        private readonly int _id;

        public Get(FoodTruckContext context, int id) : base(context)
        {
            _id = id;
        }

        protected override SquareLocation InternalExecute()
        {
            return _context.SquareLocations
                .SingleOrDefault(x => x.Id == _id);
        }
    }
}
