using Naspinski.Data.Interfaces;
using Naspinski.FoodTruck.Data.Distribution.Models.Events;
using System.Collections.Generic;
using System.Linq;
using Command = Naspinski.FoodTruck.Data.Access.Commands;
using Query = Naspinski.FoodTruck.Data.Access.Queries;

namespace Naspinski.FoodTruck.Data.Distribution.Handlers.Events
{
    public class LocationHandler : ICrudHandler<LocationModel, FoodTruckContext, LocationModel>
    {
        private FoodTruckContext _context;
        private string _user;

        public LocationHandler(FoodTruckContext context, string user)
        {
            _context = context;
            _user = user;
        }
        public LocationModel Get(int id)
        {
            return id == 0 ? new LocationModel() : new LocationModel(new Query.Locations.Get(_context, id).ExecuteAndReturnResults());
        }

        public IEnumerable<LocationModel> GetAll(bool isDeleted = false)
        {
            return new Query.Locations.GetAll(_context, isDeleted).ExecuteAndReturnResults().Select(x => new LocationModel(x));
        }

        public LocationModel Upsert(LocationModel model)
        {
            return new LocationModel(new Command.Locations.Upsert(_context, _user, model.ToModel()).ExecuteAndReturnResults());
        }

        public void Delete(int id)
        {
            new Command.Locations.DeleteRestore(_context, _user, id, false).Execute();
        }

        public void Restore(int id)
        {
            new Command.Locations.DeleteRestore(_context, _user, id, true).Execute();
        }
    }
}
