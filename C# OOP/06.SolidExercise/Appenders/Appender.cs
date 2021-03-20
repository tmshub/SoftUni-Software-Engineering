using _07.Solid.Enums;
using _07.Solid.Layouts;
using _07.Solid.Loggers;
using System;
using System.Collections.Generic;
using System.Text;

namespace _07.Solid.Appenders
{
  public abstract class Appender : IAppender
    {

        protected ILayout layout;

        public Appender(ILayout layout)
        {
            this.layout = layout;
        }

        public ReportLevel ReportLevel { get; set ; }
        protected int MessagesCount { get; set; }
        public abstract void Append(string date, ReportLevel reportLevel, string message);

        protected bool CanAppend(ReportLevel reportLevel)
        {
            return reportLevel >= this.ReportLevel;
        }

        public override string ToString()
        {
            return
            $"Appender type: {this.GetType().Name}, Layout type: {layout.GetType().Name}, Report level: {ReportLevel}, Messages appended: {MessagesCount}";

        }
    }
}
