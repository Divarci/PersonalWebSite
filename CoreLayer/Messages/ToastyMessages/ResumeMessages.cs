namespace CoreLayer.Messages.ToastyMessages
{
    // special messages added for Resume

    public interface IResumeMessages : IGenericMessages
    {
        string Inaktivated(string title);
        string Aktivated(string title);
        string CanNotDelete(string title);
        string Published(string title);
        string Editable(string title);
    }

    public class ResumeMessages : GenericMessages, IResumeMessages
    {
        public string Aktivated(string title)
        {
            return $"{title} has been activated Successfully!";
        }

        public string CanNotDelete(string title)
        {
            return $"{title} can not be inaktivated if it is editable or published!";
        }

        public string Editable(string title)
        {
            return $"{title} is now editable!";
        }

        public string Inaktivated(string title)
        {
            return $"{title} has been inactivated Successfully!";
        }

        public string Published(string title)
        {
            return $"{title} is now published!"; ;
        }
    }
}
