using Naspinski.Data.CommandQuery.Base;
using Naspinski.FoodTruck.Data.Access.Queries.Images;
using Naspinski.FoodTruck.Data.Models.Storage;

namespace Naspinski.FoodTruck.Data.Access.Commands.Images
{
    public class Upsert : ResultCommandBase<FoodTruckContext, Image>
    {
        private readonly Image _model;

        public Upsert(FoodTruckContext context, string user, Image model) : base(context, user)
        {
            _model = model;
        }

        protected override Image InternalExecute()
        {
            var isNew = _model.Id == 0;

            var upsert = isNew ? new Image() : new Get(_context, _model.Id).ExecuteAndReturnResults();

            upsert.Name = _model.Name;
            upsert.Location = _model.Location;

            if (isNew)
            {
                upsert.Create(_user);
                _context.Images.Add(upsert);
            }
            else upsert.Update(_user);

            _context.SaveChanges();
            return upsert;
        }
    }
}
