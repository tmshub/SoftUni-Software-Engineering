using _07.Solid.Appenders;
using _07.Solid.Core.Factories;
using _07.Solid.Enums;
using _07.Solid.Layouts;
using _07.Solid.Loggers;
using System;
using System.Collections.Generic;
using System.IO;

namespace _07.Solid
{
    class Program
    {
       
        static void Main(string[] args)
        {
            ILayoutFactory layoutFactory = new LayoutFactory();
            IAppenderFactory appenderFactory = new AppenderFactory();

            IEngine engine = new Engine(appenderFactory, layoutFactory);

            engine.Run();
    }
    }
}
