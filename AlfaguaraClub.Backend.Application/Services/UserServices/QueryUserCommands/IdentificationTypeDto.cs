using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.UserServices.QueryUserCommands
{
    public class IdentificationTypeDto
    {
        public int IdendificationTypeId { get; set; }
        public int IdentificationTypeCode { get; set; }
        public string Nomenclature { get; set; }
        public string Description { get; set; }

    }
}
