namespace GuideAPI.Models
{
    public abstract class BaseModel
    {
        public int Id { get; set; }
        public DateTime? CreatedAt { get; set; } // created_at
        public DateTime? UpdatedAt { get; set; } // updated_at
        public DateTime? DeletedAt { get; set; } // deleted_at
        public int createdBy { get; set; }
        public string? updatedBy { get; set; }
    }
}
