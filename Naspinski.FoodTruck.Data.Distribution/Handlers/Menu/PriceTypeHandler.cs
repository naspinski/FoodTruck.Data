using Naspinski.Data.Interfaces;
using Naspinski.FoodTruck.Data.Distribution.Models.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using Command = Naspinski.FoodTruck.Data.Access.Commands;
using Query = Naspinski.FoodTruck.Data.Access.Queries;

namespace Naspinski.FoodTruck.Data.Distribution.Handlers.Menu
{
    public class PriceTypeHandler : ICrudHandler<PriceTypeModel, FoodTruckContext, PriceTypeModel>
    {
        private FoodTruckContext _context;
        private string _user;

        public PriceTypeHandler(FoodTruckContext context, string user)
        {
            _context = context;
            _user = user;
        }
        public PriceTypeModel Get(int id)
        {
            return id == 0 ? new PriceTypeModel() : new PriceTypeModel(new Query.PriceTypes.Get(_context, id).ExecuteAndReturnResults());
        }

        public IEnumerable<PriceTypeModel> GetAll(bool isDeleted = false)
        {
            return new Query.PriceTypes.GetAll(_context, isDeleted).ExecuteAndReturnResults()
                .Select(x => new PriceTypeModel(x)).OrderBy(x => x.SortOrder);
        }

        public PriceTypeModel Upsert(PriceTypeModel model)
        {
            return new PriceTypeModel(new Command.PriceTypes.Upsert(_context, _user, model.ToModel()).ExecuteAndReturnResults());
        }

        public void Delete(int id)
        {
            new Command.PriceTypes.Delete(_context, _user, id).Execute();
        }

        public void Restore(int id)
        {
            throw new NotImplementedException();
        }
    }
}
