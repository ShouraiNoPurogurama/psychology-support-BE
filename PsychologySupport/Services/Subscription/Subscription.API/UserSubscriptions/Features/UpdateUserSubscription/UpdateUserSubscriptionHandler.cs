﻿using BuildingBlocks.CQRS;
using Mapster;
using Subscription.API.Data;
using Subscription.API.Exceptions;
using Subscription.API.UserSubscriptions.Dtos;

namespace Subscription.API.UserSubscriptions.Features.UpdateUserSubscription;

//TODO Only status of subscription can be updated
public record UpdateUserSubscriptionCommand(UserSubscriptionDto UserSubscription) : ICommand<UpdateUserSubscriptionResult>;

public record UpdateUserSubscriptionResult(bool IsSuccess);

public class UpdateUserSubscriptionHandler : ICommandHandler<UpdateUserSubscriptionCommand, UpdateUserSubscriptionResult>
{
    private readonly SubscriptionDbContext _context;

    public UpdateUserSubscriptionHandler(SubscriptionDbContext context)
    {
        _context = context;
    }

    public async Task<UpdateUserSubscriptionResult> Handle(UpdateUserSubscriptionCommand request,
        CancellationToken cancellationToken)
    {
        var existingSubscription = await _context.UserSubscriptions.FindAsync(request.UserSubscription.Id, cancellationToken)
                                   ?? throw new SubscriptionNotFoundException("User Subscription", request.UserSubscription.Id);

        existingSubscription = request.UserSubscription.Adapt(existingSubscription);

        _context.Update(existingSubscription);

        var result = await _context.SaveChangesAsync(cancellationToken) > 0;

        return new UpdateUserSubscriptionResult(result);
    }
}