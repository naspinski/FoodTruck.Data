using Naspinski.Data.CommandQuery.Base;
using Naspinski.FoodTruck.Data.Access.Queries.Documents;
using Naspinski.FoodTruck.Data.Models.Storage;

namespace Naspinski.FoodTruck.Data.Access.Commands.Documents
{
    public class Upsert : ResultCommandBase<FoodTruckContext, Document>
    {
        private readonly Document _model;

        public Upsert(FoodTruckContext context, string user, Document model) : base(context, user)
        {
            _model = model;
        }

        protected override Document InternalExecute()
        {
            var isNew = _model.Id == 0;

            var upsert = isNew ? new Document() : new Get(_context, _model.Id).ExecuteAndReturnResults();

            upsert.Location = _model.Location;
            upsert.Category = _model.Category;
            upsert.Type = _model.Type;

            if(_model.DeleteAllOthers && !string.IsNullOrEmpty(_model.Category))
            {
                new GetAll(_context, _model.Category).ExecuteAndReturnResults().ForEach(x =>
                    new DeleteRestore(_context, _user, x.Id, false).Execute()
                );
            }

            if (isNew)
            {
                upsert.Create(_user);
                _context.Documents.Add(upsert);
            }
            else upsert.Update(_user);

            _context.SaveChanges();
            return upsert;
        }
    }
}
