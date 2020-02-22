using Naspinski.Data.CommandQuery.Base;
using Naspinski.FoodTruck.Data.Access.Queries.ComboParts;
using Naspinski.FoodTruck.Data.Models.Menu;

namespace Naspinski.FoodTruck.Data.Access.Commands.ComboParts
{
    public class Delete : ResultCommandBase<FoodTruckContext, ComboPart>
    {
        private readonly ComboPart _comboPart;
        private readonly int _id;

        public Delete(FoodTruckContext context, string user, ComboPart comboPart) : base(context, user)
        {
            _comboPart = comboPart;
        }
        public Delete(FoodTruckContext context, string user, int id) : base(context, user)
        {
            _id = id;
        }

        protected override ComboPart InternalExecute()
        {
            var delete = _comboPart == null ? new Get(_context, _id).ExecuteAndReturnResults() : _comboPart;
            delete.Delete(_user);
            if (_id > 0) _context.SaveChanges();
            return delete;
        }
    }
}
