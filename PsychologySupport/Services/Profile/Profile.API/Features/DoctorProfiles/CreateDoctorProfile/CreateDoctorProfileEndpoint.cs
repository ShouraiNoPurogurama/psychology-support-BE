﻿using Carter;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Profile.API.Models;

namespace Profile.API.Features.DoctorProfiles.CreateDoctorProfile;

public record CreateDoctorProfileRequest(DoctorProfile DoctorProfile);

public record CreateDoctorProfileResponse(Guid Id);

public class CreateDoctorProfileEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("doctor-profiles", async ([FromBody] CreateDoctorProfileRequest request, ISender sender) =>
            {
                var command = request.Adapt<CreateDoctorProfileCommand>();

                var result = await sender.Send(command);

                var response = result.Adapt<CreateDoctorProfileResponse>();

                return Results.Created($"/doctor-profiles/{response.Id}", response);
            }
        )
        .WithName("CreateDoctorProfile")
        .Produces<CreateDoctorProfileResponse>()
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithDescription("Create Doctor Profile")
        .WithSummary("Create Doctor Profile");
    }
}