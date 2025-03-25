namespace GuideAPI.Dto
{
    public class DepartmentTableDto
    {
        public DateOnly? startDate { get; set; } = null;
        public DateOnly? endDate { get; set; } = null;
        public string? searchString { get; set; }
        public int page { get; set; }
        public int rowsPerPage { get; set; }
    }
}
