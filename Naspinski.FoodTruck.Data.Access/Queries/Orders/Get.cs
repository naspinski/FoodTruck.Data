using Naspinski.Data.CommandQuery.Base;
using Naspinski.FoodTruck.Data.Models.Payment;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Naspinski.FoodTruck.Data.Access.Queries.Orders
{
    public class Get : ResultQueryBase<FoodTruckContext, Order>
    {
        private readonly int _id;

        public Get(FoodTruckContext context, int id) : base(context)
        {
            _id = id;
        }

        protected override Order InternalExecute()
        {
            return _context.Orders.Include(x => x.Items).SingleOrDefault(x => x.Id == _id);
        }
    }
}
