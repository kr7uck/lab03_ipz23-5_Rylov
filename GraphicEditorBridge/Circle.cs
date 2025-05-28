namespace GraphicEditorBridge
{
    public class Circle : Shape
    {
        public Circle(IRenderer renderer) : base(renderer) { }

        public override void Draw()
        {
            _renderer.RenderCircle();
        }
    }
}
