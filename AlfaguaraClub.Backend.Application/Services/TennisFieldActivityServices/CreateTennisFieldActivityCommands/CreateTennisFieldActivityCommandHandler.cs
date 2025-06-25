using AlfaguaraClub.Backend.Application.Contracts.Persistence;
using AlfaguaraClub.Backend.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.TennisFieldActivityServices.CreateTennisFieldActivityCommands
{
    public class CreateTennisFieldActivityCommandHandler : IRequestHandler<CreateTennisFieldActivityCommand, CreateTennisFieldActivityCommandResponse>
    {
        private readonly ITennisFieldActivitySlotRepository _tennisFieldActivitySlotRepository;
        public CreateTennisFieldActivityCommandHandler(ITennisFieldActivitySlotRepository tennisFieldActivitySlotRepository)
        {
            _tennisFieldActivitySlotRepository = tennisFieldActivitySlotRepository;
        }
        public async Task<CreateTennisFieldActivityCommandResponse> Handle(CreateTennisFieldActivityCommand request, CancellationToken cancellationToken)
        {
            var response = new CreateTennisFieldActivityCommandResponse();
            try
            {
                var tennisSlots = new List<TennisFieldActivitySlot>();
                foreach (var itemTennis in request.CreateTennisSpaceActivitySlotList)
                {
                    tennisSlots.Add(new TennisFieldActivitySlot
                    {
                        SpaceActivityId = itemTennis.SpaceActivityId,
                        FieldNumber = itemTennis.FieldNumber,
                        AvailableSlots = itemTennis.AvailableSlots,
                        IsActive = true,
                    });
                }
                await _tennisFieldActivitySlotRepository.AddRangeAsync(tennisSlots);
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
