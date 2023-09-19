namespace Bll.Exceptions;

public class ModelIsEmptyException : Exception
{
    public ModelIsEmptyException() 
        : base("Invalid model: one or several fields were empty")
    {
    }
}