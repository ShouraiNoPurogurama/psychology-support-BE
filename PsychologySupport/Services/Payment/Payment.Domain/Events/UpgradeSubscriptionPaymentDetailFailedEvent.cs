﻿using BuildingBlocks.DDD;
using MediatR;

namespace Payment.Domain.Events;

public record UpgradeSubscriptionPaymentDetailFailedEvent(
    Guid SubscriptionId,
    string PatientEmail,
    string? PromoCode,
    Guid? GiftId,
    decimal FinalPrice) : IDomainEvent;