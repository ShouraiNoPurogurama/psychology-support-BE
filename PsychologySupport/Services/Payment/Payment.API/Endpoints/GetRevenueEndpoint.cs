﻿using Carter;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Payment.Application.Payments.Queries;

namespace Payment.API.Endpoints
{
    public class GetRevenueEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/payments/revenue", async (
                [FromQuery] DateOnly startTime,
                [FromQuery] DateOnly endTime,
                ISender sender,
                CancellationToken cancellationToken) =>
            {
                var query = new GetRevenueQuery(startTime, endTime);
                var result = await sender.Send(query, cancellationToken);
                return Results.Ok(result);
            })
            .WithName("GetRevenue")
            .Produces<GetRevenueResult>()
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Get Revenue")
            .WithDescription("Get Revenue");
        }
    }
}
