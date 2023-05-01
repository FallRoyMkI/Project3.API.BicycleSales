namespace BicycleSales.Constants;

public class WorkWithForribenResourceException : Exception
{
    public WorkWithForribenResourceException(string objectName, int id)
        : base($"{objectName} with {id} was already completed") { }
}