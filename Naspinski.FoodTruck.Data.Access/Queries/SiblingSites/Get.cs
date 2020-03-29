using Naspinski.Data.CommandQuery.Base;
using Naspinski.FoodTruck.Data.Models.System;
using System.Linq;

namespace Naspinski.FoodTruck.Data.Access.Queries.SiblingSites
{
    public class Get : ResultQueryBase<FoodTruckContext, SiblingSite>
    {
        private readonly int _id;

        public Get(FoodTruckContext context, int id) : base(context)
        {
            _id = id;
        }

        protected override SiblingSite InternalExecute()
        {
            return _context.SiblingSites
                .SingleOrDefault(x => x.Id == _id);
        }
    }
}
