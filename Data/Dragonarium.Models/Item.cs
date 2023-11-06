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
        public string Icon { get; set; }

        public virtual ICollection<ItemCurrency> ItemCurrencies { get; set; }
    }

    public class HabitatItem : Item
    {
        public Guid LkHabitatID { get; set; }
        public virtual LkHabitat LkHabitat { get; set; }

    }

    public class DragonEggItem : Item
    {
        public Guid LkDragonID { get; set; }
        public virtual LkDragon LkDragon { get; set; }
    }
}