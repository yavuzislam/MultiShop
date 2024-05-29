using MultiShop.WebUI.Services.Interfaces;
using System.Net;
using System.Net.Http.Headers;

namespace MultiShop.WebUI.Handlers;

public class ClientCredentialTokenHandler : DelegatingHandler
{
    private readonly IClientCredentialTokenService _clientCredentialTokenService;

    public ClientCredentialTokenHandler(IClientCredentialTokenService clientCredentialTokenService)
    {
        _clientCredentialTokenService = clientCredentialTokenService;
    }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var accessToken = await _clientCredentialTokenService.GetToken();
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
        var response = await base.SendAsync(request, cancellationToken);
        if (response.StatusCode == HttpStatusCode.Unauthorized)
        {
            //hata mejası
        }
        return response;
    }
}
