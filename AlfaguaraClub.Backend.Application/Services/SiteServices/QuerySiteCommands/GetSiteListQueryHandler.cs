using AlfaguaraClub.Backend.Application.Contracts.Persistence;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.SiteServices.QuerySiteCommands
{
    public class GetSiteListQueryHandler : IRequestHandler<GetSiteListQuery, List<SiteListVm>>
    {
        private readonly ISiteRepository _siteRepository;
        private readonly IMapper _mapper;
        public GetSiteListQueryHandler(ISiteRepository siteRepository, IMapper mapper)
        {
            _siteRepository = siteRepository;
            _mapper = mapper;
        }

        public async Task<List<SiteListVm>> Handle(GetSiteListQuery request, CancellationToken cancellationToken)
        {
            var siteWithCostCenter = await _siteRepository.GetSiteWithCostCenter();
            return _mapper.Map<List<SiteListVm>>(siteWithCostCenter);
        }
    }
}
