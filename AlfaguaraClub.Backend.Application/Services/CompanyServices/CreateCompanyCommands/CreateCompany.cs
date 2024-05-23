using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.CompanyServices.CreateCompanyCommands
{
    public class CreateCompany: IRequest<long>
    {
        public string CompanyName { get; set; }
        public string CompanyIdentifier { get; set; }
        public int IdentificationTypeId { get; set; }
        public string CompanyLogo { get; set; }
    }
}
