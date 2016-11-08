using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
 
using UraApp.Models;
using UraApp.Services.Impl;
using UraApp.Services.Abstract;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.Net.Http.Headers;
using UraApp.Utility;
 

namespace UraApp.Controllers
{
    [Route("api/[controller]")]
    public class PortfoliosController : Controller
    {
        public IPortfolioService service;
        private IHostingEnvironment _environment;
        private string imagesfolder = @"\Images\photos\";

        public PortfoliosController(IPortfolioService serv, IHostingEnvironment environment)
        {
            service = serv;
            _environment = environment;
        }


       
    }
}
