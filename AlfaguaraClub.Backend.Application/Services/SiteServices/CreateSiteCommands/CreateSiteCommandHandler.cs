using AlfaguaraClub.Backend.Application.Contracts.Persistence;
using AlfaguaraClub.Backend.Application.Services.CompanyServices.CreateCompanyCommands;
using AlfaguaraClub.Backend.Domain.Entities;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.SiteServices.CreateSiteCommands
{
    public class CreateSiteCommandHandler : IRequestHandler<CreateSiteCommand, CreateSiteCommandResponse>
    {
        private readonly ISiteRepository _siteRepository;
        private readonly IMapper _mapper;
        public  CreateSiteCommandHandler(ISiteRepository siteRepository, IMapper mapper)
        {
            _siteRepository = siteRepository;
            _mapper = mapper;
        }
        public async Task<CreateSiteCommandResponse> Handle(CreateSiteCommand request, CancellationToken cancellationToken)
        {
            var createSiteCommandResponse = new CreateSiteCommandResponse();
            var site = _mapper.Map<Site>(request);
            var validator = new CreateSiteCommandValidator();
            var validationResult = await validator.ValidateAsync(request);
            if (validationResult.Errors.Count > 0)
            {
                createSiteCommandResponse.Success = false;
                createSiteCommandResponse.ValidationErrors = new List<string>();
                foreach (var error in validationResult.Errors)
                {
                    createSiteCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }
            if (createSiteCommandResponse.Success)
            {
                site = await _siteRepository.AddAsync(site);
                createSiteCommandResponse.SiteId = site.SiteId;
            }
            
            return createSiteCommandResponse;
        }
    }
}
