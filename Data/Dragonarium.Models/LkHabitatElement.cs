// Dragonarium
// LkHabitatElement.cs
// FuchsFarbe Studios 2023
// Oliver MacDougall
// Modified: 06-11-2023

namespace Dragonarium.Models
{
    public class LkHabitatElement
    {
        public Guid LkHabitatID { get; set; }
        public int LkElementID { get; set; }

        public virtual LkHabitat LkHabitat { get; set; }
        public virtual LkElement LkElement { get; set; }
    }
}