﻿using AlfaguaraClub.Backend.Application.Contracts.Persistence;
using AlfaguaraClub.Backend.Application.Exceptions;
using AlfaguaraClub.Backend.Domain.Entities;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.TypeActivityServices.UpdateTypeActivityCommands
{
    public class UpdateTypeActivityCommandHandler : IRequestHandler<UpdateTypeActivityCommand>
    {
        private ITypeActivityRepository _typeActivityRepository;
        private IMapper _mapper;
        public UpdateTypeActivityCommandHandler(ITypeActivityRepository typeActivityRepository, IMapper mapper)
        {
            _typeActivityRepository = typeActivityRepository;
            _mapper = mapper;
        }

        public async Task Handle(UpdateTypeActivityCommand request, CancellationToken cancellationToken)
        {
            var typeActivityToUpdate = await _typeActivityRepository.GetByIdAsync(request.TypeActivityId);
            if (typeActivityToUpdate == null) 
                throw new NotFoundException(nameof(TypeActivity),  request.TypeActivityId);
            var validator = new UpdateTypeActivityCommandValidator();
            var validationResult = await validator.ValidateAsync(request);
            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);
            _mapper.Map(request, typeActivityToUpdate, typeof(UpdateTypeActivityCommand), typeof(TypeActivity));
            await _typeActivityRepository.UpdateAsync(typeActivityToUpdate);
        }
    }
}
