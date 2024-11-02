using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Contracts.Infraestructure
{
    public interface IEmailService
    {
        Task SendEmailAsync(string to, string subject, string body, string username, string password);
    }
}
