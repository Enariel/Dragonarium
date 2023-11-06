using System.Collections.Generic;
using Dragonarium.Dragons;
using Dragonarium.Models;
using Godot;

namespace Dragonarium.Habitats
{
	public partial class Habitat : Area2D
	{
		public LkHabitat Data { get; private set; } = new LkHabitat();

		public List<Dragon> Dragons { get; private set; } = new List<Dragon>();

		public void InitializeHabitat(LkHabitat data)
		{
			Data = data;
		}
	}
}