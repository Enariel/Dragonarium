// Dragonarium
// DragonRepo.cs
// FuchsFarbe Studios 2023
// Oliver MacDougall
// Modified: 06-11-2023

using Dragonarium.Models;
using Dragonarium.Services.Contexts;

namespace Dragonarium.Services.Repos
{
    public class DragonRepo : Repository<LkDragon>
    {
        /// <inheritdoc />
        public DragonRepo(DragonariumDbContext context) : base(context)
        {
        }

        public LkDragon GetDragonByName(string name)
        {
            return Context.Set<LkDragon>().Find(name);
        }

        public IEnumerable<LkDragon> GetDragonsByElement(LkElement element)
        {
            return Context.Set<LkDragon>().Where(x=>x.DragonElements.Select(x=>x.LkElement).Contains(element));
        }
    }
}