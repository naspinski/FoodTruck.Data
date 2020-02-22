using Naspinski.Data.CommandQuery.Base;
using Naspinski.FoodTruck.Data.Access.Queries.Categories;
using Naspinski.FoodTruck.Data.Models.Menu;

namespace Naspinski.FoodTruck.Data.Access.Commands.Categories
{
    public class Delete : ResultCommandBase<FoodTruckContext, Category>
    {
        private readonly int _id;

        public Delete(FoodTruckContext context, string user, int id) : base(context, user)
        {
            _id = id;
        }

        protected override Category InternalExecute()
        {
            var delete = new Get(_context, _id).ExecuteAndReturnResults();
            delete.Delete(_user);
            _context.SaveChanges();
            return delete;
        }
    }
}
