using System;
using Xunit;
using InfoTrackSearch_BED.Services;
using InfoTrackSearch_BED.Controllers;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc;

namespace TestApi
{
    public class UnitTest1
    {
        private readonly SearchService _services;
        private readonly IConfiguration _config;
        public UnitTest1()
        {
            string _currentDir = System.IO.Directory.GetCurrentDirectory();
            IConfigurationBuilder builder = new ConfigurationBuilder()
              .SetBasePath(_currentDir)
              .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true).AddEnvironmentVariables();
            IConfigurationRoot config = builder.Build();
            _config = config;
            _services = new SearchService(_config);
        }
        [Fact]
        public async void GetGoogleSuccess()
        {
            var controller = new SearchController(_services);
            var response = await controller.GetGoogle("online title search");
            var test = (OkObjectResult)response;
            Assert.IsType<OkObjectResult>(response);
            string result = (string)test.Value;
            Assert.Equal("4,4,0,0,0", result);
        }
    }
}
