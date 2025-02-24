﻿using BuildingBlocks.CQRS;
using Mapster;
using MassTransit;
using MediatR;
using Profile.API.Data;
using Profile.API.DoctorProfiles.Events;
using Profile.API.PatientProfiles.Dtos;
using Profile.API.PatientProfiles.Events;
using Profile.API.PatientProfiles.Models;

namespace Profile.API.PatientProfiles.Features.CreatePatientProfile
{
    public record CreatePatientProfileCommand(CreatePatientProfileDto PatientProfileCreate) : ICommand<CreatePatientProfileResult>;

    public record CreatePatientProfileResult(Guid Id);

    public class CreatePatientProfileHandler : ICommandHandler<CreatePatientProfileCommand, CreatePatientProfileResult>
    {
        private readonly ProfileDbContext _context;
        private readonly IMediator _mediator;
        private readonly IPublishEndpoint _publishEndpoint;

        public CreatePatientProfileHandler(ProfileDbContext context, IMediator mediator,IPublishEndpoint publishEndpoint)
        {
            _context = context;
            _mediator = mediator;
            _publishEndpoint = publishEndpoint;
        }

        public async Task<CreatePatientProfileResult> Handle(CreatePatientProfileCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var dto = request.PatientProfileCreate;

                var patientProfile = PatientProfile.Create(
                    dto.UserId,
                    dto.FullName,
                    dto.Gender,
                    dto.Allergies,
                    dto.PersonalityTraits,
                    dto.ContactInfo
                );
                patientProfile.CreatedAt = DateTimeOffset.UtcNow;

                _context.PatientProfiles.Add(patientProfile);
                await _context.SaveChangesAsync(cancellationToken);

                var patientProfileCreatedEvent = new PatientProfileCreatedEvent(
                    patientProfile.UserId,
                    patientProfile.FullName,
                    patientProfile.Gender.ToString(),
                    patientProfile.ContactInfo.Email,
                    patientProfile.ContactInfo.PhoneNumber,
                    patientProfile.CreatedAt
                );

                await _mediator.Publish(patientProfileCreatedEvent, cancellationToken);
                await _publishEndpoint.Publish(patientProfileCreatedEvent, cancellationToken);

                return new CreatePatientProfileResult(patientProfile.Id);
            }
            catch (DbUpdateException ex)
            {
                throw new Exception($"Database error: {ex.InnerException?.Message}", ex);
            }
        }

    }
}
