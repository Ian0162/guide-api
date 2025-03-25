using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace GuideAPI.Data.Config
{
    public class Department : IEntityTypeConfiguration<Models.Department>
    {
        public void Configure(EntityTypeBuilder<Models.Department> builder)
        {
            builder.HasData(
                new Models.Department { Id = 1, departmentName = "Software Development", isHidden = false, createdBy = 1, createdDate = DateTimeOffset.UtcNow.DateTime },
                new Models.Department { Id = 2, departmentName = "Marketing", isHidden = false, createdBy = 1, createdDate = DateTimeOffset.UtcNow.DateTime },
                new Models.Department { Id = 3, departmentName = "Admin", isHidden = false, createdBy = 1, createdDate = DateTimeOffset.UtcNow.DateTime },
                new Models.Department { Id = 4, departmentName = "Human Resources", isHidden = false, createdBy = 1, createdDate = DateTimeOffset.UtcNow.DateTime },
                new Models.Department { Id = 5, departmentName = "Finance", isHidden = false, createdBy = 1, createdDate = DateTimeOffset.UtcNow.DateTime },
                new Models.Department { Id = 6, departmentName = "Operations", isHidden = false, createdBy = 1, createdDate = DateTimeOffset.UtcNow.DateTime },
                new Models.Department { Id = 7, departmentName = "Sales", isHidden = false, createdBy = 1, createdDate = DateTimeOffset.UtcNow.DateTime },
                new Models.Department { Id = 8, departmentName = "Customer Support", isHidden = false, createdBy = 1, createdDate = DateTimeOffset.UtcNow.DateTime },
                new Models.Department { Id = 9, departmentName = "Legal", isHidden = false, createdBy = 1, createdDate = DateTimeOffset.UtcNow.DateTime },
                new Models.Department { Id = 10, departmentName = "Product Management", isHidden = false, createdBy = 1, createdDate = DateTimeOffset.UtcNow.DateTime },
                new Models.Department { Id = 11, departmentName = "Engineering", isHidden = false, createdBy = 1, createdDate = DateTimeOffset.UtcNow.DateTime },
                new Models.Department { Id = 12, departmentName = "Business Development", isHidden = false, createdBy = 1, createdDate = DateTimeOffset.UtcNow.DateTime },
                new Models.Department { Id = 13, departmentName = "Quality Assurance", isHidden = false, createdBy = 1, createdDate = DateTimeOffset.UtcNow.DateTime },
                new Models.Department { Id = 14, departmentName = "Research & Development", isHidden = false, createdBy = 1, createdDate = DateTimeOffset.UtcNow.DateTime },
                new Models.Department { Id = 15, departmentName = "IT Support", isHidden = false, createdBy = 1, createdDate = DateTimeOffset.UtcNow.DateTime },
                new Models.Department { Id = 16, departmentName = "Design", isHidden = false, createdBy = 1, createdDate = DateTimeOffset.UtcNow.DateTime },
                new Models.Department { Id = 17, departmentName = "Procurement", isHidden = false, createdBy = 1, createdDate = DateTimeOffset.UtcNow.DateTime },
                new Models.Department { Id = 18, departmentName = "Training", isHidden = false, createdBy = 1, createdDate = DateTimeOffset.UtcNow.DateTime },
                new Models.Department { Id = 19, departmentName = "Public Relations", isHidden = false, createdBy = 1, createdDate = DateTimeOffset.UtcNow.DateTime },
                new Models.Department { Id = 20, departmentName = "Compliance", isHidden = false, createdBy = 1, createdDate = DateTimeOffset.UtcNow.DateTime }
            );

        }
    }
}
