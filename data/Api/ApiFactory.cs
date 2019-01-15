using System;
using Refit;
using System.Net.Http;

namespace Data.Api
{
    public class ApiFactory<T> /*: IApiFactory<T>*/
    {
        private readonly AppHttpClientHandler ClientHandler;

        public ApiFactory(AppHttpClientHandler clientHandler)
        {
            this.ClientHandler = clientHandler;
        }

        public T Create() => RestService.For<T>(
                new HttpClient(new AppHttpClientHandler())
                {
                    BaseAddress = new Uri("https://api.github.com")
                });

        /*T IApiFactory<T>.Create()
        {
            throw new NotImplementedException();
        }*/
    }
}