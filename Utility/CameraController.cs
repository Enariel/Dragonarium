using Godot;

namespace Dragonarium.Utility
{
    public partial class CameraController : Camera2D
    {
        [Export] public float ZoomSpeed { get; private set; } = 1.5f;

        private Vector2 _lastMousePos;

        // Called when the node enters the scene tree for the first time.
        public override void _Ready()
        {
            _lastMousePos = GetViewport().GetMousePosition();
        }

        public override void _Input(InputEvent @event)
        {
            if (@event is InputEventMouseMotion eventMouseMotion && Input.IsMouseButtonPressed(MouseButton.Right))
            {
                var mouseDelta = eventMouseMotion.Relative;

                // Translation speed factor allows you to control how fast the camera moves
                Translate(-mouseDelta * ZoomSpeed);
            }

            _lastMousePos = GetViewport().GetMousePosition();
        }
    }
}