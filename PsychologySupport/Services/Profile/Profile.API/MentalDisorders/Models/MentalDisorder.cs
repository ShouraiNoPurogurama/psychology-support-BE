﻿using BuildingBlocks.DDD;

namespace Profile.API.MentalDisorders.Models;

public class MentalDisorder : AggregateRoot<Guid>
{
    public string Name { get; set; }

    public string Description { get; set; }

    public ICollection<SpecificMentalDisorder> SpecificMentalDisorders { get; set; } = [];
}