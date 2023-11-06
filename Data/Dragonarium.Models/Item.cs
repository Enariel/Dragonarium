// Dragonarium
// LkItem.cs
// FuchsFarbe Studios 2023
// Oliver MacDougall
// Modified: 06-11-2023

namespace Dragonarium.Models
{
    public class Item
    {
        public Guid ItemID { get; set; }
        public string ItemName { get; set; }
        public string Description { get; set; }

        public virtual ICollection<ItemCurrency> ItemCurrencies { get; set; }
    }
}