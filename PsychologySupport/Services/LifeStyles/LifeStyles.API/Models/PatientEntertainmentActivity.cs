﻿using BuildingBlocks.Enums;

namespace LifeStyles.API.Models;

public class PatientEntertainmentActivity
{
    public Guid PatientProfileId { get; set; }
    public Guid EntertainmentActivityId { get; set; }
    public PreferenceLevel PreferenceLevel { get; set; }
}