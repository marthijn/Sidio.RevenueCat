using System.Net;
using System.Text.Json;
using RestSharp;
using RestSharp.Serializers;
using Sidio.RevenueCat.Api.V1;
using Sidio.RevenueCat.Api.V1.Responses;

namespace Sidio.RevenueCat.Tests.Api.V1;

public sealed class RevenueCatV1ClientTests
{
    private readonly IFixture _fixture = new Fixture();

    [Fact]
    public async Task GetOrCreateSubscriberAsync_ReturnsData()
    {
        // arrange
        var client = CreateClient(out var restClientMock);
        var userId = _fixture.Create<string>();
        var data = _fixture.Create<SubscriberResponse>();
        var responseData = JsonSerializer.Serialize(data);
        var response = new RestResponse<SubscriberResponse>(new RestRequest()) { StatusCode = HttpStatusCode.OK, Content = responseData, };

        restClientMock.Setup(x => x.ExecuteAsync(It.IsAny<RestRequest>(), It.IsAny<CancellationToken>())).ReturnsAsync(response);

        // act
        var result = await client.GetOrCreateSubscriberAsync(userId);

        // assert
        result.Should().NotBeNull();
        result.StatusCode.Should().Be(HttpStatusCode.OK);
        result.Data.Should().BeEquivalentTo(data);
    }

    private static RevenueCatV1Client CreateClient(out Mock<IRestClient> restClientMock)
    {
        var config = new SerializerConfig();
        config.UseDefaultSerializers();
        restClientMock = new Mock<IRestClient>();
        restClientMock.Setup(x => x.Serializers).Returns(new RestSerializers(config));

        var client = RevenueCatV1Client.Create(restClientMock.Object);
        return client;
    }
}