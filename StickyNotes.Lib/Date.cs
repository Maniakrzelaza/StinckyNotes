using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace StickyNotes.Lib
{
    public class Date : IDate
    {
        public Regex FormatRegex { get; set; }
        public String Format { get; set; }
        public Char Delimiter { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }

        public String DateString { get; set; }
        public Date()
        {
            this.FormatRegex = new Regex("[12][0-9]{3}-[01][0-9]-[0123][0-9]");
            this.Format = "YYYY-MM-DD";
        }
        public Date(String format)
        {
            this.Delimiter = '-';
            this.ChangeDateFormat(format);
        }

        public void ChangeDate(String date)
        {
            if (!date.Contains(this.Delimiter.ToString()) || !this.FormatRegex.IsMatch(date))
            {
                throw new ArgumentException("Wrong date format");
            }
            var YearMonthDay = date.Split(this.Delimiter.ToString());
            this.DateString = date;
            switch (this.Format)
            {
                case "YYYY-MM-DD":
                    this.Year = int.Parse(YearMonthDay[0]);
                    this.Month = int.Parse(YearMonthDay[1]);
                    this.Day = int.Parse(YearMonthDay[2]);
                    break;
                case "DD-MM-YYYY":
                    this.Year = int.Parse(YearMonthDay[2]);
                    this.Month = int.Parse(YearMonthDay[1]);
                    this.Day = int.Parse(YearMonthDay[0]);
                    break;
            }
        }

        public bool IsLeaterThanNow()
        {
            int yearNow = DateTime.Now.Year;
            int monthNow = DateTime.Now.Month;
            int dayNow = DateTime.Now.Day;
            if (this.Year > yearNow)
            {
                return true;
            }
            else if (this.Year == yearNow)
            {
                if (this.Month > monthNow)
                {
                    return true;
                }
                else if (this.Month == monthNow)
                {
                    if (this.Day > dayNow)
                    {
                        return true;
                    }
                    else if (this.Day == dayNow)
                    {

                    }
                    else
                        return false;
                }
                else
                    return false;
            }
            else
                return false;
            return false;
        }

        public void ChangeDateFormat(String format)
        {
            String upperedFormat = format.ToUpper().Replace(".-", "-");

            switch (upperedFormat)
            {
                case "YYYY-MM-DD":
                    this.Format = "YYYY-MM-DD";
                    this.FormatRegex = new Regex("[12][0-9]{3}" + this.Delimiter + "[01][0-9]" + this.Delimiter + "[0123][0-9]");
                    break;
                case "DD-MM-YYYY":
                    this.Format = "DD-MM-YYYY";
                    this.FormatRegex = new Regex("[0123][0-9]" + this.Delimiter + "[01][0-9]" + this.Delimiter + "[12][0-9]{3}");
                    break;
                default:
                    throw new ArgumentException("Not existing format");
            }
        }
        public void ChangeDelimiter(Char delimiter)
        {
            this.Delimiter = delimiter;
            this.ChangeDateFormat(this.Format);
        }

        public override string ToString()
        {
            return this.DateString;
        }
    }
}
