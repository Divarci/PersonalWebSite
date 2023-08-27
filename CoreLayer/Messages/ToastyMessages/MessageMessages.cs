namespace CoreLayer.Messages.ToastyMessages
{
    // special messages added for Messages

    public interface IMessageMessages : IGenericMessages
    {
        string MessageSent();
        string MessageDeleted();
    }

    public class MessageMessages : GenericMessages, IMessageMessages
    {
        public string MessageSent()
        {
            return "Message has been sent Successfully!";
        }
        public string MessageDeleted()
        {
            return "Message has been deleted Successfully!";
        }
    }
}
