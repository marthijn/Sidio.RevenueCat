using RestSharp;
using Sidio.RevenueCat.Api.V2;

namespace Sidio.RevenueCat.Tests.Api.V2;

public sealed class RevenueCatV2ClientTests
{
    private readonly IFixture _fixture = new Fixture();

    private static RevenueCatV2Client CreateClient(out Mock<IRestClient> restClientMock)
    {
        restClientMock = new Mock<IRestClient>();
        var client = RevenueCatV2Client.Create(restClientMock.Object);
        return client;
    }
}