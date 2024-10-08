﻿using AlfaguaraClub.Backend.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.UserServices.UpdateUserCommands
{
    public class UpdateUserPasswordCommand:IRequest
    {
        public long UserId { get; set; }
        public int IdentificationTypeId { get; set; }
        public string IdentificationNumber { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string CityAddress { get; set; }
        public string PhoneNumber { get; set; }
        public Genre Genre { get; set; }
        public int RoleId { get; set; }
        public long? MembershipId { get; set; }
        public TypeUser? TypeUser { get; set; }
        public bool AcceptProtectionData { get; set; }
        public string? Photograph { get; set; }
        public bool IsActive { get; set; }
    }
}
