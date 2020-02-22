using Naspinski.Data.CommandQuery.Base;
using Naspinski.FoodTruck.Data.Models.Menu;

namespace Naspinski.FoodTruck.Data.Access.Commands.Prices
{
    public class Upsert : ResultCommandBase<FoodTruckContext, Price>
    {
        private readonly Price _model;

        public Upsert(FoodTruckContext context, string user, Price model) : base(context, user)
        {
            _model = model;
        }

        protected override Price InternalExecute()
        {
            var isNew = _model.Id == 0;

            var upsert = isNew ? new Price() : _model;

            upsert.Amount = _model.Amount;
            upsert.MenuItemId = _model.MenuItemId;
            upsert.PriceTypeId = _model.PriceTypeId > 0 ? _model.PriceTypeId : null;

            if (isNew)
            {
                upsert.Create(_user);
                _context.Prices.Add(upsert);
            }
            else upsert.Update(_user);
            
            return upsert;
        }
    }
}
