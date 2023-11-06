using Dragonarium.Habitats;
using Dragonarium.Models;
using Godot;

namespace Dragonarium.Dragons
{
	public partial class Dragon : CharacterBody2D
	{
		public LkDragon Data { get; private set; } = new LkDragon();

		public Habitat Habitat { get; private set; }

		[Export] public NavigationAgent2D Agent { get; private set; }


		public void Initialize(Habitat habitat, LkDragon dragon)
		{
			Habitat = habitat;
			Data = dragon;
		}
	}
}