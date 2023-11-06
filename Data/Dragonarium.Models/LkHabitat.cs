// Dragonarium
// HabitatData.cs
// FuchsFarbe Studios 2023
// Oliver MacDougall
// Modified: 06-11-2023

using System.ComponentModel.DataAnnotations.Schema;

namespace Dragonarium.Models
{
    public class LkHabitat
    {
        public Guid HabitatID { get; set; }
        public string HabitatName { get; set; }
        public string Description { get; set; }
    }
}