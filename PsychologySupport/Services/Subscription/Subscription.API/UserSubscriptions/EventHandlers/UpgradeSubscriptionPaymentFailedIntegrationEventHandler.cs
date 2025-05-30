﻿using BuildingBlocks.Messaging.Events.Subscription;
using MassTransit;
using MediatR;
using Promotion.Grpc;
using Subscription.API.Data.Common;
using Subscription.API.UserSubscriptions.Features.UpdateSubscriptionStatus;

namespace Subscription.API.UserSubscriptions.EventHandlers;

public class UpgradeSubscriptionPaymentFailedIntegrationEventHandler(
    PromotionService.PromotionServiceClient promotionService,
    ISender sender) : IConsumer<UpgradeSubscriptionPaymentFailedIntegrationEvent>
{
    public async Task Consume(ConsumeContext<UpgradeSubscriptionPaymentFailedIntegrationEvent> context)
    {
        var message = context.Message;

        var giftId = message.GiftId.ToString();

        if (!string.IsNullOrWhiteSpace(message.PromoCode))
        {
            await promotionService.ReactivatePromoCodeAsync(new ReactivatePromoCodeRequest()
            {
                PromoCode = message.PromoCode
            });
        }

        if (!string.IsNullOrWhiteSpace(giftId))
        {
            await promotionService.ReactivateGiftCodeAsync(new ReactivateGiftCodeRequest()
            {
                GiftId = giftId
            });
        }

        await sender.Send(new UpdateUserSubscriptionStatusCommand(message.SubscriptionId, SubscriptionStatus.Cancelled));
    }
}