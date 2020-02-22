using Naspinski.Data.CommandQuery.Base;
using Naspinski.FoodTruck.Data.Models.Menu;

namespace Naspinski.FoodTruck.Data.Access.Commands.ComboParts
{
    public class Upsert : ResultCommandBase<FoodTruckContext, ComboPart>
    {
        private readonly ComboPart _model;

        public Upsert(FoodTruckContext context, string user, ComboPart model) : base(context, user)
        {
            _model = model;
        }

        protected override ComboPart InternalExecute()
        {
            var isNew = _model.Id == 0;

            var upsert = isNew ? new ComboPart() : _model;
            
            upsert.CategoryId = _model.CategoryId;
            upsert.MenuItemId = _model.MenuItemId;

            if (isNew)
            {
                upsert.Create(_user);
                _context.ComboParts.Add(upsert);
            }
            else upsert.Update(_user);
            
            return upsert;
        }
    }
}
