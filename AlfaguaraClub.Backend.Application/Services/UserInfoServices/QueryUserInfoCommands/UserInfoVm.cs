using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.UserInfoServices.QueryUserInfoCommands
{
    public class UserInfoVm
    {
        public long UserInfoId { get; set; }
        public string UserData { get; set; }
        public string IdentificationNumber { get; set; }
        public DateTime RecordDateTime { get; set; }
        public bool IsActive { get; set; }
    }
}
