using Naspinski.Data.CommandQuery.Base;
using Naspinski.FoodTruck.Data.Models.Events;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Naspinski.FoodTruck.Data.Access.Queries.Events
{
    public class Get : ResultQueryBase<FoodTruckContext, Event>
    {
        private readonly int _id;

        public Get(FoodTruckContext context, int id) : base(context)
        {
            _id = id;
        }

        protected override Event InternalExecute()
        {
            return _context.Events.Include(x => x.Location).SingleOrDefault(x => x.Id == _id);
        }
    }
}
