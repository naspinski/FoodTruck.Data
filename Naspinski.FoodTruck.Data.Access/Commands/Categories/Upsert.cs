using Naspinski.Data.CommandQuery.Base;
using Naspinski.FoodTruck.Data.Access.Queries.Categories;
using Naspinski.FoodTruck.Data.Models.Menu;

namespace Naspinski.FoodTruck.Data.Access.Commands.Categories
{
    public class Upsert : ResultCommandBase<FoodTruckContext, Category>
    {
        private readonly Category _model;

        public Upsert(FoodTruckContext context, string user, Category model) : base(context, user)
        {
            _model = model;
        }

        protected override Category InternalExecute()
        {
            var isNew = _model.Id == 0;

            var upsert = isNew ? new Category() : new Get(_context, _model.Id).ExecuteAndReturnResults();

            upsert.Name = _model.Name;
            upsert.Description = _model.Description;
            upsert.SortOrder = _model.SortOrder;
            upsert.ExcludeFromMenu = _model.ExcludeFromMenu;
            upsert.ExcludeFromOrdering = _model.ExcludeFromOrdering;

            if (isNew)
            {
                upsert.Create(_user);
                _context.Categories.Add(upsert);
            }
            else upsert.Update(_user);

            _context.SaveChanges();
            return upsert;
        }
    }
}
