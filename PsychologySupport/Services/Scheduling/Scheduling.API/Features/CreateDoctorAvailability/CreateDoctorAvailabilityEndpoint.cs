﻿using Carter;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Scheduling.API.Dtos;

namespace Scheduling.API.Features.CreateDoctorAvailability
{
    public record CreateDoctorAvailabilityRequest(CreateDoctorAvailabilityDto DoctorAvailabilityCreate);

    public record CreateDoctorAvailabilityResponse(Guid Id);
    public class CreateDoctorAvailabilityEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("doctor-availabilities", async ([FromBody] CreateDoctorAvailabilityRequest request, ISender sender) =>
            {
                var command = request.Adapt<CreateDoctorAvailabilityCommand>();

                var result = await sender.Send(command);

                var response = result.Adapt<CreateDoctorAvailabilityResponse>();

                return Results.Created($"/doctor-availabilities/{response.Id}", response);
            })
                .WithName("CreateDoctorAvailability")
                .Produces<CreateDoctorAvailabilityResponse>()
                .ProducesProblem(StatusCodes.Status400BadRequest)
                .WithDescription("Create Doctor Availability")
                .WithSummary("Create Doctor Availability");
        }
    }
}
