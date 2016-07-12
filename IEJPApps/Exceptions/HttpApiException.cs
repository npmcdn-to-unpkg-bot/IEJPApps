using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace IEJPApps.Exceptions
{
    public class HttpApiException : HttpResponseException
    {
        public HttpApiException(string message, string reason = null)
            : base(HttpStatusCode.BadRequest)
        {
            Response.Content = new StringContent(message);
            
            if (!string.IsNullOrWhiteSpace(reason))
            {
                Response.ReasonPhrase = reason;
            }
        }
    }
}