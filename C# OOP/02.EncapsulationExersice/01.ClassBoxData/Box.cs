using System;
using System.Collections.Generic;
using System.Text;

namespace _01.ClassBoxData
{
    public class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            Length = length;
            Width = width;
            Height = height;
        }

        public double Length
        {
            get => this.length;
            private set
            {
                Validation.IsZeroOrNegativeNumber(value, nameof(Length));
            }
        }
        public double Width 
        {
            get => this.width;
            private set
            {
                Validation.IsZeroOrNegativeNumber(value, nameof(Width));
            }
        }
        public double Height 
        {
            get => this.height;
            private set
            {
                Validation.IsZeroOrNegativeNumber(value, nameof(Height));
            }
        }

        public double Volume(double length, double width, double height)
        {
            return length * width * height;
        }

        public double SurfaceArea(double length, double width, double height)
        {
            return 2 * length * width + 2 * length * height + 2 * width * height;
        }

        public double LateralSurfaceArea(double length, double width, double height)
        {
            return 2*length*height + 2*width*height;
        }
    }
}
