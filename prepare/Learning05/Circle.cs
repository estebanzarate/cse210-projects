public class Circle : Shape
{
    private double _ratio;
    public Circle(string color, double ratio) : base(color)
    {
        _ratio = ratio;
    }
    public override double GetArea()
    {
        return Math.PI * Math.Pow(_ratio, 2);
    }
}