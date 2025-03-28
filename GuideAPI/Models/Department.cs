using System.ComponentModel.DataAnnotations;

namespace GuideAPI.Models
{
    public class Department : BaseModel
    {
        public string departmentName { get; set; }
        public bool isHidden { get; set; }
    }
}
