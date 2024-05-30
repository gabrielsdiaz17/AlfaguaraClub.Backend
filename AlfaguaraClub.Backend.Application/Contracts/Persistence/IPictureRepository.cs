using AlfaguaraClub.Backend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Contracts.Persistence
{
    public interface IPictureRepository: IRepository<Picture>
    {
        Task<List<Picture>> GetActivePictures();
        Task<Picture> GetPictureById(long pictureId);
        Task<List<Picture>> GetPicturesByStory(long storyId);
        Task<List<Picture>> GetPicturesBySpace(long spaceId);
    }
}
