using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace ApiGateway.Handlers
{
    public class RemoveEncodingDelegatingHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            request.Headers.AcceptEncoding.Clear(); /*Borrar el encoding de los headers de la peticion*/
            return await base.SendAsync(request, cancellationToken);
        }
    }
}
