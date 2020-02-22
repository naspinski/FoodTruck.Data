using Naspinski.Data.Interfaces;
using Naspinski.FoodTruck.Data.Models.Menu;
using System;
using System.Collections.Generic;
using System.Text;

namespace Naspinski.FoodTruck.Data.Distribution.Models.Menu
{
    public class PriceModel : IToModel<Price>
    {
        public int Id { get; set; }
        public int? PriceTypeId { get; set; }
        public int MenuItemId { get; set; }
        public decimal Amount { get; set; }
        public string AmountAsCurrency { get { return string.Format("{0:C}", Amount); } }
        public string PriceTypeName { get; set; }
        public int PriceTypeSortOrder { get; set; }

        public PriceModel() { }
        public PriceModel(Price model)
        {
            Id = model.Id;
            MenuItemId = model.MenuItemId;
            PriceTypeId = model.PriceTypeId;
            PriceTypeName = model.PriceType?.Name ?? string.Empty;
            PriceTypeSortOrder = model.PriceType?.SortOrder ?? 0;
            Amount = model.Amount;
        }

        public Price ToModel()
        {
            return new Price()
            {
                Id = Id,
                MenuItemId = MenuItemId,
                PriceTypeId = PriceTypeId,
                Amount = Amount
            };
        }
    }
}
