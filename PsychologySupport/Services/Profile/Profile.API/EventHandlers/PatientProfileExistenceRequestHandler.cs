﻿using BuildingBlocks.Messaging.Events.Profile;

namespace Profile.API.EventHandlers;

public class PatientProfileExistenceRequestHandler : IConsumer<PatientProfileExistenceRequest>
{
    private readonly ProfileDbContext _context;

    public PatientProfileExistenceRequestHandler(ProfileDbContext context)
    {
        _context = context;
    }

    public async Task Consume(ConsumeContext<PatientProfileExistenceRequest> context)
    {
        var message = context.Message;

        var patientProfile = await _context.PatientProfiles
            .FindAsync(message.PatientProfileId);

        await context.RespondAsync(new PatientProfileExistenceResponse(patientProfile is not null));
    }
}