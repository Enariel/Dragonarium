// Dragonarium
// LkHabitatElement.cs
// FuchsFarbe Studios 2023
// Oliver MacDougall
// Modified: 06-11-2023

namespace Dragonarium.Models
{
    public class LkHabitatElement
    {
        public Guid HabitatID { get; set; }
        public int ElementID { get; set; }

        public virtual LkHabitat Habitat { get; set; }
        public virtual LkElement Element { get; set; }
    }
}