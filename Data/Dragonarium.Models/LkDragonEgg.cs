// Dragonarium
// LkDragonEgg.cs
// FuchsFarbe Studios 2023
// Oliver MacDougall
// Modified: 06-11-2023

namespace Dragonarium.Models
{
    public class LkDragonEgg
    {
        public Guid LkDragonID { get; set; }
        public int HatchExp { get; set; }

        public virtual LkDragon LkDragon { get; set; }
    }
}