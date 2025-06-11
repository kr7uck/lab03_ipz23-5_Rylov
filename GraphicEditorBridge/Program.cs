namespace GraphicEditorBridge
{
    class Program
    {
        static void Main(string[] args)
        {
            Shape vectorCircle = new Circle(new VectorRenderer());
            Shape vectorSquare = new Square(new VectorRenderer());
            Shape vectorTriangle = new Triangle(new VectorRenderer());

            Shape rasterCircle = new Circle(new RasterRenderer());
            Shape rasterSquare = new Square(new RasterRenderer());
            Shape rasterTriangle = new Triangle(new RasterRenderer());

            vectorCircle.Draw();
            vectorSquare.Draw();
            vectorTriangle.Draw();

            rasterCircle.Draw();
            rasterSquare.Draw();
            rasterTriangle.Draw();
        }
    }
}