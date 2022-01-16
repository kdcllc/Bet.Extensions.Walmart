using System.Text.Json;

using Bet.Extensions.Walmart.Models.Notifications.Webhook;

using Xunit;

namespace Bet.Extensions.Walmart.UnitTest
{
    public class WebhookModelsTests
    {
        [Fact]
        public async Task POCreatedEvent_Parse_Successfully()
        {
            using var stream = File.OpenRead(Path.Combine("Data", $"{nameof(POCreatedEvent)}.json"));
            var model = await JsonSerializer.DeserializeAsync<POCreatedEvent>(stream);

            Assert.NotNull(model);

            Assert.Equal("PO_CREATED", model?.Source?.EventType);

            Assert.Equal("Created", model?.Payload?.OrderLines[1]?.Status);
        }

        [Fact]
        public async Task POLineAutoCancelledEvent_Parse_Successfully()
        {
            using var stream = File.OpenRead(Path.Combine("Data", $"{nameof(POLineAutoCancelledEvent)}.json"));
            var model = await JsonSerializer.DeserializeAsync<POLineAutoCancelledEvent>(stream);

            Assert.NotNull(model);

            Assert.Equal("PO_LINE_AUTOCANCELLED", model?.Source?.EventType);

            Assert.Equal("Cancelled", model?.Payload?.OrderLines[0]?.Status);

            Assert.Equal("Auto-cancelled due to expiry", model?.Payload?.OrderLines[0]?.CancellationReason);
        }

        [Fact]
        public async Task OfferPublishdEvent_Parse_Successfully()
        {
            using var stream = File.OpenRead(Path.Combine("Data", $"{nameof(OfferPublishedEvent)}.json"));
            var model = await JsonSerializer.DeserializeAsync<OfferPublishedEvent>(stream);

            Assert.NotNull(model);

            Assert.Equal("OFFER_PUBLISHED", model?.Source?.EventType);

            Assert.Equal("PUBLISHED", model?.Payload.PublishStatus);

            Assert.Equal("ACTIVE", model?.Payload?.LifecycleStatus);
        }

        [Fact]
        public async Task OfferUnpublishedEvent_Parse_Successfully()
        {
            using var stream = File.OpenRead(Path.Combine("Data", $"{nameof(OfferUnpublishedEvent)}.json"));
            var model = await JsonSerializer.DeserializeAsync<OfferUnpublishedEvent>(stream);

            Assert.NotNull(model);

            Assert.Equal("OFFER_UNPUBLISHED", model?.Source?.EventType);

            Assert.Equal("UNPUBLISHED", model?.Payload.PublishStatus);

            Assert.Equal("ACTIVE", model?.Payload?.LifecycleStatus);

            Assert.Equal("Reasonable price requirements are not met", model?.Payload.StatusChangeReasons.FirstOrDefault(x => x.Key == "REASONABLE_PRICE_NOT_SATISFIED").Value);
        }
    }
}
