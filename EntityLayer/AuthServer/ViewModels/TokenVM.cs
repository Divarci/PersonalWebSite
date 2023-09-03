namespace EntityLayer.AuthServer.ViewModels
{
    public class TokenVM
    {
        public string AccessToken { get; set; } = null!;
        public DateTime AccessTokenExpireDate { get; set; }
        public string RefreshToken { get; set; } = null!;
        public DateTime RefreshTokenExpireDate { get; set; }
    }
}
