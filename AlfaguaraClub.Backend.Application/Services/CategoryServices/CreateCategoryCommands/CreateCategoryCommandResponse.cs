using AlfaguaraClub.Backend.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.CategoryServices.CreateCategoryCommands
{
    public class CreateCategoryCommandResponse:BaseResponse
    {
        public CreateCategoryCommandResponse():base()
        {
            
        }
        public int CategoryId { get; set; }

    }
}
