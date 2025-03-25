using GuideAPI.Dto;
using GuideAPI.Models;
using MediatR;

namespace GuideAPI.Filters
{
    public class IDepartmentPagination : IRequest<DepartmentTableResponse<Department>>
    {
        public DateOnly? startDate { get; set; } = null;
        public DateOnly? endDate { get; set; } = null;
        public string? searchString { get; set; }
        public int page { get; set; }
        public int rowsPerPage { get; set; }

        public IDepartmentPagination(DepartmentTableDto request)
        {
            startDate = request.startDate;
            endDate = request.endDate;
            searchString = request.searchString;
            page = request.page;
            rowsPerPage = request.rowsPerPage;
        }
    }
}
