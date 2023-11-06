using Godot;
using System;
using System.Linq;
using Dragonarium.Models;
using Dragonarium.Services.Contexts;
using Dragonarium.Services.Repos;

public partial class PurchaseHabitatBtn : Button
{
    public LkHabitat Habitat { get; set; }

    /// <inheritdoc />
    public override void _EnterTree()
    {
        base._EnterTree();
        Pressed += HabitatBtnPressed;
    }

    /// <inheritdoc />
    public override void _ExitTree()
    {
        base._ExitTree();
        Pressed -= HabitatBtnPressed;
    }

    /// <inheritdoc />
    public override async void _Ready()
    {
        base._Ready();
        await using (var ctx = new DragonariumDbContext())
        {
            var repo = new HabitatRepo(ctx);
            var habitats = await repo.GetAllAsync();
            Habitat = habitats.FirstOrDefault();
            Text = Habitat.HabitatName;
        }
    }

    private void HabitatBtnPressed()
    {
        GD.Print(Habitat.HabitatName);
    }
}