using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.CategoryServices.CreateCategoryCommands
{
    public class CreateCategoryCommand:IRequest<CreateCategoryCommandResponse>
    {
        public string CategoryName { get; set; }
        public bool IsActive { get; set; }

        public override string ToString()
        {
            return $"Category Name {CategoryName}";
        }
    }
}
