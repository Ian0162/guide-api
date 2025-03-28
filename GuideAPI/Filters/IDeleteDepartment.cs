using GuideAPI.Dto;
using MediatR;

namespace GuideAPI.Filters
{
    public class IDeleteDepartment : IRequest<DefaultResponse>
    {
        public int Id;
        public IDeleteDepartment( int Id)
        {
            this.Id = Id;
        }
    }
}
