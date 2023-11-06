using System.Linq;
using Dragonarium.Models;
using Dragonarium.Services.Contexts;
using Dragonarium.Services.Repos;
using Godot;

namespace Dragonarium.UI.Components;

public partial class PurchaseEggBtn : Button
{
    public LkDragonEgg Egg { get; set; } = new LkDragonEgg();

    public override async void _Ready()
    {
        await using (var ctx = new DragonariumDbContext())
        {
            var repo = new DragonRepo(ctx);
            var eggs = await repo.GetDragonEggsAsync();
            Egg = eggs.FirstOrDefault();
            Text = Egg?.LkDragon.DragonName;
        }
    }

    /// <inheritdoc />
    public override void _EnterTree()
    {
        Pressed += EggBtnPressed;
    }

    /// <inheritdoc />
    public override void _ExitTree()
    {
        Pressed -= EggBtnPressed;
    }

    private void EggBtnPressed()
    {
        GD.Print(Egg?.LkDragon.DragonName + "- Egg");

        // Try purchasing the egg
    }
}