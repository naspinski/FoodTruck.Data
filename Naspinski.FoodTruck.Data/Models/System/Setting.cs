using Naspinski.Data.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Naspinski.FoodTruck.Data.Models.System
{
    public class Setting : AuditCreateUpdateBase
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Value { get; set; }

        public string Category { get; set; }
        public string DataType { get; set; }
        public bool IsHidden { get; set; }
        public int Order { get; set; }

        [NotMapped]
        public string Regex
        {
            get
            {
                if (string.IsNullOrWhiteSpace(DataType) || !Constants.DataTypes.ContainsKey(DataType))
                    return string.Empty;

                return Constants.DataTypes[DataType];
            }
        }
    }
}
