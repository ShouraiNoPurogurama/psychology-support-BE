﻿namespace BuildingBlocks.Messaging.Events.Subscription;

public record UpgradeSubscriptionPaymentSuccessIntegrationEvent(Guid SubscriptionId) : IntegrationEvents;