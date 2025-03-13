﻿using BuildingBlocks.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.Messaging.Events.LifeStyle
{
    public record ActivityRequestResponse<T>(T Activity) where T : IActivityDto;

}
