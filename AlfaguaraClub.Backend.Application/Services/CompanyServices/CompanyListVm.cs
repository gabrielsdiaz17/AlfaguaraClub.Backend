﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.CompanyServices
{
    public class CompanyListVm
    {
        public long CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string CompanyIdentifier { get; set; }
        public int IdentificationTypeId { get; set; }
        public string CompanyLogo { get; set; }

    }
}