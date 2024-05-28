using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.IdentificationTypeServices.QueryIdentificationTypeCommands
{
    public class QueryIdentificationTypeQuery: IRequest<List<IdentificationTypeListVm>>
    {
    }
}
