using Naspinski.Data.Model;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;

namespace Naspinski.FoodTruck.Data.Models.Storage
{
    public class Document : AuditCreateUpdateDeleteBase
    {
        [NotMapped]
        public static class DocType
        {
            public const string Pdf = "application/pdf";
            public const string Jpeg = "image/jpeg";
            public const string Png = "image/png";

            public static string FromFileName(string filename)
            {
                var ext = Path.GetExtension(filename).ToLower().Trim();
                switch(ext)
                {
                    case ".pdf": return Pdf;
                    case ".png": return Png;
                    case ".jpg": case ".jpeg": return Jpeg;

                    default:
                        throw new NotImplementedException($"extension: {ext} has not been implemented yet");
                }
            }
        }

        [NotMapped]
        public static class DocCategory
        {
            public const string Menu = "Menu";
        }

        [NotMapped]
        public bool DeleteAllOthers { get; set; }

        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Location { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        public string Category { get; set; }
    }
}
