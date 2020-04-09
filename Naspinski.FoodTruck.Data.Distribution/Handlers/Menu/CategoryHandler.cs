using Naspinski.Data.Interfaces;
using Naspinski.FoodTruck.Data.Distribution.Models.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using Command = Naspinski.FoodTruck.Data.Access.Commands;
using Query = Naspinski.FoodTruck.Data.Access.Queries;

namespace Naspinski.FoodTruck.Data.Distribution.Handlers.Menu
{
    public class CategoryHandler : ICrudHandler<CategoryModel, FoodTruckContext, CategoryModel>
    {
        private FoodTruckContext _context;
        private string _user;

        public CategoryHandler(FoodTruckContext context, string user)
        {
            _context = context;
            _user = user;
        }
        public CategoryModel Get(int id)
        {
            return id == 0 ? new CategoryModel() : new CategoryModel(new Query.Categories.Get(_context, id).ExecuteAndReturnResults());
        }

        public IEnumerable<CategoryModel> GetAll(bool isDeleted = false)
        {
            return new Query.Categories.GetAll(_context, isDeleted).ExecuteAndReturnResults()
                .Select(x => new CategoryModel(x)).OrderBy(x => x.SortOrder);
        }

        public CategoryModel Upsert(CategoryModel model)
        {
            return new CategoryModel(new Command.Categories.Upsert(_context, _user, model.ToModel()).ExecuteAndReturnResults());
        }

        public void Delete(int id)
        {
            new Command.Categories.Delete(_context, _user, id).Execute();
        }

        public void Restore(int id)
        {
            throw new NotImplementedException();
        }
    }
}
