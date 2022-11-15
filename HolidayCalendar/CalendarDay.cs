﻿using System;

namespace CalendarCalculator
{
    public class CalendarDay : IComparable<CalendarDay>, IEquatable<CalendarDay>
    {
        private static readonly string[] _weekdayNames
            = new string[] { "SO", "MO", "DI", "MI", "DO", "FR", "SA" };

        public CalendarDay(DateTime dateTime) : this(dateTime, false, null) { }

        public CalendarDay(DateTime dateTime, bool isPublicHoliday, string? holidayName)
        {
            DateTime = dateTime;
            IsPublicHoliday = isPublicHoliday;
            HolidayName = holidayName;
        }

        public DateTime DateTime { get; }
        public bool IsPublicHoliday { get; }
        public string? HolidayName { get; }
        public bool IsSchoolHoliday => HolidayName is not null;
        public DateTime Date2000 => new DateTime(2000, DateTime.Month, DateTime.Day);
        public int DayOfYearSinceMarch => 
            (int)((DateTime.Ticks - new DateTime(DateTime.Month < 3 ? DateTime.Year - 1 : DateTime.Year, 3, 1).Ticks) 
            / TimeSpan.TicksPerDay);
        public int WeekdayNr => DateTime.DayOfWeek == DayOfWeek.Sunday ? 7 : (int)DateTime.DayOfWeek;
        public string WeekdayName => _weekdayNames[(int)DateTime.DayOfWeek];
        public bool IsWorkingDayMoFr =>
            DateTime.DayOfWeek != DayOfWeek.Saturday && DateTime.DayOfWeek != DayOfWeek.Sunday && !IsPublicHoliday;
        public bool IsWorkingDayMoSa =>
            DateTime.DayOfWeek != DayOfWeek.Sunday && !IsPublicHoliday;
        public bool IsSchoolDayMoFr =>
            DateTime.DayOfWeek != DayOfWeek.Saturday && DateTime.DayOfWeek != DayOfWeek.Sunday && !IsSchoolHoliday;

        public int CompareTo(CalendarDay? other) => DateTime.CompareTo(other?.DateTime);
        public bool Equals(CalendarDay? other) => DateTime.Equals(other?.DateTime);
    }
}