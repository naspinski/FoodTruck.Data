using Naspinski.Data.Interfaces;
using Naspinski.FoodTruck.Data.Distribution.Models.Menu;
using System.Collections.Generic;
using System.Linq;
using Command = Naspinski.FoodTruck.Data.Access.Commands;
using Query = Naspinski.FoodTruck.Data.Access.Queries;

namespace Naspinski.FoodTruck.Data.Distribution.Handlers.Menu
{
    public class MenuItemHandler : ICrudHandler<MenuItemModel, FoodTruckContext, MenuItemModel>
    {
        private FoodTruckContext _context;
        private string _user;

        public MenuItemHandler(FoodTruckContext context, string user)
        {
            _context = context;
            _user = user;
        }
        public MenuItemModel Get(int id)
        {
            return id == 0 ? new MenuItemModel() : new MenuItemModel(new Query.MenuItems.Get(_context, id).ExecuteAndReturnResults());
        }

        public IEnumerable<MenuItemModel> GetAll(bool isDeleted = false)
        {
            return new Query.MenuItems.GetAll(_context, true, isDeleted).ExecuteAndReturnResults().Select(x => new MenuItemModel(x));
        }

        public IEnumerable<MenuItemModel> GetAllWithoutDetails(bool isDeleted = false)
        {
            return new Query.MenuItems.GetAll(_context, false, isDeleted).ExecuteAndReturnResults().Select(x => new MenuItemModel(x));
        }

        public MenuItemModel Upsert(MenuItemModel model)
        {
            return new MenuItemModel(new Command.MenuItems.Upsert(_context, _user, model.ToModel()).ExecuteAndReturnResults());
        }

        public void Delete(int id)
        {
            new Command.MenuItems.DeleteRestore(_context, _user, id, false).Execute();
        }

        public void Restore(int id)
        {
            new Command.MenuItems.DeleteRestore(_context, _user, id, true).Execute();
        }
    }
}
