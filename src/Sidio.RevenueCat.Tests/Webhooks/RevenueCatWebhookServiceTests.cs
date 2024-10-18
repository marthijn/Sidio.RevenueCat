using System.Reflection;
using Microsoft.Extensions.Logging.Abstractions;
using Sidio.RevenueCat.Webhooks;

namespace Sidio.RevenueCat.Tests.Webhooks;

public sealed class RevenueCatWebhookServiceTests
{
    [Theory]
    [InlineData("Transfer.json", true)]
    [InlineData("InitialPurchase.json", false)]
    public void IsTransferEvent(string filename, bool isTransferEvent)
    {
        // arrange
        var service = new RevenueCatWebhookService(NullLogger<RevenueCatWebhookService>.Instance);
        var fileData = GetFileContents(filename);

        // act
        var result = service.IsTransferEvent(fileData);

        // assert
        result.Should().Be(isTransferEvent);
    }

    [Fact]
    public void TryParseSubscriptionEvent_InitialPurchase()
    {
        // arrange
        var service = new RevenueCatWebhookService(NullLogger<RevenueCatWebhookService>.Instance);
        var fileData = GetFileContents("InitialPurchase.json");

        // act
        var result = service.TryParseSubscriptionEvent(fileData, out var content);

        // assert
        result.Should().BeTrue();
        content!.ProductId.Should().Be("com.subscription.weekly");
        content.Type.Should().Be("INITIAL_PURCHASE");
        content.Price.Should().Be(4.99);
        content.PriceInPurchasedCurrency.Should().Be(4.99);
        content.Currency.Should().Be("USD");

        var email = content.SubscriberAttributes.FirstOrDefault(x => x.Key == "$email");
        email.Should().NotBeNull();
        email.Value.Value.Should().Be("firstlast@gmail.com");
    }

    [Fact]
    public void TryParseSubscriptionEvent_Renewal()
    {
        // arrange
        var service = new RevenueCatWebhookService(NullLogger<RevenueCatWebhookService>.Instance);
        var fileData = GetFileContents("Renewal.json");

        // act
        var result = service.TryParseSubscriptionEvent(fileData, out var content);

        // assert
        result.Should().BeTrue();
        content!.ProductId.Should().Be("com.subscription.weekly");
        content.Type.Should().Be("RENEWAL");
        content.IsTrialConversion.Should().BeFalse();
    }

    [Fact]
    public void TryParseSubscriptionEvent_Cancellation()
    {
        // arrange
        var service = new RevenueCatWebhookService(NullLogger<RevenueCatWebhookService>.Instance);
        var fileData = GetFileContents("Cancellation.json");

        // act
        var result = service.TryParseSubscriptionEvent(fileData, out var content);

        // assert
        result.Should().BeTrue();
        content!.ProductId.Should().Be("com.revenuecat.myapp.weekly");
        content.Type.Should().Be("CANCELLATION");
        content.CancelReason.Should().Be("UNSUBSCRIBE");
    }

    [Fact]
    public void TryParseSubscriptionEvent_Uncancellation()
    {
        // arrange
        var service = new RevenueCatWebhookService(NullLogger<RevenueCatWebhookService>.Instance);
        var fileData = GetFileContents("Uncancellation.json");

        // act
        var result = service.TryParseSubscriptionEvent(fileData, out var content);

        // assert
        result.Should().BeTrue();
        content!.ProductId.Should().Be("com.subscription.monthly");
        content.Type.Should().Be("UNCANCELLATION");
        content.Store.Should().Be("APP_STORE");
    }

    [Fact]
    public void TryParseSubscriptionEvent_NonRenewingPurchase()
    {
        // arrange
        var service = new RevenueCatWebhookService(NullLogger<RevenueCatWebhookService>.Instance);
        var fileData = GetFileContents("NonRenewingPurchase.json");

        // act
        var result = service.TryParseSubscriptionEvent(fileData, out var content);

        // assert
        result.Should().BeTrue();
        content!.ProductId.Should().Be("2100_tokens");
        content.Type.Should().Be("NON_RENEWING_PURCHASE");
        content.Price.Should().Be(25.487);
        content.PriceInPurchasedCurrency.Should().Be(32.99);
        content.Currency.Should().Be("CAD");
        content.EntitlementIds.Should().Contain("pro");
    }

    [Fact]
    public void TryParseSubscriptionEvent_SubscriptionPaused()
    {
        // arrange
        var service = new RevenueCatWebhookService(NullLogger<RevenueCatWebhookService>.Instance);
        var fileData = GetFileContents("SubscriptionPaused.json");

        // act
        var result = service.TryParseSubscriptionEvent(fileData, out var content);

        // assert
        result.Should().BeTrue();
        content!.ProductId.Should().Be("premium");
        content.Type.Should().Be("SUBSCRIPTION_PAUSED");
        content.EntitlementIds.Should().Contain("Premium1");
    }

