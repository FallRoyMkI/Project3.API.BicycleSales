namespace BicycleSales.Constants;

public class InvalidTimeException : Exception
{
    public InvalidTimeException(DateTime plannedTime)
        : base($"Trying to add invalid time: {plannedTime}") { }
}