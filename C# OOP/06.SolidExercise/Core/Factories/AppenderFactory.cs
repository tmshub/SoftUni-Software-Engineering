using _07.Solid.Appenders;
using _07.Solid.Enums;
using _07.Solid.Layouts;
using System;
using System.Collections.Generic;
using System.Text;

namespace _07.Solid.Core.Factories
{
    public class AppenderFactory : IAppenderFactory
    {
        public IAppender CreateAppender(string type, ILayout layout, ReportLevel reportLevel)
        {
            IAppender appender = null;

            switch (type)
            {
                case nameof(ConsoleAppender):
                    appender = new ConsoleAppender(layout)
                    {
                        ReportLevel = reportLevel
                    };
                    break;
                case nameof(FileAppender):
                    appender = new FileAppender(layout, new LogFile())
                    {
                        ReportLevel = reportLevel
                    };
                    break;
            }

            return appender;
        }
    }
}
