using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using RazorPagesProject.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace RazorPagesProjectsTests
{
   public class CustomWebApplicationFactory<TStartup>
        : WebApplicationFactory<TStartup> where TStartup: class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services => {
              //  services.AddScoped<IQuoteService, TestQuoteService>();
                // Configure Services
            });
        }
    }
    public class TestQuoteService : IQuoteService
    {
        public Task<string> GenerateQuote()
        {
            return Task.FromResult<string>(
                "Something's interfering with time, Mr. Scarman, " +
                "and time is my business.");
        }
    }
}
