using AlfaguaraClub.Backend.Application.Contracts.Infraestructure;
using AlfaguaraClub.Backend.Application.Contracts.Persistence;
using AlfaguaraClub.Backend.Domain.Entities;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.BookingServices.CreateBookingCommands
{
    public class CreateBookingCommandHandler : IRequestHandler<CreateBookingCommand, CreateBookingCommandResponse>
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IMapper _mapper;
        private readonly IParameterRepository _parameterRepository;
        private readonly IEmailService _emailService;

        public CreateBookingCommandHandler(IBookingRepository bookingRepository, IMapper mapper, 
            IParameterRepository parameterRepository, IEmailService emailService)
        {
            _bookingRepository = bookingRepository;
            _mapper = mapper;
            _parameterRepository = parameterRepository;
            _emailService = emailService;
        }

        public async Task<CreateBookingCommandResponse> Handle(CreateBookingCommand request, CancellationToken cancellationToken)
        {
            var createBookingCommandResponse = new CreateBookingCommandResponse();
            var booking = _mapper.Map<Booking>(request);
            var validator = new CreateBookingCommandValidator();
            var validationResult = await validator.ValidateAsync(request);
            if (validationResult.Errors.Count >0 )
            {
                createBookingCommandResponse.Success = false;
                createBookingCommandResponse.ValidationErrors = new List<string>();
                foreach( var error in validationResult.Errors )
                {
                    createBookingCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }
            if (createBookingCommandResponse.Success)
            {
                try
                {
                    booking = await _bookingRepository.AddAsync(booking);
                    createBookingCommandResponse.BookingId = booking.BookingId;
                    var parameterUser = await _parameterRepository.GetParameterByName("useremailadmin");
                    var parameterPassword = await _parameterRepository.GetParameterByName("passwordemailadmin");
                    var adminReceiver = await _parameterRepository.GetParameterByName("adminreceiver");
                    var bookingDetail = await _bookingRepository.GetBookingDetailByBookingId(booking.BookingId);

                    var adminSubject = "Nueva reserva en Espacio Alfaguara";
                    var adminBody = string.Format("Una nueva reserva ha sido realizada para la membresia {0}. " +
                        "El usuario {1} ha realizado una reserva para la actividad {2}, para el dia {3}",
                        bookingDetail.Membership.UniqueIdentifier, bookingDetail.User.Name + " " +
                        bookingDetail.User.LastName, bookingDetail.SpaceActivity.ActivityName,
                        bookingDetail.SpaceActivity.ActivityDate.ToString("yyyy-mm-dd"));

                    await _emailService.SendEmailAsync(adminReceiver.ParameterValue, adminSubject, adminBody, parameterUser.ParameterValue, parameterPassword.ParameterValue);

                    var userSubject = "Confirmación Reserva en Club Alfaguara";
                    var userBody = string.Format("Cordial Saludo {0}. \n Espacios Alfaguara se complace en confirmar su reserva para el evento {1} que se llevara a cabo el dia {2} en  {3}. \n Le esperamos a usted y a sus afiliados", bookingDetail.User.Name + " " +
                        bookingDetail.User.LastName, bookingDetail.SpaceActivity.ActivityName, bookingDetail.SpaceActivity.ActivityDate.ToString("yyyy-mm-dd"), bookingDetail.SpaceActivity.Space.SpaceName);

                    await _emailService.SendEmailAsync(bookingDetail.User.Email,userSubject,userBody, parameterUser.ParameterValue,parameterPassword.ParameterValue);
                }
                catch (Exception ex) 
                {
                    createBookingCommandResponse.ValidationErrors = new List<string> { ex.Message };
                }
            }
            return createBookingCommandResponse;
        }
    }
}
