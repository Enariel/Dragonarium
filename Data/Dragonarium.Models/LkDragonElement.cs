// Dragonarium
// LkDragonElements.cs
// FuchsFarbe Studios 2023
// Oliver MacDougall
// Modified: 06-11-2023

namespace Dragonarium.Models
{
    public class LkDragonElement
    {
        public Guid LkDragonID { get; set; }
        public int LkElementID { get; set; }

        public virtual LkDragon LkDragon { get; set; }
        public virtual LkElement LkElement { get; set; }
    }
}