using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.IdentificationTypeServices.CreateIdentificationTypeCommands
{
    public class CreateIdentificationTypeCommand:IRequest<CreateIdentificationTypeCommandResponse>
    {
        public int IdentificationTypeCode { get; set; }
        public string Nomenclature { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }

        public override string ToString()
        {
            return $"Identification Type Code:{IdentificationTypeCode}; Nomenclature:{Nomenclature}; Description{Description}";
        }

    }
}
