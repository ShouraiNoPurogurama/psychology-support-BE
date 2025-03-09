﻿using BuildingBlocks.Pagination;
using Carter;
using Mapster;
using Profile.API.PatientProfiles.Dtos;

namespace Profile.API.PatientProfiles.Features.GetAllMedicalRecord;

public record GetAllMedicalRecordsResponse(PaginatedResult<MedicalRecordDto> MedicalRecords);

public class GetAllMedicalRecordsEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/patients/{patientId}/medical-records", async ([AsParameters] GetAllMedicalRecordsQuery request,ISender sender) 
        =>{
            var result = await sender.Send(request);
            var response = result.Adapt<GetAllMedicalRecordsResponse>();

            return Results.Ok(response);
        })
            .WithName("GetAllMedicalRecords")
            .Produces<GetAllMedicalRecordsResponse>()
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .WithDescription("Get All MedicalRecords")
            .WithSummary("Get All MedicalRecords");
    }
}
