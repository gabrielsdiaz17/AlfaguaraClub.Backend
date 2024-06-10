using AlfaguaraClub.Backend.Application.Contracts.Persistence;
using AlfaguaraClub.Backend.Domain.Entities;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.CategoryServices.CreateCategoryCommands
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, CreateCategoryCommandResponse>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public CreateCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<CreateCategoryCommandResponse> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var createCategoryCommandResponse= new CreateCategoryCommandResponse();
            var newCategory = _mapper.Map<Category>(request);
            var validator = new CreateCategoryCommandValidator();
            var validationResult = await validator.ValidateAsync(request);
            if(validationResult.Errors.Count >= 0)
            {
                createCategoryCommandResponse.Success = false;
                createCategoryCommandResponse.ValidationErrors = new List<string>();
                foreach(var error in validationResult.Errors)
                {
                    createCategoryCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }
            if(createCategoryCommandResponse.Success)
            {
                newCategory = await _categoryRepository.AddAsync(newCategory);
                createCategoryCommandResponse.CategoryId = newCategory.CategoryId;
            }            
            return createCategoryCommandResponse;
        }
    }
}
