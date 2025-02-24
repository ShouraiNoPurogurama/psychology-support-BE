﻿using BuildingBlocks.Messaging.Events;
using BuildingBlocks.Messaging.Events.Notification;
using Mapster;
using Profile.API.DoctorProfiles.Features;
using Profile.API.PatientProfiles.Events;

namespace Profile.API.DoctorProfiles.EventHandlers;

public class MedicalRecordAddedEventHandler(IBus bus, ISender sender, ILogger<MedicalRecordAddedEventHandler> logger)
    : INotificationHandler<MedicalRecordAddedEvent>
{
    public async Task Handle(MedicalRecordAddedEvent notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("DomainEvent Event handled: {DomainEvent}", notification.GetType().Name);
        
        var command = notification.Adapt<AddMedicalRecordCommand>();
        
        var result = await sender.Send(command, cancellationToken);

        // var integrationEvent =
        //     new SendEmailIntegrationEvent("nhatanhtruong687@gmail.com", "Test ne", "Hello world!");

        // await bus.Publish(integrationEvent, cancellationToken);
        
        if (!result.IsSuccess)
        {
            logger.LogError("Error adding medical record to doctor id: {DoctorId}", command.MedicalRecord.DoctorProfileId);
        }

        logger.LogInformation("Successfully added medical record to doctor id {DoctorId}", command.MedicalRecord.DoctorProfileId);
    }
}