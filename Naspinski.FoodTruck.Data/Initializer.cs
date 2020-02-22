using Naspinski.FoodTruck.Data.Models.System;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Naspinski.FoodTruck.Data
{
    public class Initializer
    {
        private FoodTruckContext _context;

        public Initializer(FoodTruckContext context)
        {
            _context = context;
        }

        public async Task Seed()
        {
            var settings = _context.Settings.ToList();

            foreach (var seed in Seeds.Settings)
            {
                var setting = settings.FirstOrDefault(x => x.Name == seed.Name);
                if(setting == null)
                {
                    _context.Add(new Setting()
                    {
                        Name = seed.Name,
                        Value = seed.Value,
                        Category = seed.Category,
                        DataType = seed.DataType,
                        IsHidden = seed.IsHidden,
                        Created = DateTime.UtcNow,
                        CreatedBy = "system"
                    });
                }
                else //always set these
                {
                    setting.Category = seed.Category;
                    setting.DataType = seed.DataType;
                    setting.IsHidden = seed.IsHidden;
                }
            }
            await _context.SaveChangesAsync();
        }
    }
}
