using GuideAPI.Dto;
using GuideAPI.Handler;
using GuideAPI.Models;

namespace GuideAPI.Exceptions
{
    public static class ThrowHttp
    {
        public static DefaultResponse Response(bool isErr, int responseCode, string responseMessage)
        {
            return new DefaultResponse
            {
                isErr = isErr,
                responseCode = responseCode,
                responseMessage = responseMessage
            };
        }

        public static DepartmentTableResponse<Department> PageResponse(bool isErr, int responseCode, string responseMessage)
        {

            return new DepartmentTableResponse<Department>
            {
                isErr = isErr,
                responseCode = responseCode,
                responseMessage = responseMessage
            };
        }
    }
}
