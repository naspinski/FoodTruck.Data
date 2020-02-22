using Naspinski.Data.CommandQuery.Base;
using Naspinski.FoodTruck.Data.Models.Menu;
using System.Linq;

namespace Naspinski.FoodTruck.Data.Access.Queries.ComboParts
{
    public class Get : ResultQueryBase<FoodTruckContext, ComboPart>
    {
        private readonly int _id;

        public Get(FoodTruckContext context, int id) : base(context)
        {
            _id = id;
        }

        protected override ComboPart InternalExecute()
        {
            return _context.ComboParts.SingleOrDefault(x => x.Id == _id);
        }
    }
}
