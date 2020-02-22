using Naspinski.Data.CommandQuery.Base;
using Naspinski.FoodTruck.Data.Access.Queries.Documents;
using Naspinski.FoodTruck.Data.Models.Storage;

namespace Naspinski.FoodTruck.Data.Access.Commands.Documents
{
    public class DeleteRestore : ResultCommandBase<FoodTruckContext, Document>
    {
        private readonly int _id;
        private readonly bool _isRestore;

        public DeleteRestore(FoodTruckContext context, string user, int id, bool isRestore) : base(context, user)
        {
            _id = id;
            _isRestore = isRestore;
        }

        protected override Document InternalExecute()
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
