﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlfaguaraClub.Backend.Domain.Enums;

namespace AlfaguaraClub.Backend.Domain.Entities
{
    public class SpaceActivity: AuditableEntity
    {
        [Key]
        public long SpaceActivityId { get; set; }
        [MaxLength(200)]
        public string ActivityName { get; set; }
        [Column(TypeName = "text")]
        public string ActivityDescription { get; set; }
        public int AvailableQuorum { get; set; }
        [ForeignKey("TypeActivity")]
        public int? TypeActivityId { get; set; }
        public TypeActivity TypeActivity { get; set; }
        public ActivityVisibility Visibility { get; set; }

        [ForeignKey("Space")]
        public long SpaceId { get; set; }
        public Space Space { get; set; }
        public DateTimeOffset ActivityDate { get; set; }
        public TimeSpan StartActivityHour { get; set; }
        public TimeSpan EndActivityHour { get; set; }
        public bool IsActive { get; set; }
        public ICollection<Booking> Bookings { get; set; }

    }
}
