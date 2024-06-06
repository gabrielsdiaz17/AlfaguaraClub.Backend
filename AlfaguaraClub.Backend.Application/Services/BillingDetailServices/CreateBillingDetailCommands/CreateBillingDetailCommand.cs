using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.BillingDetailServices.CreateBillingDetailCommands
{
    public class CreateBillingDetailCommand: IRequest<long>
    {
        public long BillingId { get; set; }
        public long ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal SubtotalPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public override string ToString()
        {
            return $"Billing Detail Billing: {BillingId}; Product:{ProductId}; Quantity: {Quantity}; TotalPrice: {TotalPrice}" ;
        }
    }
}
