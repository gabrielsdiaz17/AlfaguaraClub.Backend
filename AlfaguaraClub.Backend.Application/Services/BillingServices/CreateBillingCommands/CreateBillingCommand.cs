using AlfaguaraClub.Backend.Application.Services.CompanyServices.CreateCompanyCommands;
using AlfaguaraClub.Backend.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.BillingServices.CreateBillingCommands
{
    public class CreateBillingCommand: IRequest<CreateBillingCommandResponse>
    {
        public DateTimeOffset BillingDate { get; set; }
        public string BillingConsecutive { get; set; }

        public long UserId { get; set; }
        public int BillingStatusId { get; set; }

        public long? BookingId { get; set; }
        public int PaymentMethodId { get; set; }
        public string Observations { get; set; }
        public bool IsActive { get; set; }

        public override string ToString()
        {
            return $"Billing Consecutive: {BillingConsecutive}; User: {UserId}; Status: {BillingStatusId}; Payment method: {PaymentMethodId}; Observations{Observations}";
        }

    }
}
