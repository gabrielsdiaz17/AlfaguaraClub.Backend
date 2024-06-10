using AlfaguaraClub.Backend.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.TaxServices.CreateTaxCommands
{
    public  class CreateTaxCommandResponse:BaseResponse
    {
        public CreateTaxCommandResponse():base()
        {
            
        }
        public int TaxId { get; set; }

    }
}
