﻿using Carter;
using Mapster;
using Profile.API.PatientProfiles.Dtos;

namespace Profile.API.PatientProfiles.Features.GetMedicalRecord
{
    public record GetMedicalRecordRequest(Guid MedicalRecordId);

    public record GetMedicalRecordResponse(MedicalRecordDto Record);

    public class GetMedicalRecordEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/medical-records/{medicalRecordId:guid}", async (Guid medicalRecordId, ISender sender) =>
            {
                var query = new GetMedicalRecordQuery(medicalRecordId);
                var result = await sender.Send(query);
                var response = result.Adapt<GetMedicalRecordResponse>();
                return Results.Ok(response);
            })
                .WithName("GetMedicalRecordById")
                .Produces<GetMedicalRecordResponse>()
                .ProducesProblem(StatusCodes.Status404NotFound)
                .WithDescription("Get MedicalRecord")
                .WithSummary("Get MedicalRecord");
        }
    }
}
