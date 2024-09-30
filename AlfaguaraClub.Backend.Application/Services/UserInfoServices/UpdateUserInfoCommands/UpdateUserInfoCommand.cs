using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.UserInfoServices.UpdateUserInfoCommands
{
    public class UpdateUserInfoCommand:IRequest
    {
        public long UserInfoId { get; set; }
        public string UserData { get; set; }
        public string IdentificationNumber { get; set; }
        public DateTime RecordDateTime { get; set; }
        public bool IsActive { get; set; }
    }
}
