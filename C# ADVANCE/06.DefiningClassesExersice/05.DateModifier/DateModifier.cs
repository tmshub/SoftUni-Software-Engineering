using System;
using System.Collections.Generic;
using System.Text;

namespace _05.DateModifier
{
    class DateModifier
    {
        public int GetDifferenceDays(string startDateAsString, string endDateAsString)
        {
            var startDate = DateTime.Parse(startDateAsString);
            var endDate = DateTime.Parse(endDateAsString);

            var result = (int)Math.Abs((startDate - endDate).TotalDays);

            return result;
        }
    }
}
