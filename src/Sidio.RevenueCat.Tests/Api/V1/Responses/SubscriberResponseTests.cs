using System.Reflection;
using System.Text.Json;
using Sidio.RevenueCat.Api.V1.Responses;

namespace Sidio.RevenueCat.Tests.Api.V1.Responses;

public sealed class SubscriberResponseTests
{
    [Fact]
    public void Deserialize_ReturnsModel()
    {
        // arrange
        var fileContent = GetFileContents("SubscriberResponse.json");

        // act
        var result = JsonSerializer.Deserialize<SubscriberResponse>(fileContent);

        // assert
        result.Should().NotBeNull();
        result!.Subscriber.OriginalAppUserId.Should().Be("XXX-XXXXX-XXXXX-XX");
        result.Subscriber.Entitlements.Count.Should().Be(2);
        result.Subscriber.Entitlements.Should().ContainKeys("pro_cat", "pro_cat2");
    }

    private static string GetFileContents(string filename)
    {
        var fullPath =
            $"Sidio.RevenueCat.Tests.Api.V1.Responses.TestData.{filename}";
        var assembly = Assembly.GetExecutingAssembly();

        using var stream = assembly.GetManifestResourceStream(fullPath);
        using var reader = new StreamReader(stream!);

        var jsonFile = reader.ReadToEnd();

        jsonFile.Should().NotBeNullOrEmpty("{0} should not be null or empty.", filename);

        return jsonFile;
    }
}