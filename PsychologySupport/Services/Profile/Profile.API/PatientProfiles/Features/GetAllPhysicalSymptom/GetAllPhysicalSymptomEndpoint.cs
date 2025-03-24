﻿using BuildingBlocks.Pagination;
using Carter;
using Mapster;
using Profile.API.PatientProfiles.Dtos;

namespace Profile.API.PatientProfiles.Features.GetAllPhysicalSymptom
{
    public record GetAllPhysicalSymptomResponse(PaginatedResult<PhysicalSymptomDto> PhysicalSymptom);

    public class GetAllPhysicalSymptomEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/physical-symptoms", async (
                [AsParameters] GetAllPhysicalSymptomQuery request, ISender sender) =>
            {
                var result = await sender.Send(request);
                var response = result.Adapt<GetAllPhysicalSymptomResponse>();

                return Results.Ok(response);
            })
                .WithName("GetAllPhysicalSymptoms")
                .Produces<GetAllPhysicalSymptomResponse>()
                .ProducesProblem(StatusCodes.Status400BadRequest)
                .ProducesProblem(StatusCodes.Status404NotFound)
                .WithDescription("GetAllPhysicalSymptoms")
                .WithSummary("GetAllPhysicalSymptoms");
        }
    }
}
