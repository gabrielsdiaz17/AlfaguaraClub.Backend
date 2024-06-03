using AlfaguaraClub.Backend.Application.Contracts.Persistence;
using AlfaguaraClub.Backend.Domain.Entities;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.ProductServices.CreateProductCommands
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, long>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public CreateProductCommandHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<long> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var newProduct = _mapper.Map<Product>(request);
            newProduct = await _productRepository.AddAsync(newProduct);
            return newProduct.ProductId;
        }
    }
}
