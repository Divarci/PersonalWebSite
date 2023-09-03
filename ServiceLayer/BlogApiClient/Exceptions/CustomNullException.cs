namespace ServiceLayer.BlogApiClient.Exceptions
{
    public class CustomNullException : Exception
    {
        public CustomNullException(string? message) : base(message)
        {
        }
    }
}
