using System;

namespace Shapes
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Shape shape = new Rectangle(2, 3);
            Console.WriteLine(shape.CalculateArea());
            
        }
    }
}
