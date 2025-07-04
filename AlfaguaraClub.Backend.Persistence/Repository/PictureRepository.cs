using AlfaguaraClub.Backend.Application.Contracts.Persistence;
using AlfaguaraClub.Backend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Persistence.Repository
{
    public class PictureRepository : BaseRepository<Picture>, IPictureRepository
    {
        public PictureRepository(IRepository<Picture> repository) : base(repository)
        {
        }

        public async Task<List<Picture>> GetActivePictures()
        {
            var activePictures = await QueryNoTracking().Where(picture=> picture.IsActive)
                                                        .OrderByDescending(picture=>picture.PictureId)
                                                        .ToListAsync();
            return activePictures;
        }

        public async Task<Picture> GetPictureById(long pictureId)
        {
            var picture = await QueryNoTracking().Where(pic=> pic.IsActive).FirstOrDefaultAsync();
            return picture;
        }

        public async Task<List<Picture>> GetPicturesBySpace(long spaceId)
        {
            var picturesSpace = await QueryNoTracking().Where(picture=> picture.SpaceId == spaceId && picture.IsActive)
                                                       .OrderByDescending(picture => picture.PictureId)
                                                       .ToListAsync();
            return picturesSpace;
        }

        public async Task<List<Picture>> GetPicturesByStory(long storyId)
        {
            var picturesStory = await QueryNoTracking().Where(picture =>picture.StoryId == storyId && picture.IsActive)
                                                       .OrderByDescending(picture => picture.PictureId)
                                                       .ToListAsync();
            return picturesStory;
        }
    }
}
