using AlfaguaraClub.Backend.Application.Contracts.Persistence;
using AlfaguaraClub.Backend.Domain.Entities;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.SpaceActivitySlotServices.CreateSlotsCommands
{
    public class CreateSpaceActivitySlotCommandHandler : IRequestHandler<CreateSpaceActivitySlotCommand, CreateSpaceActivitySlotCommandResponse>
    {
        private ISpaceActivitySlotRepository _spaceActivitySlotRepository;
        
        public CreateSpaceActivitySlotCommandHandler(ISpaceActivitySlotRepository spaceActivitySlotRepository)
        {
            
            _spaceActivitySlotRepository = spaceActivitySlotRepository;
        }
        public async Task<CreateSpaceActivitySlotCommandResponse> Handle(CreateSpaceActivitySlotCommand request, CancellationToken cancellationToken)
        {
            var response  = new CreateSpaceActivitySlotCommandResponse();
            try
            {
                var slots = new List<SpaceActivitySlot>();

                foreach (var spaceSlot in request.CreateSpaceActivitySlotList)
                {
                    slots.Add(new SpaceActivitySlot
                    {
                        SpaceActivityId = spaceSlot.SpaceActivityId,
                        RailNumber = spaceSlot.RailNumber,
                        MaxQuorum = spaceSlot.MaxQuorum,
                        CurrentQuorum = 0,
                        IsActive = true,
                    });
                }
                
                await _spaceActivitySlotRepository.AddRangeAsync(slots);
                response.Success = true;
                response.SavedRecords = true;
            }
            catch (Exception ex) 
            {
                response.Success = false;
                response.SavedRecords = false;
                response.Message = ex.Message.ToString();
            }
            return response;

        }
    }
}
