﻿using BuildingBlocks.Pagination;
using Carter;
using Mapster;
using MediatR;
using LifeStyles.API.Dtos;

namespace LifeStyles.API.Features.EntertainmentActivities.GetAllEntertainmentActivity;

public record GetAllEntertainmentActivitiesResponse(IEnumerable<EntertainmentActivityDto> EntertainmentActivities);

public class GetAllEntertainmentActivityEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/entertainment-activities", async ([AsParameters] PaginationRequest request, ISender sender) =>
        {
            var query = new GetAllEntertainmentActivitiesQuery(request);
            var result = await sender.Send(query);
            var response = result.Adapt<GetAllEntertainmentActivitiesResponse>();

            return Results.Ok(response);
        })
            .WithName("GetAllEntertainmentActivities")
            .Produces<GetAllEntertainmentActivitiesResponse>()
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithDescription("GetAll Entertainment Activities")
            .WithSummary("GetAll Entertainment Activities");
    }
}
