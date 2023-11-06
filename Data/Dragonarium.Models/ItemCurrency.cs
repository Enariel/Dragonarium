// Dragonarium
// ItemCurrency.cs
// FuchsFarbe Studios 2023
// Oliver MacDougall
// Modified: 06-11-2023

namespace Dragonarium.Models
{
    public class ItemCurrency
    {
        public Guid ItemID { get; set; }
        public int LkCurrencyID { get; set; }
        public int Amount { get; set; }

        public virtual Item Item { get; set; }
        public virtual LkCurrency LkCurrency { get; set; }
    }
}