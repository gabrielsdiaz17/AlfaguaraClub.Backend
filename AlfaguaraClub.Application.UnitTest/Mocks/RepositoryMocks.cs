using AlfaguaraClub.Backend.Application.Contracts.Persistence;
using AlfaguaraClub.Backend.Domain.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Application.UnitTest.Mocks
{
    public class RepositoryMocks
    {
        public static Mock<ICompanyRepository> GetCompanyRepository()
        {
            var companies = new List<Company>()
            {
                new Company()
                {
                    CompanyId = 1,
                    CompanyIdentifier = "91000000",
                    CompanyName = "TestCompanyOne",
                    IdentificationTypeId = 2
                },
                new Company()
                {
                    CompanyId = 2,
                    CompanyIdentifier = "95288800",
                    CompanyName = "TestCompanyTwo",
                    IdentificationTypeId = 2
                },
                new Company()
                {
                    CompanyId = 3,
                    CompanyIdentifier = "96300000",
                    CompanyName = "TestCompanyThree",
                    IdentificationTypeId = 2
                },
            };
            var mockCompanyRepository = new Mock<ICompanyRepository>();
            mockCompanyRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(companies);

            mockCompanyRepository.Setup(repo => repo.AddAsync(It.IsAny<Company>())).ReturnsAsync(
                (Company company) =>
                {
                    companies.Add(company);
                    return company;
                });
            return mockCompanyRepository;
        }
    }
}
