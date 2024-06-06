using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.ParameterServices.CreateParameterCommands
{
    public class CreateParameterCommand: IRequest<long>
    {
        public string ParameterName { get; set; }
        public string ParameterValue { get; set; }
        public override string ToString()
        {
            return $"Parameter Name: {ParameterName}; Value: {ParameterValue}";
        }
    }
}
