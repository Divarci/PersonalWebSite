namespace EntityLayer.Identity.ViewModes
{
    public class EmailOptionsVM
    {

        //keeps data for email provider
        public string Host { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Email { get; set; } = null!;
    }
}
