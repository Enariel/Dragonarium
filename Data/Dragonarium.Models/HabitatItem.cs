// Dragonarium
// HabitatItem.cs
// FuchsFarbe Studios 2023
// Oliver MacDougall
// Modified: 06-11-2023

namespace Dragonarium.Models
{
    public class HabitatItem : Item
    {
        public Guid LkHabitatID { get; set; }
        public virtual LkHabitat LkHabitat { get; set; }

    }
}