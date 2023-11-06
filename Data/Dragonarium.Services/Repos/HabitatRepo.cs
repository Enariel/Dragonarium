// Dragonarium
// HabitatRepo.cs
// FuchsFarbe Studios 2023
// Oliver MacDougall
// Modified: 06-11-2023

using Dragonarium.Models;
using Dragonarium.Services.Contexts;

namespace Dragonarium.Services.Repos
{
    /// <inheritdoc />
    public class HabitatRepo : Repository<LkHabitat>
    {
        public HabitatRepo(DragonariumDbContext context) : base(context)
        {
        }

        public LkHabitat GetHabitatByName(string name)
        {
            return Context.Set<LkHabitat>().Find(name);
        }
        
    }
}