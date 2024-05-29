using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.ParameterServices.QueryParameterCommands
{
    public class GetParameterQuery: IRequest<ParameterListVm>
    {
        public long ParameterId { get; set; }
    {
    }
}
