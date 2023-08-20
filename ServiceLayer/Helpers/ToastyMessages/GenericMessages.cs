namespace ServiceLayer.Helpers.ToastyMessages
{
    //toast message interface
    public interface IGenericMessages
    {
        string Add(string Title);
        string Update(string Title);
        string Delete(string Title);
        string Denied();
        string ImageError();
    }

    //toast message class
    public class GenericMessages : IGenericMessages
    {
        public string Add(string Title)
        {
            return $"{Title} has been created Successfully!";
        }
        public string Update(string Title)
        {
            return $"{Title} has been updated Successfully!";
        }
        public string Delete(string Title)
        {
            return $"{Title} has been deleted Successfully!";
        }
        public string Denied()
        {
            return "Operation Unsuccesful!";
        }
        public string ImageError()
        {
            return "You have to upload a JPG,JPeG or PNG file!";
        }

    }
}
