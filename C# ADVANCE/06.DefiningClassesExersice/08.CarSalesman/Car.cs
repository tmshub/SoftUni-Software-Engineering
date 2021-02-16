using System;
using System.Collections.Generic;
using System.Text;

namespace _08.CarSalesman
{

    public class Car
    {
        public Car(string model, Engine engine)
        {
            Model = model;
            Engine = engine;
            Weight = "n/a";
            Color = "n/a";
        }
        public Car(string model, Engine engine, string weight)
            :this(model,engine)
        {
            Model = model;
            Engine = engine;
            Weight = weight;
        }
        public Car(string model, Engine engine, string weight, string color)
            :this(model,engine,weight)
        {
            Model = model;
            Engine = engine;
            Weight = weight;
            Color = color;
        }

        public string Model { get; set; }
        public Engine Engine { get; set; }
        public string Weight { get; set; }
        public string Color { get; set; }

    }
}
