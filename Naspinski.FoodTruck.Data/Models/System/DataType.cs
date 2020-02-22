namespace Naspinski.FoodTruck.Data.Models.System
{
    public class DataType
    {
        public string Name { get; set; }

        public string Regex { get; set; }

        public DataType() { }
        public DataType(string name, string regex)
        {
            Name = name;
            Regex = regex;
        }
    }
}
