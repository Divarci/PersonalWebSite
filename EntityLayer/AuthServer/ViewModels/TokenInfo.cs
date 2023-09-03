namespace EntityLayer.AuthServer.ViewModels
{
    public class TokenInfo
    {
        public List<string> Audience { get; set; } = null!;
        public string Issuer { get; set; } = null!;

        public int AccessTokenExpireDate { get; set; }
        public int RefreshTokenExpiredate { get; set; }

        public string SecurityKey { get; set; } = null!;
    }
}
