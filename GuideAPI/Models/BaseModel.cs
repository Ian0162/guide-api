namespace GuideAPI.Models
{
    public abstract class BaseModel
    {
        public int Id { get; set; }
        public DateTime? createdDate { get; set; }
        public DateTime? updatedDate { get; set; }
        public DateTime? deleteDate { get; set; }
        public int createdBy { get; set; }
        public string? updatedBy { get; set; }
    }
}
