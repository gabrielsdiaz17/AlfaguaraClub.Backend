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

namespace AlfaguaraClub.Backend.Application.Services.SiteServices.UpdateCompanyCommands
{
    public class UpdateSiteCommandHandler : IRequestHandler<UpdateSiteCommand>
    {
        private readonly ISiteRepository _siteRepository;
        private readonly IMapper _mapper;
        public UpdateSiteCommandHandler(ISiteRepository siteRepository, IMapper mapper)
        {
            _siteRepository = siteRepository;
            _mapper = mapper;
        }

        public async Task Handle(UpdateSiteCommand request, CancellationToken cancellationToken)
        {
            var siteToUpdate = await _siteRepository.GetByIdAsync(request.SiteId);
            if (siteToUpdate == null)
                throw new NotFoundException(nameof(Site), request.SiteId);
            var validator = new UpdateSiteCommandValidator();
            var validationResult = await validator.ValidateAsync(request);
            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);

            _mapper.Map(request,siteToUpdate,typeof(UpdateSiteCommand),typeof(Site));
            await _siteRepository.UpdateAsync(siteToUpdate);
        }
    }
}
