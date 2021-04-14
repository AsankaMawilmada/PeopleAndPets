using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace PeopleAndPets.Core.Tests.Helpers
{
    public class MoqHttpMessageHandler : DelegatingHandler
    {
        private HttpResponseMessage _moqResponse;

        public MoqHttpMessageHandler(HttpResponseMessage responseMessage)
        {
            _moqResponse = responseMessage;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(_moqResponse);
        }
    }
}
