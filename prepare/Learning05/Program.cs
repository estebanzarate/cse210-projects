using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine($"\n--- [SQUARE] ---");
        Square square = new Square("Green", 3.00);
        Console.WriteLine($"Color: {square.GetColor()}");
        Console.WriteLine($"Area: {square.GetArea()}");
        Console.WriteLine($"\n--- [RECTANGLE] ---");
        Rectangle rectangle = new Rectangle("Red", 4.00, 2.00);
        Console.WriteLine($"Color: {rectangle.GetColor()}");
        Console.WriteLine($"Area: {rectangle.GetArea()}");
        Console.WriteLine($"\n--- [CIRCLE] ---");
        Circle circle = new Circle("Blue", 5.00);
        Console.WriteLine($"Color: {circle.GetColor()}");
        Console.WriteLine($"Area: {circle.GetArea()}");
    }
}