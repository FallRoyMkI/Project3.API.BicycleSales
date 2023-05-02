namespace BicycleSales.Constants;

public class WorkWithForbiddenResourceException : Exception
{
    public WorkWithForbiddenResourceException(string objectName, int id)
        : base($"{objectName} with {id} was already completed") { }
}