using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.UserInfoServices.CreateUserInfoCommands
{
    public class CreateUserInfoCommand:IRequest<CreateUserInfoCommandResponse>
    {
        public string UserData { get; set; }
        public string IdentificationNumber { get; set; }
        public DateTime RecordDateTime { get; set; }
        public bool IsActive { get; set; }
    }
}
