// Dragonarium
// ItemRepo.cs
// FuchsFarbe Studios 2023
// Oliver MacDougall
// Modified: 06-11-2023

using Dragonarium.Models;
using Dragonarium.Services.Contexts;

namespace Dragonarium.Services.Repos
{
    public class ItemRepo : Repository<Item>
    {
        /// <inheritdoc />
        public ItemRepo(DragonariumDbContext context) : base(context)
        {
        }
    }
}