using CoreLayer.BaseEntity;

namespace EntityLayer.WebApplication.Entities
{
    public class SocialMedia : BaseEntity
    {
        //Social Media Section
        public string? GitHub { get; set; }
        public string? Twitter { get; set; }
        public string? LinkedIn { get; set; }
        public string? Youtube { get; set; }

        //Relation with AboutMe(parent)
        public AboutMe AboutMe { get; set; } = null!;
        public int AboutMeId { get; set; }
    }
}
