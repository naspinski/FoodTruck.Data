using Naspinski.Data.CommandQuery.Base;
using Naspinski.FoodTruck.Data.Access.Queries.Events;
using Naspinski.FoodTruck.Data.Models.Events;

namespace Naspinski.FoodTruck.Data.Access.Commands.Events
{
    public class DeleteRestore : ResultCommandBase<FoodTruckContext, Event>
    {
        private readonly int _id;
        private readonly bool _isRestore;

        public DeleteRestore(FoodTruckContext context, string user, int id, bool isRestore) : base(context, user)
        {
            _id = id;
            _isRestore = isRestore;
        }

        protected override Event InternalExecute()
        {
            var entity = new Get(_context, _id).ExecuteAndReturnResults();
            if (_isRestore)
                entity.Restore(_user);
            else
                entity.Delete(_user);
            _context.SaveChanges();
            return entity;
        }
    }
}
