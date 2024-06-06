using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.CompanyServices.CreateCompanyCommands
{
    public class CreateCompanyCommand: IRequest<CreateCompanyCommandResponse>
    {
        public string CompanyName { get; set; }
        public string CompanyIdentifier { get; set; }
        public int IdentificationTypeId { get; set; }
        public string CompanyLogo { get; set; }
        public override string ToString()
        {
            return $"Company {CompanyName}; Identifier{CompanyIdentifier}; Identification Type{IdentificationTypeId}";
        }
    }
}
