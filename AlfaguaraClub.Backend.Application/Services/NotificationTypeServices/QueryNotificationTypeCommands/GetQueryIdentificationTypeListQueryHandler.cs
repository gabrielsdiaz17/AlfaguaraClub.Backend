using AlfaguaraClub.Backend.Application.Contracts.Persistence;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.NotificationTypeServices.QueryNotificationTypeCommands
{
    public class GetQueryIdentificationTypeListQueryHandler : IRequestHandler<GetQueryIdentificationTypeListQuery, List<NotificationTypeListVm>>
    {
        private readonly INotificationTypeRepository _notificationTypeRepository;
        private readonly IMapper _mapper;

        public GetQueryIdentificationTypeListQueryHandler(INotificationTypeRepository notificationTypeRepository, IMapper mapper)
        {
            _notificationTypeRepository = notificationTypeRepository;
            _mapper = mapper;
        }

        public async Task<List<NotificationTypeListVm>> Handle(GetQueryIdentificationTypeListQuery request, CancellationToken cancellationToken)
        {
            var notificationTypes = await _notificationTypeRepository.GetNotificationTypes();
            return _mapper.Map<List<NotificationTypeListVm>>(notificationTypes);    
        }
    }
}
