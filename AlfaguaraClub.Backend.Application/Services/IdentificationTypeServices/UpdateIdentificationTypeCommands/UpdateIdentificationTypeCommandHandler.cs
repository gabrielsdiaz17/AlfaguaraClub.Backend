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

namespace AlfaguaraClub.Backend.Application.Services.IdentificationTypeServices.UpdateIdentificationTypeCommands
{
    public class UpdateIdentificationTypeCommandHandler : IRequestHandler<UpdateIdentificationTypeCommand>
    {
        private readonly IIdentificationTypeRepository _IIdentificationTypeRepository;
        private readonly IMapper _mapper;
        public UpdateIdentificationTypeCommandHandler(IIdentificationTypeRepository iIdentificationTypeRepository, IMapper mapper)
        {
            _IIdentificationTypeRepository = iIdentificationTypeRepository;
            _mapper = mapper;
        }

        public async Task Handle(UpdateIdentificationTypeCommand request, CancellationToken cancellationToken)
        {
            var identificationTypeToUdate = await _IIdentificationTypeRepository.GetByIdAsync(request.IdendificationTypeId);
            if (identificationTypeToUdate == null)
                throw new NotFoundException(nameof(IdentificationType), request.IdendificationTypeId);
            var validator = new UpdateIdentificationTypeCommandValidator();
            var validationResult = await validator.ValidateAsync(request);
            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);
            _mapper.Map(request, identificationTypeToUdate, typeof (UpdateIdentificationTypeCommand), typeof(IdentificationType));
            await _IIdentificationTypeRepository.UpdateAsync(identificationTypeToUdate);
        }
    }
}
