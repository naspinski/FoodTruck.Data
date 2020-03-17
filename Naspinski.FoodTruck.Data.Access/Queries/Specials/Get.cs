using Naspinski.Data.CommandQuery.Base;
using Naspinski.FoodTruck.Data.Models.Specials;
using System.Linq;

namespace Naspinski.FoodTruck.Data.Access.Queries.Specials
{
    public class Get : ResultQueryBase<FoodTruckContext, Special>
    {
        private readonly int _id;

        public Get(FoodTruckContext context, int id) : base(context)
        {
            _id = id;
        }

        protected override Special InternalExecute()
        {
            return _context.Specials
                .SingleOrDefault(x => x.Id == _id);
        }
    }
}
