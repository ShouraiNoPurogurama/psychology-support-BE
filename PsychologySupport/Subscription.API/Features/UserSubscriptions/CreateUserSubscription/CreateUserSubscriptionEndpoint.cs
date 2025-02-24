﻿using Carter;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Subscription.API.Models;

namespace Subscription.API.Features.UserSubscriptions.CreateUserSubscription;

public record CreateUserSubscriptionRequest(UserSubscription UserSubscription);

public record CreateUserSubscriptionResponse(Guid Id);

public class CreateUserSubscriptionEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("user-subscriptions", async ([FromBody] CreateUserSubscriptionRequest request, ISender sender) =>
        {
            var command = request.Adapt<CreateUserSubscriptionCommand>();

            var result = await sender.Send(command);

            var response = result.Adapt<CreateUserSubscriptionResponse>();

            return Results.Created($"/user-subscriptions/{response.Id}", response);
        }
        )
        .WithName("CreateUserSubscription")
        .Produces<CreateUserSubscriptionResponse>()
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithDescription("Create User Subscription")
        .WithSummary("Create User Subscription");
    }
}
