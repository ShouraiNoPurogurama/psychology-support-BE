﻿namespace BuildingBlocks.Messaging.Events.Payment;

public record GetPendingPaymentUrlForSubscriptionRequest(Guid SubscriptionId);