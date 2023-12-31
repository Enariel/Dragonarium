// Dragonarium
// LkDragon.cs
// FuchsFarbe Studios 2023
// Oliver MacDougall
// Modified: 06-11-2023

namespace Dragonarium.Models
{
    public class LkDragon
    {
        public Guid LkDragonID { get; set; }
        public string DragonName { get; set; }
        public string Description { get; set; }
        public int GoldRate { get; set; }

        public virtual ICollection<LkDragonElement> DragonElements { get; set; }
    }
}