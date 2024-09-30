using AlfaguaraClub.Backend.Application.Contracts.Persistence;
using AlfaguaraClub.Backend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Persistence.Repository
{
    public class UserInfoRepository : BaseRepository<UserInfo>, IUserInfoRepository
    {
        public UserInfoRepository(IRepository<UserInfo> repository) : base(repository)
        {
        }

        public async Task<UserInfo> GetRecentUserInfo(string identificationNumber)
        {
            var userInfo = await QueryNoTracking().Where(ui=>ui.IdentificationNumber == identificationNumber && ui.IsActive)
                                                  .OrderByDescending(ui=>ui.RecordDateTime).FirstOrDefaultAsync();
            return userInfo;
        }
    }
}
