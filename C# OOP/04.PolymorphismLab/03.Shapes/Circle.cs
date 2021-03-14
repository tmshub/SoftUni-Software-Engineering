using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Circle : Shape
    {
        double radius;

        public Circle(double radius)
        {
            this.radius = radius;
        }

        public override double CalculateArea()
        {
            return Math.PI * this.radius * 2;
        }

        public override double CalculatePerimeter()
        {
            return Math.PI * this.radius * 2;
        }

        public override void Draw()
        {
            base.Draw();
        }
    }
}
