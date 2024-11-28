using AlfaguaraClub.Backend.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.SpaceActivityServices.DeleteSpaceActivityCommands
{
    public class DeleteSpaceActivityCommandHandler : IRequestHandler<DeleteSpaceActivityCommand>
    {
        private readonly ISpaceActivityRepository _spaceActivityRepository;
        public DeleteSpaceActivityCommandHandler(ISpaceActivityRepository spaceActivityRepository) {
            _spaceActivityRepository = spaceActivityRepository;
        }
        public async Task Handle(DeleteSpaceActivityCommand request, CancellationToken cancellationToken)
        {
            var activities = await _spaceActivityRepository.GetSpaceActivitiesByDate(request.ActivityDate);
            if (activities.Any())
            {
                foreach (var activity in activities) 
                {
                    activity.IsActive = false;
                    await _spaceActivityRepository.UpdateAsync(activity);
                }
            }
        }
    }
}
