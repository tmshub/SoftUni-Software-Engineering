using _07.Solid.Enums;
using _07.Solid.Layouts;
using _07.Solid.Loggers;

namespace _07.Solid.Appenders
{
    public interface IAppender
    {
        public ReportLevel ReportLevel { get; set; }
        void Append(string date, ReportLevel reportLevel, string message);
    }
}
