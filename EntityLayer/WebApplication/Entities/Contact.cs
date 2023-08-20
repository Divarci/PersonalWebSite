using CoreLayer.BaseEntity;

namespace EntityLayer.WebApplication.Entities
{
    public class Contact : BaseEntity
    {       
        //Contact Section
        public string Address { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string LocationUrl { get; set; } = null!;

        //Relation with AboutMe(parent)
        public AboutMe AboutMe { get; set; } = null!;   
        public int AboutMeId { get; set; }


    }
}
