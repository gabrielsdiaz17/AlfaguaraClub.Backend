using AlfaguaraClub.Backend.Application.Contracts.Persistence;
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
    public class CreateSiteCommandHandler : IRequestHandler<CreateSiteCommand, long>
    {
        private readonly ISiteRepository _siteRepository;
        private readonly IMapper _mapper;
        public  CreateSiteCommandHandler(ISiteRepository siteRepository, IMapper mapper)
        {
            _siteRepository = siteRepository;
            _mapper = mapper;
        }
        public async Task<long> Handle(CreateSiteCommand request, CancellationToken cancellationToken)
        {
            var site = _mapper.Map<Site>(request);
            site = await _siteRepository.AddAsync(site);
            return site.SiteId;
        }
    }
}
