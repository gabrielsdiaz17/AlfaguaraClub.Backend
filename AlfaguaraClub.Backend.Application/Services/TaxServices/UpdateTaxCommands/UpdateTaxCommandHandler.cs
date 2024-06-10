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

namespace AlfaguaraClub.Backend.Application.Services.TaxServices.UpdateTaxCommands
{
    public class UpdateTaxCommandHandler : IRequestHandler<UpdateTaxCommand>
    {
        private ITaxRepository _taxRepository;
        private IMapper _mapper;
        public UpdateTaxCommandHandler(ITaxRepository taxRepository, IMapper mapper)
        {
            _taxRepository = taxRepository;
            _mapper = mapper;
        }

        public async Task Handle(UpdateTaxCommand request, CancellationToken cancellationToken)
        {
            var taxToUpdate = await _taxRepository.GetByIdAsync(request.TaxId);
            if (taxToUpdate == null)
                throw new NotFoundException(nameof(Tax), taxToUpdate.TaxId);
            var validator = new UpdateTaxtCommandValidator();
            var validationResult = await validator.ValidateAsync(request);
            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);
            _mapper.Map(request, taxToUpdate, typeof(UpdateTaxCommand), typeof(Tax));
            await _taxRepository.UpdateAsync(taxToUpdate);
        }
    }
}
