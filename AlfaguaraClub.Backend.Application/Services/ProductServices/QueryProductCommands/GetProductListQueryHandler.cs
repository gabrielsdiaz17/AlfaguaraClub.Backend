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
    public class GetProductListQueryHandler : IRequestHandler<GetProductListQuery, List<ProductListVm>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public GetProductListQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<List<ProductListVm>> Handle(GetProductListQuery request, CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetProductsActive();
            return _mapper.Map<List<ProductListVm>>(products);
        }
    }
}
