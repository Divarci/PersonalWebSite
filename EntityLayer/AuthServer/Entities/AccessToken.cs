namespace EntityLayer.AuthServer.Entities
{
    public class AccessToken
    {
        public string UserId { get; set; } = null!;
        public string Code { get; set; } = null!;
        public DateTime ExpireDate { get; set; }
    }
}
