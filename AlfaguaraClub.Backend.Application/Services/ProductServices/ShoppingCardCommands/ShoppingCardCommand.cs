using AlfaguaraClub.Backend.Application.Services.UserInfoServices.CreateUserInfoCommands;
using MercadoPago.Client.Preference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Services.ProductServices.ShoppingCardCommands
{
    public class ShoppingCardCommand
    {
        public CreateUserInfoCommand CreateUserInfoCommand { get; set; }
        public List<PreferenceItemRequest> PreferenceRequest { get; set; }
    }
}
