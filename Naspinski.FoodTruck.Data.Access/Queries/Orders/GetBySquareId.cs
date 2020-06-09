using Naspinski.Data.CommandQuery.Base;
using Naspinski.FoodTruck.Data.Models.Payment;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Naspinski.FoodTruck.Data.Access.Queries.Orders
{
    public class GetBySquareId : ResultQueryBase<FoodTruckContext, Order>
    {
        private readonly string _squareOrderId;

        public GetBySquareId(FoodTruckContext context, string squareOrderId) : base(context)
        {
            _squareOrderId = squareOrderId;
        }

        protected override Order InternalExecute()
        {
            return _context.Orders.Include(x => x.Items).SingleOrDefault(x => x.SquareOrderId.Equals(_squareOrderId, System.StringComparison.InvariantCultureIgnoreCase));
        }
    }
}
