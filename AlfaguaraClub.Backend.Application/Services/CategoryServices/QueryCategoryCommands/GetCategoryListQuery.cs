using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.CategoryServices.QueryCategoryCommands
{
    public class GetCategoryListQuery:IRequest<List<CategoryListVm>>
    {
    }
}
