using _07.Solid.Appenders;
using _07.Solid.Core.Factories;
using _07.Solid.Enums;
using _07.Solid.Layouts;
using _07.Solid.Loggers;
using System;
using System.Collections.Generic;
using System.Text;

namespace _07.Solid
{
    public class Engine : IEngine
    {
        private IAppenderFactory appenderFactory;
        private ILayoutFactory layoutFactory;

        public Engine(IAppenderFactory appenderFactory, ILayoutFactory layoutFactory)
        {
            this.appenderFactory = appenderFactory;
            this.layoutFactory = layoutFactory;
        }

        public void Run()
        {
            int n = int.Parse(Console.ReadLine());

            layoutFactory = new LayoutFactory();
            appenderFactory = new AppenderFactory();
            List<IAppender> appenders = new List<IAppender>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                string appenderType = input[0];
                string layoutType = input[1];

                ReportLevel reportLevel = input.Length == 3
                    ? Enum.Parse<ReportLevel>(input[2], true)
                    : ReportLevel.Info;

                ILayout layout = layoutFactory.CreateLayout(layoutType);
                IAppender appender = appenderFactory.CreateAppender(appenderType, layout, reportLevel);
                appenders.Add(appender);

            }

            ILogger loggers = new Logger(appenders.ToArray());
            string[] command = Console.ReadLine().Split("|");

            while (command[0] != "END")
            {

                ReportLevel reportLevel = Enum.Parse<ReportLevel>(command[0], true);
                string date = command[1];
                string message = command[2];

                switch (reportLevel)
                {
                    case ReportLevel.Info:
                        loggers.Info(date, message);
                        break;
                    case ReportLevel.Warning:
                        loggers.Warning(date, message);
                        break;
                    case ReportLevel.Error:
                        loggers.Error(date, message);
                        break;
                    case ReportLevel.Critical:
                        loggers.Critical(date, message);
                        break;
                    case ReportLevel.Fatal:
                        loggers.Fatal(date, message);
                        break;
                }
                command = Console.ReadLine().Split("|");

            }
            Console.WriteLine(loggers);
        }

        private List<IAppender> ReadAppenders(int n)
        {
            List<IAppender> appenders = new List<IAppender>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                string appenderType = input[0];
                string layoutType = input[1];

                ReportLevel reportLevel = input[2].Length == 3
                    ? Enum.Parse<ReportLevel>(input[2], true)
                    : ReportLevel.Info;

                ILayout layout = layoutFactory.CreateLayout(layoutType);
                IAppender appender = appenderFactory.CreateAppender(appenderType, layout, reportLevel);
                appenders.Add(appender);

            }

            return appenders;
        }
        
    }
}
