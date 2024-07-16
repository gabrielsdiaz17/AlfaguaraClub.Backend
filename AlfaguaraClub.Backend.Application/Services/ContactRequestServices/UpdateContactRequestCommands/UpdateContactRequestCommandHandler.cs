using AlfaguaraClub.Backend.Application.Contracts.Persistence;
using AlfaguaraClub.Backend.Application.Exceptions;
using AlfaguaraClub.Backend.Domain.Entities;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.ContactRequestServices.UpdateContactRequestCommands
{
    public class UpdateContactRequestCommandHandler : IRequestHandler<UpdateContactRequestCommand>
    {
        private readonly IContactRequestRepository _contactRequestRepository;
        private readonly IMapper _mapper;
        public UpdateContactRequestCommandHandler(IContactRequestRepository contactRequestRepository, IMapper mapper)
        {
            _contactRequestRepository = contactRequestRepository;
            _mapper = mapper;
        }

        public async Task Handle(UpdateContactRequestCommand request, CancellationToken cancellationToken)
        {
            var requestToUpdate = await _contactRequestRepository.GetByIdAsync(request.ContactRequestId);
            if (requestToUpdate == null)
                throw new NotFoundException(nameof(ContactRequest), request.ContactRequestId);
            var validator = new UpdateContactRequestCommandValidator();
            var validationResult = await validator.ValidateAsync(request);
            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);
            _mapper.Map(request, requestToUpdate, typeof(UpdateContactRequestCommand), typeof(ContactRequest));
            await _contactRequestRepository.UpdateAsync(requestToUpdate);           
        }
    }
}
