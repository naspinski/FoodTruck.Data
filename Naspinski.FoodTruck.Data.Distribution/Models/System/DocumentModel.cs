using Naspinski.Data.Interfaces;
using Naspinski.FoodTruck.Data.Models.Storage;
using System;
using System.ComponentModel.DataAnnotations;

namespace Naspinski.FoodTruck.Data.Distribution.Models.System
{
    public class DocumentModel : IToModel<Document>
    {
        public int Id { get; set; }
        public bool IsNew { get { return Id == 0; } }

        [Required]
        public string Location { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public string Category { get; set; }

        public bool DeleteAllOthers { get; set; }

        public bool IsDeleted { get; set; }

        private DateTimeOffset Created;
        private DateTimeOffset? Updated;
        public DateTimeOffset LastModified { get { return Updated.HasValue ? Updated.Value : Created; } }

        public DocumentModel() { }

        public DocumentModel(Document model)
        {
            Id = model.Id;
            Location = model.Location;
            Type = model.Type;
            Category = model.Category;
            IsDeleted = model.Deleted != null;
            Created = model.Created;
            Updated = model.Updated;
        }

        public Document ToModel()
        {
            return new Document()
            {
                Id = Id,
                Location = Location,
                Type = Type,
                Category = Category,
                DeleteAllOthers = DeleteAllOthers
            };
        }

    }
}
