using AlfaguaraClub.Backend.Application.Contracts.Persistence;
using AlfaguaraClub.Backend.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.CouponServices.CreateCouponPurchaseCommands
{
    public class AddCouponPurchaseCommandHandler : IRequestHandler<AddCouponPurchaseCommand, AddCouponPurchaseResponse>
    {
        private readonly IMonthlyCouponBookRepository _couponBookRepository;
        private readonly ICouponPurchaseRepository _purchaseRepository;
        private readonly IProductRepository _productRepository;

        public AddCouponPurchaseCommandHandler(
            IMonthlyCouponBookRepository couponBookRepo,
            ICouponPurchaseRepository purchaseRepo,
            IProductRepository productRepo)
        {
            _couponBookRepository = couponBookRepo;
            _purchaseRepository = purchaseRepo;
            _productRepository = productRepo;
        }

        public async Task<AddCouponPurchaseResponse> Handle(AddCouponPurchaseCommand request, CancellationToken cancellationToken)
        {
            var book = await _couponBookRepository.GetByIdAsync(request.MonthlyCouponBookId);
            if (book == null || !book.IsActive) throw new Exception("Coupon book not available or inactive");

            decimal totalCost = 0;

            foreach (var item in request.Purchases)
            {
                var product = await _productRepository.GetByIdAsync(item.ProductId);
                if (product == null)
                    throw new Exception($"Product with ID {item.ProductId} not found.");

            }

            if (totalCost > book.CurrentBalance)
                throw new Exception("Insufficient coupon book balance.");

            foreach (var item in request.Purchases)
            {
                var product = await _productRepository.GetByIdAsync(item.ProductId);
                var purchase = new CouponPurchase
                {
                    MonthlyCouponBookId = book.MonthlyCouponBookId,
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    TotalPrice = item.TotalPrice,
                    CostCenterId = item.CostCenterId,
                    Comment = item.Comment,
                    UserId = item.UserId
                };

                await _purchaseRepository.AddAsync(purchase);
            }

            book.CurrentBalance -= totalCost;
            await _couponBookRepository.UpdateAsync(book);

            return new AddCouponPurchaseResponse
            {
                RemainingBalance = book.CurrentBalance
            };

        }
    }
}
