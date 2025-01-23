using System;
using System.Collections.Generic;
using System.Globalization;
using Izenda.BI.Framework.Constants;
using Izenda.BI.Framework.Models;

namespace CustomAdhocReports
{
    /// <summary>
    /// The custom data format class.
    /// </summary>
    static class CustomDataFormat
    {
        /// <summary>
        /// Loads the custom data formats.
        /// </summary>
        /// <returns>Returns a list of custom data formats.</returns>
        public static List<DataFormat> LoadCustomDataFormat()
        {
            var result = new List<DataFormat>
            {
                new DataFormat
                {
                    Name = "By Hour",
                    DataType = DataType.DateTime,
                    Category = IzendaKey.CustomFormat,
                    GroupBy = "dateandtime",
                    FormatFunc = (x) =>
                    {
                        var date = Convert.ToDateTime(x);
                        return date.ToString("M/d/yyyy h:00 tt");
                    },
                    JsFormatString = "By Hour"
                },
                new DataFormat
                {
                    Name = "dd MM:mm",
                    DataType = DataType.DateTime,
                    Category = IzendaKey.CustomFormat,
                    GroupBy = "dateandtime",
                    FormatFunc = (x) =>
                    {
                        var date = Convert.ToDateTime(x);
                        return date.ToString("dd HH:mm");
                    },
                    JsFormatString = "{value:%d %H:%M}"
                },
                new DataFormat
                {
                    Name = "dd HH:mm:ss",
                    DataType = DataType.DateTime,
                    Category = IzendaKey.CustomFormat,
                    GroupBy = "dateandtime",
                    FormatFunc = (x) =>
                    {
                        var date = Convert.ToDateTime(x);
                        return date.ToString("dd HH:mm:ss");
                    },
                    JsFormatString = "{value:%d %H:%M:%S}"
                },
                new DataFormat
                {
                    Name = "dd mm:ss",
                    DataType = DataType.DateTime,
                    Category = IzendaKey.CustomFormat,
                    GroupBy = "dateandtime",
                    FormatFunc = (x) =>
                    {
                        var date = Convert.ToDateTime(x);
                        return date.ToString("dd mm:ss");
                    },
                    JsFormatString = "{value:%d %M:%S}"
                },
                new DataFormat
                {
                    Name = "week",
                    DataType = DataType.DateTime,
                    Category = IzendaKey.CustomFormat,
                    GroupBy = "weeknumber",
                    FormatFunc = x =>
                    {
                        try
                        {
                            if (x is string xString)
                            {
                                var parts = xString.Split("-");
                                var year = int.Parse(parts[0]);
                                int week = int.Parse(parts[1]);

                                var firstDate = new DateTime(year, 1, 1);
                                var dateTime = firstDate.AddDays((week - 1) * 7 - (int)firstDate.DayOfWeek + (int)DayOfWeek.Monday);

                                // Example: "Week from Monday, January 01, 2020"
                                return "Week from " + dateTime.ToString("dddd, MMMM d, yyyy");
                            }

                            return "Week from " + Convert.ToDateTime(x).ToString("dddd, MMMM d, yyyy");
                        }
                        catch
                        {
                            return x?.ToString();
                        }
                    },
                    JsFormatString ="Week from {value:%A, %B %e, %Y}",
                    FormatDataType = DataType.DateTime
                },
                new DataFormat
                {
                    Name = "£0,000",
                    DataType = DataType.Numeric,
                    Category = IzendaKey.CustomFormat,
                    FormatFunc = (x) =>
                    {
                        var number = Convert.ToDecimal(x);
                        return number.ToString("C0", CultureInfo.CreateSpecificCulture("en-GB"));
                    }
                },
                new DataFormat
                {
                    Name = "¥0,000",
                    DataType = DataType.Numeric,
                    Category = IzendaKey.CustomFormat,
                    FormatFunc = (x) =>
                    {
                        var number = Convert.ToDecimal(x);
                        return number.ToString("C0", CultureInfo.CreateSpecificCulture("ja-JP"));
                    }
                },
                new DataFormat
                {
                    Name = "0,000",
                    DataType = DataType.Numeric,
                    Category = IzendaKey.CustomFormat,
                    FormatFunc = (x) =>
                    {
                        return String.Format(CultureInfo.InvariantCulture, "{0:0,0}", x);
                    }
                },
                new DataFormat
                {
                    Name = "$0,000",
                    DataType = DataType.Numeric,
                    Category = IzendaKey.CustomFormat,
                    FormatFunc = (x) =>
                    {
                        return String.Format(CultureInfo.InvariantCulture, "${0:0,0}", x);
                    }
                },
                new DataFormat
                {
                    Name = "HH:MM:SS",
                    DataType = DataType.Numeric,
                    Category = IzendaKey.CustomFormat,
                    FormatFunc = (x) =>
                    {
                        var newValue = Convert.ToDouble(x);
                        TimeSpan time = TimeSpan.FromSeconds(newValue);

                        return time.ToString(@"dd\.hh\:mm\:ss");
                    }
                }
            };

            return result;
        }
    }
}
