using Naspinski.Data.Interfaces;
using Naspinski.FoodTruck.Data.Distribution.Models.System;
using System.Collections.Generic;
using System.Linq;
using Command = Naspinski.FoodTruck.Data.Access.Commands;
using Query = Naspinski.FoodTruck.Data.Access.Queries;

namespace Naspinski.FoodTruck.Data.Distribution.Handlers.System
{
    public class DocumentHandler : ICrudHandler<DocumentModel, FoodTruckContext, DocumentModel>
    {
        private FoodTruckContext _context;
        private string _user;

        public DocumentHandler(FoodTruckContext context, string user)
        {
            _context = context;
            _user = user;
        }
        public DocumentModel Get(int id)
        {
            return id == 0 ? new DocumentModel() : new DocumentModel(new Query.Documents.Get(_context, id).ExecuteAndReturnResults());
        }

        public IEnumerable<DocumentModel> GetAll(bool isDeleted = false)
        {
            return GetAll(string.Empty, isDeleted);
        }

        public IEnumerable<DocumentModel> GetAll(string category, bool isDeleted = false)
        {
            return new Query.Documents.GetAll(_context, category, isDeleted).ExecuteAndReturnResults()
                .Select(x => new DocumentModel(x)).OrderBy(x => x.LastModified);
        }

        public DocumentModel Upsert(DocumentModel model)
        {
            return new DocumentModel(new Command.Documents.Upsert(_context, _user, model.ToModel()).ExecuteAndReturnResults());
        }

        public void Delete(int id)
        {
            new Command.Documents.DeleteRestore(_context, _user, id, false).Execute();
        }

        public void Restore(int id)
        {
            new Command.Documents.DeleteRestore(_context, _user, id, true).Execute();
        }
    }
}
