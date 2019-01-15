using System;
using Refit;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace Core.DI
{
    public class NetworkModule<T>
    {
        private AppHttpClientHandler ProvideHTTPClient()
        {
            return new AppHttpClientHandler();
        }

        public T CreateWebService() => RestService.For<T>(
                   new HttpClient(ProvideHTTPClient())
                   {
                       BaseAddress = new Uri("https://api.github.com")
                   });
    }

    internal class AppHttpClientHandler : HttpClientHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var acceptHeader = new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json");
            request.Headers.Accept.Add(acceptHeader);

            return await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
        }
    }
}
