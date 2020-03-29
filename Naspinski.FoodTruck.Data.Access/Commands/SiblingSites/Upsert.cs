using Naspinski.Data.CommandQuery.Base;
using Naspinski.FoodTruck.Data.Access.Queries.SiblingSites;
using Naspinski.FoodTruck.Data.Models.System;

namespace Naspinski.FoodTruck.Data.Access.Commands.SiblingSites
{
    public class Upsert : ResultCommandBase<FoodTruckContext, SiblingSite>
    {
        private readonly SiblingSite _model;

        public Upsert(FoodTruckContext context, string user, SiblingSite model) : base(context, user)
        {
            _model = model;
        }

        protected override SiblingSite InternalExecute()
        {
            var isNew = _model.Id == 0;

            var upsert = isNew ? new SiblingSite() : new Get(_context, _model.Id).ExecuteAndReturnResults();

            upsert.Name = _model.Name;
            upsert.Url = _model.Url;

            if (isNew)
            {
                upsert.Create(_user);
                _context.SiblingSites.Add(upsert);
            }
            else upsert.Update(_user);
            _context.SaveChanges();
            
            return upsert;
        }
    }
}
