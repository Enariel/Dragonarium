using Godot;

namespace Dragonarium.Dragons
{
    public partial class DragonVfx : Node2D
    {
        [Export] public Skeleton2D Rig { get; set; }
    }
}