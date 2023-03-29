namespace Login.Utils.Exceptions
{
    public class DuplicateEntityException : Exception
    {
        public DuplicateEntityException()
            : base() { }

        public DuplicateEntityException(String message)
            : base(message) { }
    }
}
