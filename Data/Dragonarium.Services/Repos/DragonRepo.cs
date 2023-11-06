// Dragonarium
// DragonRepo.cs
// FuchsFarbe Studios 2023
// Oliver MacDougall
// Modified: 06-11-2023

using Dragonarium.Models;
using Dragonarium.Services.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Dragonarium.Services.Repos
{
    /// <inheritdoc />
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
            return Context.Set<LkDragon>().Where(x => x.DragonElements.Select(x => x.LkElement).Contains(element));
        }

        public async Task<IEnumerable<LkDragonEgg>> GetDragonEggsAsync()
        {
            return await Context.DragonEggs.ToListAsync();
        }

        public async Task<LkDragonEgg> GetDragonEggAsync(LkDragon dragon)
        {
            var egg = await Context.DragonEggs.Where(x => x.LkDragon == dragon).FirstOrDefaultAsync();
            if (egg != null)
                return egg;

            return null;
        }

        public async Task<LkDragonEgg> GetDragonEggAsync(Guid dragonID)
        {
            var egg = await Context.DragonEggs.Where(x => x.LkDragonID == dragonID).FirstOrDefaultAsync();
            if (egg != null)
                return egg;

            return null;
        }
    }
}