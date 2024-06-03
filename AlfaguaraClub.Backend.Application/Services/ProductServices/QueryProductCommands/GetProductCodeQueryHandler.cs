using AlfaguaraClub.Backend.Application.Contracts.Persistence;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.ProductServices.QueryProductCommands
{
    public class GetProductCodeQueryHandler : IRequestHandler<GetProductCodeQuery, ProductListVm>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public GetProductCodeQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<ProductListVm> Handle(GetProductCodeQuery request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetProductByCode(request.Code);
            return _mapper.Map<ProductListVm>(product);
        }
    }
}
