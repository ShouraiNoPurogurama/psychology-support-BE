﻿namespace Scheduling.API.Dtos
{
    public record CreateDoctorAvailabilityDto(Guid DoctorId, DateOnly Date, TimeOnly StartTime);
}
