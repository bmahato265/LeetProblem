using System.Security.Cryptography;

static class Program
{
    public static void Main(string[] args)
    {
        DateTimeOffset dateTimeOffset = DateTimeOffset.Now;
        DateTimeOffset dateTimeOffsetUTC = DateTimeOffset.UtcNow;
        Console.WriteLine(dateTimeOffset);
        Console.WriteLine(TimeZoneInfo.Local);
        var estTime = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
        Console.WriteLine(TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, estTime));


        Console.WriteLine($"{CalculateDuration(new TimeOnly(22, 45), new TimeOnly(23, 59))} minutes.");
        // var age = new DateOnly(1995, 10, 30).CalculateAge();
        // Console.WriteLine($"{age.years} years, {age.months} months, {age.days} days");
        // Console.WriteLine(CalculateDays(new DateOnly(2026, 02, 07), new DateOnly(2026, 02, 21)));
        //Console.WriteLine(new DateOnly(2026, 02, 21).CalculateDayOfWeek());

    }
    
    public static DayOfWeek CalculateDayOfWeek(this DateOnly date)
    {
        /*
        Problem:
        Given a date (day, month, year), return the day of the week.
    */
        return date.DayOfWeek;
    }
   
    internal static int CalculateDays(DateOnly startDate, DateOnly endDate)
    {
         /*Problem:
            Given two dates "YYYY-MM-DD", return the absolute number of days between them.
            */
        return  Math.Abs(endDate.Day - startDate.Day);
    }
    internal static (int years, int months, int days) CalculateAge(this DateOnly dob)
    {
        int ageIndays =  Math.Abs(DateOnly.FromDateTime(DateTime.Now).DayNumber - dob.DayNumber);
        var years = ageIndays / 365;
        var months = (ageIndays - (years * 365)) / 30;
        var days = ageIndays - years * 365 - months * 30;
        return (years, months, days);
        // return $"{years} Years, {months} months and {days} days";
    }
    internal static int CalculateDuration(TimeOnly start, TimeOnly end)
    {
        var duration = end.ToTimeSpan() - start.ToTimeSpan();
        return (int)duration.TotalMinutes;
    }
}