using Naspinski.Data.CommandQuery.Base;
using Naspinski.FoodTruck.Data.Access.Queries.PriceTypes;
using Naspinski.FoodTruck.Data.Models.Menu;

namespace Naspinski.FoodTruck.Data.Access.Commands.PriceTypes
{
    public class Upsert : ResultCommandBase<FoodTruckContext, PriceType>
    {
        private readonly PriceType _model;

        public Upsert(FoodTruckContext context, string user, PriceType model) : base(context, user)
        {
            _model = model;
        }

        protected override PriceType InternalExecute()
        {
            var isNew = _model.Id == 0;

            var upsert = isNew ? new PriceType() : new Get(_context, _model.Id).ExecuteAndReturnResults();

            upsert.Name = _model.Name;
            upsert.SortOrder = _model.SortOrder;

            if (isNew)
            {
                upsert.Create(_user);
                _context.PriceTypes.Add(upsert);
            }
            else upsert.Update(_user);

            _context.SaveChanges();
            return upsert;
        }
    }
}
