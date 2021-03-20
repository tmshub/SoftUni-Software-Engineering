using _07.Solid.Appenders;
using _07.Solid.Enums;
using _07.Solid.Layouts;
using System;
using System.Collections.Generic;
using System.Text;

namespace _07.Solid.Core.Factories
{
   public interface IAppenderFactory
    {
        IAppender CreateAppender(string type, ILayout layout, ReportLevel reportLevel);
    }
}
