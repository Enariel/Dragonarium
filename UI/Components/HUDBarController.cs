using Godot;
using System;

public partial class HUDBarController : HBoxContainer
{
    [Export] public Button ShopBtn { get; private set; }
    [Export] public Button ProfileBtn { get; private set; }
    [Export] public Button InventoryBtn { get; private set; }
    [Export] public Button SettingsBtn { get; private set; }
    [Export] public Button QuitBtn { get; private set; }
}