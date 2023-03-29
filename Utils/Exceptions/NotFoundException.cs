namespace Login.Utils.Exceptions;

public class NotFoundException : Exception
{
    public NotFoundException()
        : base() { }

    public NotFoundException(String message)
        : base(message) { }
}
