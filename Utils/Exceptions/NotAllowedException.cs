namespace Login.Utils.Exceptions;

public class NotAllowedException : Exception
{
    public NotAllowedException()
        : base() { }

    public NotAllowedException(String message)
        : base(message) { }
}
