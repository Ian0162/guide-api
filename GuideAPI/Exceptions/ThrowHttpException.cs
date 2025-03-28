using Azure;
using System.Net;
using System.Web.Http;

namespace GuideAPI.Exceptions
{
    public static class ThrowHttpException
    {
        public static HttpResponseException Throw(HttpStatusCode statusCode, string message, string reasonPhrase = null)
        {
            var response = new HttpResponseMessage(statusCode)
            {
                Content = new StringContent(message),
                ReasonPhrase = reasonPhrase ?? statusCode.ToString()
            };

            return new HttpResponseException(response);
        }
    }
}
