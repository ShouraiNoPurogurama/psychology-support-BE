﻿using BuildingBlocks.Data.Common;
using Profile.API.DoctorProfiles.Dtos;
using Profile.API.DoctorProfiles.Models;

namespace Profile.API.DoctorProfiles.Features.CreateDoctorProfile;

public record CreateDoctorProfileCommand(CreateDoctorProfileDto DoctorProfile) : ICommand<CreateDoctorProfileResult>;

public record CreateDoctorProfileResult(Guid Id);

public class CreateDoctorProfileHandler(ProfileDbContext context,
    IRequestClient<DoctorProfileCreatedResponseEvent> requestClient)
    : ICommandHandler<CreateDoctorProfileCommand, CreateDoctorProfileResult>
{
    public async Task<CreateDoctorProfileResult> Handle(CreateDoctorProfileCommand request, CancellationToken cancellationToken)
    {
        var dto = request.DoctorProfile;

        var doctorProfileCreatedEvent = new DoctorProfileCreatedRequestEvent(
            dto.FullName,
            dto.Gender,
            dto.ContactInfo.Email,
            dto.ContactInfo.PhoneNumber,
            "None"
        );

        // Send event and wait for response
        var response = await requestClient.GetResponse<DoctorProfileCreatedResponseEvent>(doctorProfileCreatedEvent);

        if (!response.Message.Success)
        {
            throw new InvalidOperationException("User creation failed. Cannot create DoctorProfile.");
        }

        var doctorProfile = DoctorProfile.Create(
            response.Message.UserId, 
            dto.FullName,
            dto.Gender,
            new ContactInfo(
                dto.ContactInfo.Address,
                dto.ContactInfo.PhoneNumber,
                dto.ContactInfo.Email
            ),
            dto.Qualifications,
            dto.YearsOfExperience,
            dto.Bio
        );

        context.DoctorProfiles.Add(doctorProfile);
        await context.SaveChangesAsync(cancellationToken);

        return new CreateDoctorProfileResult(response.Message.UserId);
    }
}
