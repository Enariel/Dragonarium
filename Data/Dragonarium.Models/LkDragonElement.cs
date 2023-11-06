// Dragonarium
// LkDragonElements.cs
// FuchsFarbe Studios 2023
// Oliver MacDougall
// Modified: 06-11-2023

namespace Dragonarium.Models
{
    public class LkDragonElement
    {
        public Guid DragonID { get; set; }
        public int ElementID { get; set; }

        public virtual LkDragon Dragon { get; set; }
        public virtual LkElement Element { get; set; }
    }
}