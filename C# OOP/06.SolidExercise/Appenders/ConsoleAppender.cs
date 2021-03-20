using _07.Solid.Enums;
using _07.Solid.Layouts;
using System;
using System.Collections.Generic;
using System.Text;

namespace _07.Solid.Appenders
{
    public class ConsoleAppender : Appender
    {
        public ConsoleAppender(ILayout layout)
            : base(layout)
        {

        }

        public override void Append(string date, ReportLevel reportLevel, string message)
        {
            if (CanAppend(reportLevel))
            {
                string content = string.Format(this.layout.Template, date, reportLevel, message);
                MessagesCount += 1;
                Console.WriteLine(content);
            }
            
        }
    }
}
