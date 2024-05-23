using AlfaguaraClub.Backend.Application.Services.CompanyServices;
using AlfaguaraClub.Backend.Application.Services.CompanyServices.CreateCompanyCommands;
using AlfaguaraClub.Backend.Application.Services.CompanyServices.UpdateCompanyCommands;
using AlfaguaraClub.Backend.Application.Services.CostcenterServices.CreateCostCenterCommands;
using AlfaguaraClub.Backend.Application.Services.CostcenterServices.QueryCostCenterCommands;
using AlfaguaraClub.Backend.Application.Services.CostcenterServices.UpdateCostCenterCommands;
using AlfaguaraClub.Backend.Application.Services.SiteServices.CreateSiteCommands;
using AlfaguaraClub.Backend.Application.Services.SiteServices.QuerySiteCommands;
using AlfaguaraClub.Backend.Application.Services.SiteServices.UpdateCompanyCommands;
using AlfaguaraClub.Backend.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Profiles
{
    public class MappingProfile: Profile
    {
        public MappingProfile() 
        {
            CreateMap<Company,CompanyListVm>().ReverseMap();
            CreateMap<Company,CreateCompany>().ReverseMap();
            CreateMap<Company,UpdateCompanyCommand>().ReverseMap();
            CreateMap<Site,SiteListVm>().ReverseMap();
            CreateMap<Site,CreateSiteCommand>().ReverseMap();
            CreateMap<Site,UpdateSiteCommand>().ReverseMap();
            CreateMap<CostCenter,CostCenterDto>().ReverseMap();
            CreateMap<CostCenter,CreateCostCenterCommand>().ReverseMap();
            CreateMap<CostCenter,UpdateCostCenterCommand>().ReverseMap();
            CreateMap<CostCenter,CostCenterListVm>().ReverseMap();
            CreateMap<Space,SpaceDto>().ReverseMap();
        }
    }
}
