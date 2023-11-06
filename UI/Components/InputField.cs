using Godot;
using System;

public partial class InputField : HBoxContainer
{
    [Export] public LineEdit Input { get; set; }

    [Export] public Button AcceptBtn { get; set; }

    [Export] public Button ClearBtn { get; set; }

    [Export] public Label TextLbl { get; set; }

    /// <inheritdoc />
    public override void _EnterTree()
    {
        base._EnterTree();
        AcceptBtn.Pressed += AcceptBtnPressed;
        ClearBtn.Pressed += ClearBtnPressed;
    }

    /// <inheritdoc />
    public override void _ExitTree()
    {
        base._ExitTree();
        AcceptBtn.Pressed -= AcceptBtnPressed;
        ClearBtn.Pressed -= ClearBtnPressed;
    }

    private void AcceptBtnPressed()
    {
        TextLbl.Text = Input.Text;
        Input.Text = "";
    }

    private void ClearBtnPressed()
    {
        Input.Text = "";
        TextLbl.Text = "";
    }
}