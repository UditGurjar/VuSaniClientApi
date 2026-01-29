using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VuSaniClientApi.Models.DBModels;

namespace VuSaniClientApi.Infrastructure.DBContext.Seed
{
    public static class ReasonForInactiveSeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ReasonForInactive>().HasData(
                new ReasonForInactive
                {
                    Id = 1,
                    Name = "Retrenched",
                    Description = "Refers to an employee whose employment has been terminated by the employer due to operational or economic reasons, rather than personal misconduct or poor performance.",
                    Deleted = false
                },
                new ReasonForInactive
                {
                    Id = 2,
                    Name = "Retired",
                    Description = "Refers to a person who has permanently withdrawn from active employment or professional work, usually after reaching a certain age or completing the required years of service.",
                    Deleted = false
                },
                new ReasonForInactive
                {
                    Id = 3,
                    Name = "End Of Contract",
                    Description = "Refers to the conclusion of an employment, service, or business agreement once the agreed-upon period, conditions, or obligations have been fulfilled.",
                    Deleted = false
                },
                new ReasonForInactive
                {
                    Id = 4,
                    Name = "Deceased",
                    Description = "Refers to a person who has died.",
                    Deleted = false
                },
                new ReasonForInactive
                {
                    Id = 5,
                    Name = "Dismissal",
                    Description = "A termination of an employee’s contract of employment by the employer, usually due to misconduct, poor performance, redundancy, or violation of company policies.",
                    Deleted = false
                },
                new ReasonForInactive
                {
                    Id = 6,
                    Name = "Resignation",
                    Description = "A formal act of voluntarily leaving a job, position, or office by an employee or officeholder.",
                    Deleted = false
                }
            );
        }


    }
}
