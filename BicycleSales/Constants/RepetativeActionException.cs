namespace BicycleSales.Constants;
public class RepetativeActionException : Exception
{
    public RepetativeActionException(string action, string objectName)
        : base($"{action} this {objectName} was done earlier") { }
}