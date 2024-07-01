using AlfaguaraClub.Backend.Application.Contracts.Persistence;
using AlfaguaraClub.Backend.Domain.Entities;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.SpaceActivityServices.CreateSpaceActivityCommands
{
    public class CreateMassiveSpaceActivityCommandHandler : IRequestHandler<CreateMassiveSpaceActivityCommand, CreateMassiveSpaceActivityCommandResponse>
    {
        private readonly ISpaceActivityRepository _spaceActivityRepository;
        public CreateMassiveSpaceActivityCommandHandler(ISpaceActivityRepository spaceActivityRepository)
        {
            _spaceActivityRepository = spaceActivityRepository;
        }

        public async Task<CreateMassiveSpaceActivityCommandResponse> Handle(CreateMassiveSpaceActivityCommand request, CancellationToken cancellationToken)
        {
            var listActivities = new List<SpaceActivity>();
            var response = new CreateMassiveSpaceActivityCommandResponse();
            var validator = new CreateMassiveSpaceActivityCommandValidator();
            var validationResult = await validator.ValidateAsync(request);
            if (validationResult.Errors.Count > 0)
            {
                response.Success = false;
                response.ValidationErrors = new List<string>();
                foreach (var error in validationResult.Errors)
                {
                    response.ValidationErrors.Add(error.ErrorMessage.ToString());
                }
            }
            if (response.Success)
            {
                DateTimeOffset dateToSave = request.FromDate;
                while(dateToSave <=request.ToDate)
                {
                    var newActivity = new SpaceActivity()
                    {
                        ActivityName = request.ActivityName,
                        ActivityDescription = request.ActivityDescription,
                        AvailableQuorum = request.AvailableQuorum,
                        TypeActivityId = request.TypeActivityId,
                        Visibility = request.Visibility,
                        SpaceId = request.SpaceId,
                        ActivityDate = dateToSave,
                        StartActivityHour = request.StartActivityHour,
                        EndActivityHour = request.EndActivityHour,
                        IsActive = request.IsActive,
                    };
                    listActivities.Add(newActivity);
                    dateToSave= dateToSave.AddDays(1);
                }
                listActivities = (List<SpaceActivity>)await _spaceActivityRepository.AddRangeAsync(listActivities);
                response.SavedRecords = true;

            }
            return response;
        }
    }
}
