using AlfaguaraClub.Backend.Application.Contracts.Persistence;
using AlfaguaraClub.Backend.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.SquashFieldActivityServices.CreateSquashFieldActivityCommands
{
    public class CreateSquashFieldActivityCommandHandler : IRequestHandler<CreateSquashFieldActivityCommand, CreateSquashFieldActivityCommandResponse>
    {
        private readonly ISquashFieldActivitySlotRepository _squashFieldActivitySlotRepository;
        public CreateSquashFieldActivityCommandHandler(ISquashFieldActivitySlotRepository squashFieldActivitySlotRepository)
        {
            _squashFieldActivitySlotRepository = squashFieldActivitySlotRepository;
        }

        public async Task<CreateSquashFieldActivityCommandResponse> Handle(CreateSquashFieldActivityCommand request, CancellationToken cancellationToken)
        {
            var response = new CreateSquashFieldActivityCommandResponse();
            try
            {
                var squashSlots = new List<SquashFieldActivitySlot>();
                foreach(var itemSquash in request.CreateSquashSpaceActivitySlotList)
                {
                    squashSlots.Add(new SquashFieldActivitySlot
                    {
                        SpaceActivityId = itemSquash.SpaceActivityId,
                        FieldNumber = itemSquash.FieldNumber,
                        AvailableSlots = itemSquash.AvailableSlots,
                        IsActive = true
                    });
                }
                await _squashFieldActivitySlotRepository.AddRangeAsync(squashSlots);
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
