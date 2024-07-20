using AlfaguaraClub.Backend.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Domain.Entities
{
    public class ContactRequest: AuditableEntity
    {
        public long ContactRequestId { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(20)]
        public string PhoneNumber { get; set; }
        [MaxLength(100)]
        public string Email { get; set; }
        [Column(TypeName = "text")]
        public string Message { get; set; }
        public string? ObservationResponse { get; set; }
        public StatusRequest StatusRequest { get; set; }
        [ForeignKey("SpaceId")]
        public long? SpaceId { get; set; }
        public Space Space { get; set; }
        public DateTime DateRequest { get; set; }
        public bool IsActive { get; set; }
    }
}
