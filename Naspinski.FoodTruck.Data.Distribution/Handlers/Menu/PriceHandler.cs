using Naspinski.Data.Interfaces;
using Naspinski.FoodTruck.Data.Distribution.Models.Menu;
using System.Collections.Generic;
using Command = Naspinski.FoodTruck.Data.Access.Commands;

namespace Naspinski.FoodTruck.Data.Distribution.Handlers.Menu
{
    public class PriceHandler : ICrudHandler<PriceModel, FoodTruckContext, PriceModel>
    {
        private FoodTruckContext _context;
        private string _user;

        public PriceHandler(FoodTruckContext context, string user)
        {
            _context = context;
            _user = user;
        }

        public void Delete(int id)
        {
            new Command.Prices.Delete(_context, _user, id).Execute();
        }

        public PriceModel Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<PriceModel> GetAll(bool isDeleted = false)
        {
            throw new System.NotImplementedException();
        }

        public void Restore(int id)
        {
            throw new System.NotImplementedException();
        }

        public PriceModel Upsert(PriceModel model)
        {
            throw new System.NotImplementedException();
        }
    }
}
