using CoreLayer.BaseEntity;

namespace EntityLayer.WebApplication.Entities
{
    public class Fact : BaseEntity
    {       
        //Fact Section
        public int DaysOfStudy { get; set; }
        public int Project { get; set; }
        public int CodingLanguage { get; set; }
        public int Certificate { get; set; }

        //Relation with AboutMe(parent)
        public AboutMe AboutMe { get; set; } = null!;
        public int AboutMeId { get; set; }

       
    }
}
