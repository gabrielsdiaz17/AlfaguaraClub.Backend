using AlfaguaraClub.Backend.Application.Contracts.Persistence;
using AutoMapper;
using MediatR;
using MercadoPago.Client.Preference;
using MercadoPago.Config;
using MercadoPago.Resource.Preference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.ProductServices.ShoppingCardCommands
{
    public class ShoppingCardCommandHandler : IRequestHandler<ShoppingCardCommand, Preference>
    {

        private readonly IParameterRepository _parameterRepository;
        public ShoppingCardCommandHandler(IUserInfoRepository userInfoRepository, IParameterRepository parameterRepository)
        {            
            _parameterRepository = parameterRepository;   
        }

        public async Task<Preference> Handle(ShoppingCardCommand request, CancellationToken cancellationToken)
        {
            var successUrlParameter = await _parameterRepository.GetParameterByName("successUrlPayment");
            var pendingUrlParameter = await _parameterRepository.GetParameterByName("pendingUrlPayment");
            var failureUrlParameter = await _parameterRepository.GetParameterByName("failureUrlPayment");
            var accessTokenParameter = await _parameterRepository.GetParameterByName("accessTokenMercadoPago");

            MercadoPagoConfig.AccessToken = accessTokenParameter.ParameterValue;

            var successUrl = string.Format(successUrlParameter.ParameterValue, request.CreateUserInfoCommand.IdentificationNumber);
            var pendingUrl = string.Format(pendingUrlParameter.ParameterValue, request.CreateUserInfoCommand.IdentificationNumber);
            var failureUrl = string.Format(failureUrlParameter.ParameterValue, request.CreateUserInfoCommand.IdentificationNumber);

            var backUrls = new PreferenceBackUrlsRequest
            {
                Success = successUrl,
                Pending = pendingUrl,
                Failure = failureUrl
            };
            var requestMP = new PreferenceRequest
            {
                Items = request.PreferenceRequest,
                BackUrls = backUrls
            };
            var client = new PreferenceClient();
            Preference preference = await client.CreateAsync(requestMP);
            return preference;
        }
    }
}
