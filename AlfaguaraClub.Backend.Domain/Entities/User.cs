using AlfaguaraClub.Backend.Domain.Entities;
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
    public class User: AuditableEntity
    {
        [Key]
        public long UserId { get; set; }

        [ForeignKey("IdentificationType")]
        public int IdentificationTypeId { get; set; }
        public IdentificationType IdentificationType { get; set; }
        [MaxLength(200)]
        public string Name { get; set; }
        [MaxLength(200)]
        public string LastName { get; set; }
        [MaxLength(200)]
        public string Email { get; set; }
        [Column(TypeName = "text")]
        public string Password { get; set; }
        [Column(TypeName = "text")]
        public string Address { get; set; }
        [MaxLength(200)]
        public string CityAddress { get; set; }
        [MaxLength(30)]
        public string PhoneNumber { get; set; }
        public Genre Genre { get; set; }
        [ForeignKey("Role")]
        public int RoleId { get; set; }
        public Role Role { get; set; }
        [ForeignKey("Membership")]
        public long? MembershipId { get; set; }
        public Membership? Membership { get; set; }
        public TypeUser? TypeUser { get; set; }
        public bool AcceptProtectionData { get; set; }
        [Column(TypeName = "text")]
        public string Photograph { get; set; }
        public ICollection<Booking> Bookings { get; set; }
        public ICollection<Billing> Billings { get; set; }
        public ICollection<Notification> Notifications { get; set; }
    }
}
