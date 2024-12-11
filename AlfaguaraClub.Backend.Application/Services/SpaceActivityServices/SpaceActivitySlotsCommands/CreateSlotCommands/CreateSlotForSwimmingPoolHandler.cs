using AlfaguaraClub.Backend.Application.Contracts.Persistence;
using AlfaguaraClub.Backend.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.SpaceActivityServices.SpaceActivitySlotsCommands.CreateSlotCommands
{
    public class CreateSlotForSwimmingPoolHandler : IRequestHandler<CreateSlotForSwimmingPool, CreateSlotForSwimmingPoolResponse>
    {
        private readonly ISpaceActivitySlotRepository _spaceActivitySlotRepository;
        public CreateSlotForSwimmingPoolHandler(ISpaceActivitySlotRepository spaceActivitySlotRepository)
        {
            _spaceActivitySlotRepository = spaceActivitySlotRepository;
        }

        public async Task<CreateSlotForSwimmingPoolResponse> Handle(CreateSlotForSwimmingPool request, CancellationToken cancellationToken)
        {
            var response = new CreateSlotForSwimmingPoolResponse();
            var slots = new List<SpaceActivitySlot>();
            try
            {
                for (int rail = 1; rail <= request.RailCount; rail++)
                {
                    slots.Add(new SpaceActivitySlot
                    {
                        SpaceActivityId = request.SpaceActivityId,
                        RailNumber = rail,
                        MaxQuorum = request.MaxQuorum,
                        CurrentQuorum = request.CurrentQuorum,
                        IsActive = true
                    });
                }
                _spaceActivitySlotRepository.AddRangeAsync(slots);
                response.SavedRecords = true;
            }
            catch (Exception ex) 
            {
                response.SavedRecords = false;
                response.Message = ex.Message;
            }
            return response;
        }
    }
}
