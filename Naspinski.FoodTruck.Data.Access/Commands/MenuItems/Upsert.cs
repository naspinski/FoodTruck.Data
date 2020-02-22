using Naspinski.Data.CommandQuery.Base;
using Naspinski.FoodTruck.Data.Access.Queries.MenuItems;
using Naspinski.FoodTruck.Data.Models.Menu;
using System.Linq;

namespace Naspinski.FoodTruck.Data.Access.Commands.MenuItems
{
    public class Upsert : ResultCommandBase<FoodTruckContext, MenuItem>
    {
        private readonly MenuItem _model;

        public Upsert(FoodTruckContext context, string user, MenuItem model) : base(context, user)
        {
            _model = model;
        }

        protected override MenuItem InternalExecute()
        {
            var isNew = _model.Id == 0;

            var upsert = isNew ? new MenuItem() : new Get(_context, _model.Id).ExecuteAndReturnResults();

            upsert.Name = _model.Name;
            upsert.Description = _model.Description;
            upsert.CategoryId = _model.CategoryId;
            upsert.ImageId = _model.ImageId;
            upsert.SortOrder = _model.SortOrder;
            upsert.ItemId = _model.ItemId;

            if (isNew)
            {
                upsert.Create(_user);
                _context.MenuItems.Add(upsert);
            }
            else upsert.Update(_user);
            _context.SaveChanges();

            upsert = new Get(_context, upsert.Id).ExecuteAndReturnResults();

            /// PRICES
            //delete old prices
            var existingIdsInModel = _model.Prices.Select(y => y.Id);
            upsert.Prices.Where(x => !existingIdsInModel.Contains(x.Id)).ToList()
                .ForEach(x => new Prices.Delete(_context, _user, x).Execute());

            // update existing prices
            upsert.Prices.Where(x => existingIdsInModel.Contains(x.Id)).ToList().ForEach((x) => {
                var p = _model.Prices.First(y => y.Id == x.Id);
                x.Amount = p.Amount;
                x.PriceTypeId = p.PriceTypeId;
                new Prices.Upsert(_context, _user, x).Execute();
            });

            //insert new prices
            _model.Prices.Where(x => x.Id == 0).ToList().ForEach((x) => {
                x.MenuItemId = upsert.Id;
                new Prices.Upsert(_context, _user, x).Execute();
            });

            ///COMBO
            //delete old comboParts
            existingIdsInModel = _model.ComboParts.Select(y => y.Id);
            upsert.ComboParts.Where(x => !existingIdsInModel.Contains(x.Id)).ToList()
                .ForEach(x => new ComboParts.Delete(_context, _user, x).Execute());

            // update existing prices
            upsert.ComboParts.Where(x => existingIdsInModel.Contains(x.Id)).ToList().ForEach((x) => {
                var c = _model.ComboParts.First(y => y.Id == x.Id);
                x.CategoryId = c.CategoryId;
                new ComboParts.Upsert(_context, _user, x).Execute();
            });

            //insert new prices
            _model.ComboParts.Where(x => x.Id == 0).ToList().ForEach((x) => {
                x.MenuItemId = upsert.Id;
                new ComboParts.Upsert(_context, _user, x).Execute();
            });

            _context.SaveChanges();

            return upsert;
        }
    }
}
