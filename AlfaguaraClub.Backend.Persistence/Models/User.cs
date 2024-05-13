using AlfaguaraClub.Backend.Persistence.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Persistence.Models
{
    public class User: AuditableEntity
    {
        [Key]

        public long UserId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public Genre Genre { get; set; }
        [ForeignKey("Role")]
        public long RoleId { get; set; }
        public Role Role { get; set; }
        [ForeignKey("Membership")]
        public long? MembershipId { get; set; }
        public Membership? Membership { get; set; }
        public TypeUser? TypeUser { get; set; }
        public bool AcceptProtectionData { get; set; }
        public string Photograph { get; set; }
    }
}
