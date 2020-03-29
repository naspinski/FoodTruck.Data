using Naspinski.Data.Interfaces;
using Naspinski.FoodTruck.Data.Distribution.Models.System;
using Naspinski.FoodTruck.Data.Models.System;
using System.Collections.Generic;
using System.Linq;
using Command = Naspinski.FoodTruck.Data.Access.Commands;
using Query = Naspinski.FoodTruck.Data.Access.Queries;

namespace Naspinski.FoodTruck.Data.Distribution.Handlers.Menu
{
    public class SiblingSiteHandler : ICrudHandler<SiblingSiteModel, FoodTruckContext, SiblingSiteModel>
    {
        private FoodTruckContext _context;
        private string _user;

        public SiblingSiteHandler(FoodTruckContext context, string user)
        {
            _context = context;
            _user = user;
        }
        public SiblingSiteModel Get(int id)
        {
            return id == 0 ? new SiblingSiteModel() : new SiblingSiteModel(new Query.SiblingSites.Get(_context, id).ExecuteAndReturnResults());
        }

        public IEnumerable<SiblingSiteModel> GetAll(bool isDeleted = false)
        {
            return new Query.SiblingSites.GetAll(_context, isDeleted).ExecuteAndReturnResults().Select(x => new SiblingSiteModel(x)).OrderBy(x => x.Name);
        }

        public SiblingSiteModel Upsert(SiblingSiteModel model)
        {
            return new SiblingSiteModel(new Command.SiblingSites.Upsert(_context, _user, model.ToModel()).ExecuteAndReturnResults());
        }

        public void Delete(int id)
        {
            new Command.SiblingSites.DeleteRestore(_context, _user, id, false).Execute();
        }

        public void Restore(int id)
        {
            new Command.SiblingSites.DeleteRestore(_context, _user, id, true).Execute();
        }
    }
}
