using AlfaguaraClub.Application.UnitTest.Mocks;
using AlfaguaraClub.Backend.Application.Contracts.Persistence;
using AlfaguaraClub.Backend.Application.Profiles;
using AlfaguaraClub.Backend.Application.Services.CompanyServices;
using AutoMapper;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Application.UnitTest.CompanyTests.Queries
{
    public class GetCompanyListQueryHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<ICompanyRepository> _mockCompanyRepository;
        public GetCompanyListQueryHandlerTest()
        {
            _mockCompanyRepository = RepositoryMocks.GetCompanyRepository();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });
            _mapper = configurationProvider.CreateMapper();
        }
        [Fact]
        public async Task GetCompanyListTest()
        {
            var handler = new GetCompanyListQueryHandler(_mockCompanyRepository.Object, _mapper);
            var result = await handler.Handle(new GetCompanyListQuery(),CancellationToken.None);
            result.ShouldBeOfType<List<CompanyListVm>>();
            result.Count.ShouldBe(3);
        }
    }
}
