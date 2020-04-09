using Naspinski.Data.Interfaces;
using Naspinski.FoodTruck.Data.Distribution.Models.System;
using System;
using System.Collections.Generic;
using System.Linq;
using Query = Naspinski.FoodTruck.Data.Access.Queries;
using Command = Naspinski.FoodTruck.Data.Access.Commands;

namespace Naspinski.FoodTruck.Data.Distribution.Handlers.System
{
    public class DeliveryDestinationHandler : ICrudHandler<DeliveryDestinationModel, FoodTruckContext, DeliveryDestinationModel>
    {
        private FoodTruckContext _context;
        private string _user;

        public DeliveryDestinationHandler(FoodTruckContext context, string user)
        {
            _context = context;
            _user = user;
        }

        public IEnumerable<DeliveryDestinationModel> GetAll(bool isDeleted = false)
        {
            return new Query.DeliveryDestinations.GetAll(_context, isDeleted).ExecuteAndReturnResults().Select(x => new DeliveryDestinationModel(x));
        }

        public void Delete(int id)
        {
            new Command.DeliveryDestinations.Delete(_context, _user, id).Execute();
        }

        public DeliveryDestinationModel Upsert(DeliveryDestinationModel model)
        {
            return new DeliveryDestinationModel(new Command.DeliveryDestinations.Upsert(_context, _user, model.ToModel()).ExecuteAndReturnResults());
        }



        public DeliveryDestinationModel Get(int id)
        {
            throw new NotImplementedException();
        }

        public void Restore(int id)
        {
            throw new NotImplementedException();
        }
    }
}
