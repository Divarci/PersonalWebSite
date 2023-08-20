namespace CoreLayer.BaseEntity
{
    public abstract class BaseEntity
    {
        //Primary Key
        public int Id { get; set; }

        //Information
        public string CreatedDate { get; set; } = null!;
        public string? UpdatedDate { get; set; }

        //Check Constraint       
        public byte[] RowVersion { get; set; } = null!;
    }
}
