using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.TaxServices.CreateTaxCommands
{
    public class CreateTaxCommand: IRequest<CreateTaxCommandResponse>
    {
        public string TaxName { get; set; }
        public int TaxValue { get; set; }
        public double TaxPercentage { get; set; }
        public bool IsActive { get; set; }

        public override string ToString()
        {
            return $" Tax: {TaxName}; Value: {TaxValue}";
        }
    }
}
