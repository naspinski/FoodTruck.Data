using Naspinski.Data.Interfaces;
using Naspinski.FoodTruck.Data.Distribution.Models.System;
using System.Collections.Generic;
using System.Linq;
using Command = Naspinski.FoodTruck.Data.Access.Commands;
using Query = Naspinski.FoodTruck.Data.Access.Queries;

namespace Naspinski.FoodTruck.Data.Distribution.Handlers.Menu
{
    public class ImageHandler : ICrudHandler<ImageModel, FoodTruckContext, ImageModel>
    {
        private FoodTruckContext _context;
        private string _user;

        public ImageHandler(FoodTruckContext context, string user)
        {
            _context = context;
            _user = user;
        }
        public ImageModel Get(int id)
        {
            return id == 0 ? new ImageModel() : new ImageModel(new Query.Images.Get(_context, id).ExecuteAndReturnResults());
        }

        public IEnumerable<ImageModel> GetAll(bool isDeleted = false)
        {
            return new Query.Images.GetAll(_context, isDeleted).ExecuteAndReturnResults().Select(x => new ImageModel(x)).OrderBy(x => x.Name);
        }

        public ImageModel Upsert(ImageModel model)
        {
            return new ImageModel(new Command.Images.Upsert(_context, _user, model.ToModel()).ExecuteAndReturnResults());
        }

        public void Delete(int id)
        {
            new Command.Images.DeleteRestore(_context, _user, id, false).Execute();
        }

        public void Restore(int id)
        {
            new Command.Images.DeleteRestore(_context, _user, id, true).Execute();
        }
    }
}