    [Fact]
    public void TryParseSubscriptionEvent_BillingIssue()
    {
        // arrange
        var service = new RevenueCatWebhookService(NullLogger<RevenueCatWebhookService>.Instance);
        var fileData = GetFileContents("BillingIssue.json");

        // act
        var result = service.TryParseSubscriptionEvent(fileData, out var content);

        // assert
        result.Should().BeTrue();
        content!.ProductId.Should().Be("com.revenuecat.myapp.monthly");
        content.Type.Should().Be("BILLING_ISSUE");
    }

    [Fact]
    public void TryParseSubscriptionEvent_Expiration()
    {
        // arrange
        var service = new RevenueCatWebhookService(NullLogger<RevenueCatWebhookService>.Instance);
        var fileData = GetFileContents("Expiration.json");

        // act
        var result = service.TryParseSubscriptionEvent(fileData, out var content);

        // assert
        result.Should().BeTrue();
        content!.ProductId.Should().Be("com.subscription.weekly");
        content.Type.Should().Be("EXPIRATION");
        content.ExpirationReason.Should().Be("UNSUBSCRIBE");
    }

    [Fact]
    public void TryParseSubscriptionEvent_Refund()
    {
        // arrange
        var service = new RevenueCatWebhookService(NullLogger<RevenueCatWebhookService>.Instance);
        var fileData = GetFileContents("Refund.json");

        // act
        var result = service.TryParseSubscriptionEvent(fileData, out var content);

        // assert
        result.Should().BeTrue();
        content!.ProductId.Should().Be("com.revenuecat.myapp.monthly");
        content.Type.Should().Be("CANCELLATION");
        content.CancelReason.Should().Be("CUSTOMER_SUPPORT");
    }

    [Fact]
    public void TryParseSubscriptionEvent_ProductChange()
    {
        // arrange
        var service = new RevenueCatWebhookService(NullLogger<RevenueCatWebhookService>.Instance);
        var fileData = GetFileContents("ProductChange.json");

        // act
        var result = service.TryParseSubscriptionEvent(fileData, out var content);

        // assert
        result.Should().BeTrue();
        content!.ProductId.Should().Be("com.revenuecat.myapp.monthly");
        content.Type.Should().Be("PRODUCT_CHANGE");
    }

    [Fact]
    public void TryParseSubscriptionEvent_SubscriptionExtended()
    {
        // arrange
        var service = new RevenueCatWebhookService(NullLogger<RevenueCatWebhookService>.Instance);
        var fileData = GetFileContents("SubscriptionExtended.json");

        // act
        var result = service.TryParseSubscriptionEvent(fileData, out var content);

        // assert
        result.Should().BeTrue();
        content!.ProductId.Should().Be("com.subscription.weekly");
        content.Type.Should().Be("SUBSCRIPTION_EXTENDED");
    }

    [Fact]
    public void TryParseSubscriptionEvent_TrialStarted()
    {
        // arrange
        var service = new RevenueCatWebhookService(NullLogger<RevenueCatWebhookService>.Instance);
        var fileData = GetFileContents("TrialStarted.json");

        // act
        var result = service.TryParseSubscriptionEvent(fileData, out var content);

        // assert
        result.Should().BeTrue();
        content!.ProductId.Should().Be("com.subscription.yearly");
        content.Type.Should().Be("INITIAL_PURCHASE");
    }

    [Fact]
    public void TryParseSubscriptionEvent_TrialCancelled()
    {
        // arrange
        var service = new RevenueCatWebhookService(NullLogger<RevenueCatWebhookService>.Instance);
        var fileData = GetFileContents("TrialCancelled.json");

        // act
        var result = service.TryParseSubscriptionEvent(fileData, out var content);

        // assert
        result.Should().BeTrue();
        content!.ProductId.Should().Be("com.subscription.weekly");
        content.Type.Should().Be("CANCELLATION");
    }

    [Fact]
    public void TryParseTransferEvent_Transfer()
    {
        // arrange
        var service = new RevenueCatWebhookService(NullLogger<RevenueCatWebhookService>.Instance);
        var fileData = GetFileContents("Transfer.json");

        // act
        var result = service.TryParseTransferEvent(fileData, out var content);

        // assert
        result.Should().BeTrue();
        content!.Type.Should().Be("TRANSFER");
        content.TransferredFrom.Should().Contain("00005A1C-6091-4F81-BE77-F0A83A271AB6");
        content.TransferredTo.Should().Contain("4BEDB450-8EF2-11E9-B475-0800200C9A66");
    }

    [Fact]
    public void TryParseSubscriptionEvent_Transfer()
    {
        // arrange
        var service = new RevenueCatWebhookService(NullLogger<RevenueCatWebhookService>.Instance);
        var fileData = GetFileContents("Transfer.json");

        // act
        var result = service.TryParseSubscriptionEvent(fileData, out var content);

        // assert
        result.Should().BeFalse();
    }

    private static string GetFileContents(string filename)
    {
        var fullPath =
            $"Sidio.RevenueCat.Tests.Webhooks.TestData.{filename}";
        var assembly = Assembly.GetExecutingAssembly();

        using var stream = assembly.GetManifestResourceStream(fullPath);
        using var reader = new StreamReader(stream!);

        var jsonFile = reader.ReadToEnd();

        jsonFile.Should().NotBeNullOrEmpty("{0} should not be null or empty.", filename);

        return jsonFile;
    }
}