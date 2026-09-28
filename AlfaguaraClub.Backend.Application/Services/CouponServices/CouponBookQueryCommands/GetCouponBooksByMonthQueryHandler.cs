using AlfaguaraClub.Backend.Application.Contracts.Persistence;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.CouponServices.CouponBookQueryCommands
{
    public class GetCouponBooksByMonthQueryHandler : IRequestHandler<GetCouponBooksByMonthQuery, List<CouponBookVm>>
    {
        private readonly IMonthlyCouponBookRepository _monthlyCouponBookRepository;
        private readonly IMapper _mapper;
        public GetCouponBooksByMonthQueryHandler(IMonthlyCouponBookRepository monthlyCouponBookRepository, IMapper mapper)
        {
            _monthlyCouponBookRepository = monthlyCouponBookRepository;
            _mapper = mapper;
        }
        public async Task<List<CouponBookVm>> Handle(GetCouponBooksByMonthQuery request, CancellationToken cancellationToken)
        {
            var books = await _monthlyCouponBookRepository.GetCouponBooksByMonthAsync(request.Month);
            return _mapper.Map<List<CouponBookVm>>(books);
        }
    }
}
