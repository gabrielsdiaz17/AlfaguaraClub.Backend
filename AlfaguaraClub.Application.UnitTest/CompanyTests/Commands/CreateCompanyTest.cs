using AlfaguaraClub.Application.UnitTest.Mocks;
using AlfaguaraClub.Backend.Application.Contracts.Persistence;
using AlfaguaraClub.Backend.Application.Profiles;
using AlfaguaraClub.Backend.Application.Services.CompanyServices.CreateCompanyCommands;
using AutoMapper;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Application.UnitTest.CompanyTests.Commands
{
    public class CreateCompanyTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<ICompanyRepository> _companyRepository;
        public CreateCompanyTest()
        {
            _companyRepository = RepositoryMocks.GetCompanyRepository();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });
            _mapper = configurationProvider.CreateMapper();
        }
        [Fact]
        public async Task Handle_ValidCompany()
        {
            var handler = new CreateCompanyCommandHandler(_companyRepository.Object,_mapper);
            await handler.Handle(new CreateCompanyCommand() {
                CompanyIdentifier = "9878554123", CompanyName = "TestCompanyFour" , IdentificationTypeId = 2
            }, CancellationToken.None);
            var allCompanies = await _companyRepository.Object.GetAllAsync();
            allCompanies.Count.ShouldBe(4);
        }
    }
}
