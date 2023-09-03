using CoreLayer.BaseEntity;

namespace EntityLayer.AuthServer.Entities
{
    public class RefreshToken
    {
        public string UserId { get; set; } = null!;
        public string Code { get; set; } = null!;
        public DateTime ExpireDate { get; set; }
    }
}
