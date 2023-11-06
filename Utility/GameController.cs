using System;
using Dragonarium.Habitats;
using Dragonarium.Models;
using Dragonarium.Player;
using Dragonarium.Services.Contexts;
using Dragonarium.Services.Repos;
using Godot;

namespace Dragonarium.Utility;

public partial class GameController : Node
{
    [Export] public PackedScene DragonScene { get; set; }

    [Export] public PackedScene HabitatScene { get; set; }

    [Export] public HabitatManager HabitatManager { get; set; }

    [Export] public PlayerManager PlayerManager { get; set; }

    public void PlaceHabitat(LkHabitat data)
    {
    }
}