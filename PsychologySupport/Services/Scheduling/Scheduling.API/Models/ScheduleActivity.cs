﻿using Scheduling.API.Data.Common;

namespace Scheduling.API.Models
{
    public class ScheduleActivity
    {
        public Guid Id { get; set; }
        public Guid SessionId { get; set; }
        public Guid? EntertainmentActivityId { get; set; }
        public Guid? FoodActivityId { get; set; }
        public Guid? PhysicalActivityId { get; set; }
        public Guid? TherapeuticActivityId { get; set; }
        public ScheduleActivityStatus Status { get; set; }
        public string Description { get; set; }
        public DateTime TimeRange { get; set; } // ngày giờ bắt đầu
        public string Duration { get; set; } // khoảng thời gian thực hiện
        public int DateNumber { get; set; } // ngày thứ mấy trong session
    }
}
