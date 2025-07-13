using AlfaguaraClub.Backend.Application.Contracts.Persistence;
using AlfaguaraClub.Backend.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.CouponServices.CreateMonthlyCouponCommands
{
    public class CreateCouponBookCommandHandler : IRequestHandler<CreateCouponBookCommand, CreateCouponBookResponse>
    {
        private readonly IMonthlyCouponBookRepository  _couponBookRepo;

        public CreateCouponBookCommandHandler(IMonthlyCouponBookRepository couponBookRepo)
        {
            _couponBookRepo = couponBookRepo;
        }

        public async Task<CreateCouponBookResponse> Handle(CreateCouponBookCommand request, CancellationToken cancellationToken)
        {
            var book = new MonthlyCouponBook
            {
                MembershipId = request.MembershipId,
                Month = request.Month,
                InitialBalance = request.InitialBalance,
                CurrentBalance = request.InitialBalance,
                IsActive = true
            };
            book = await _couponBookRepo.AddAsync(book);
            return new CreateCouponBookResponse { MonthlyCouponBookId = book.MonthlyCouponBookId };
        }
    }
}
