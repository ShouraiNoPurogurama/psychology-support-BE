﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.Messaging.Events.LifeStyle
{
    //public record ActivityRequest(Guid Id, string ActivityType);
    public record ActivityRequest(List<Guid> Ids, string ActivityType);

}
