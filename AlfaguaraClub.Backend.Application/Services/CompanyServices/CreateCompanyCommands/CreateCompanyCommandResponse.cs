using AlfaguaraClub.Backend.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.CompanyServices.CreateCompanyCommands
{
    public class CreateCompanyCommandResponse:BaseResponse
    {
        public CreateCompanyCommandResponse():base()
        {
            
        }
        public long CompanyId { get; set; }
    }
}
