namespace BicycleSales.Constants;

public class ObjectNotExistException : Exception
{
    public ObjectNotExistException(string objectName,int id)
        : base($"{objectName} with Id = {id} not exist") { }
}