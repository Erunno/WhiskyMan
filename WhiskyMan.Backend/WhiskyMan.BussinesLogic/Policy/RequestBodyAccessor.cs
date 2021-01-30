using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhiskyMan.BusinessLogic.Interfaces.Policy;

namespace WhiskyMan.BusinessLogic.Policy
{
    public class RequestBodyAccessor : IRequestBodyAccessor
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        public RequestBodyAccessor(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        public async Task<TBody> GetRequestBody<TBody>()
        {
            var bodyStr = "";
            var req = httpContextAccessor.HttpContext.Request;

            // Allows using several time the stream in ASP.Net Core
            req.EnableBuffering();

            // Arguments: Stream, Encoding, detect encoding, buffer size 
            // AND, the most important: keep stream opened
            using (StreamReader reader
                      = new StreamReader(req.Body, Encoding.UTF8, true, 1024, true))
            {
                bodyStr = await reader.ReadToEndAsync();
            }

            // Rewind, so the core is not lost when it looks the body for the request
            req.Body.Position = 0;

            return JsonConvert.DeserializeObject<TBody>(bodyStr);
        }
    }
}
