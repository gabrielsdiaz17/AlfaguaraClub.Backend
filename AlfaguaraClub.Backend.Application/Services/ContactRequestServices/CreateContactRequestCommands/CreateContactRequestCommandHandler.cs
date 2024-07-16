using AlfaguaraClub.Backend.Application.Contracts.Persistence;
using AlfaguaraClub.Backend.Domain.Entities;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.ContactRequestServices.CreateContactRequestCommands
{
    public class CreateContactRequestCommandHandler : IRequestHandler<CreateContactRequestCommand, CreateContactRequestCommandResponse>
    {
        private readonly IContactRequestRepository _contactRequestRepository;
        private readonly IMapper _mapper;
        public CreateContactRequestCommandHandler(IContactRequestRepository contactRequestRepository, IMapper mapper) 
        {
            _contactRequestRepository = contactRequestRepository;
            _mapper = mapper;
        }
        public async Task<CreateContactRequestCommandResponse> Handle(CreateContactRequestCommand request, CancellationToken cancellationToken)
        {
            var response = new CreateContactRequestCommandResponse();
            var newContacRequest = _mapper.Map<CreateContactRequestCommand,ContactRequest>(request);
            var validator = new CreateContactRequestCommandValidator();
            var validationResult = await validator.ValidateAsync(request);
            if(validationResult.Errors.Count > 0)
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
                newContacRequest = await _contactRequestRepository.AddAsync(newContacRequest);
                response.ContactRequestId = newContacRequest.ContactRequestId;
            }
            return response;
        }
    }
}
