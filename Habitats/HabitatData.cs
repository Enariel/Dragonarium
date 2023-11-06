// Dragonarium
// HabitatData.cs
// FuchsFarbe Studios 2023
// Oliver MacDougall
// Modified: 06-11-2023

using System;
using Dragonarium.Models;
using Godot;

namespace Dragonarium.Habitats
{
    [Serializable]
    public class HabitatData
    {
        public LkHabitat Data { get; set; } = new LkHabitat();
        public Vector2 Position { get; set; }
        // List of dragons
    }
}