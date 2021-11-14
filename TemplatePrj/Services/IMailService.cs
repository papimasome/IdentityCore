using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TemplatePrj.Models.Settings;

namespace TemplatePrj.Services
{
    public interface IMailService
    {
        Task SendEmailAsync(MailRequest mailRequest);
        //send by html template
        Task SendWelcomeEmailAsync(WelcomeRequest request);
    }
}
