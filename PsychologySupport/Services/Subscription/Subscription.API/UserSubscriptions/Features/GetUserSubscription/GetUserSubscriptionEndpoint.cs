﻿using Carter;
using Mapster;
using MediatR;
using Subscription.API.UserSubscriptions.Dtos;

namespace Subscription.API.UserSubscriptions.Features.GetUserSubscription;

public record GetUserSubscriptionResponse(GetUserSubscriptionDto UserSubscription);

public class GetUserSubscriptionEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/user-subscriptions/{id}", async (Guid id, ISender sender) =>
            {
                var query = new GetUserSubscriptionQuery(id);

                var result = await sender.Send(query);

                var response = result.Adapt<GetUserSubscriptionResponse>();

                return Results.Ok(response);
            })
            .WithName("GetUserSubscription")
            .Produces<GetUserSubscriptionResponse>()
            .ProducesProblem(StatusCodes.Status404NotFound)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithDescription("Get User Subscription")
            .WithSummary("Get User Subscription");
    }
}