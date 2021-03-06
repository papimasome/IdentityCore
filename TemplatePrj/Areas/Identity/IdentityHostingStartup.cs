using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TemplatePrj.Data;

[assembly: HostingStartup(typeof(TemplatePrj.Areas.Identity.IdentityHostingStartup))]
namespace TemplatePrj.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {

                services.AddAntiforgery(options =>
                {
                    options.FormFieldName = "Input.__RequestVerificationToken";
                });
            });
        }
    }
}