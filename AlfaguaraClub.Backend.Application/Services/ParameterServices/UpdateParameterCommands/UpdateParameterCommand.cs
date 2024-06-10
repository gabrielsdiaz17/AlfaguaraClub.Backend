using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.ParameterServices.UpdateParameterCommands
{
    public class UpdateParameterCommand:IRequest
    {
        public long ParameterId { get; set; }
        public string ParameterName { get; set; }
        public string ParameterValue { get; set; }
        public bool IsActive { get; set; }

    }
}
