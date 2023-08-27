namespace CoreLayer.Errors
{
    public class ErrorVM
    {
        public List<string> Errors { get; set; } = new List<string>();

        public bool IsShow { get; set; }

        public ErrorVM()
        {
            Errors = new List<string>();
        }
        public ErrorVM(string error)
        {
            Errors.Add(error);
        }

        public ErrorVM(string error, bool isShow)
        {
            Errors.Add(error);
            isShow = true;
        }
        public ErrorVM(List<string> error, bool isShow)
        {
            Errors = error;
            IsShow = isShow;
        }
    }
}
