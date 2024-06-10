using AlfaguaraClub.Backend.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.ProductServices.CreateProductCommands
{
    public class CreateProductCommandResponse:BaseResponse
    {
        public CreateProductCommandResponse():base()
        {
            
        }
        public long ProductId { get; set; }

    }
}
