using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Services.Abstractions.DTO;
using Services.Abstractions.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Exam.Middleware
{
    public class AdminSafeListMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<AdminSafeListMiddleware> _logger;

        public AdminSafeListMiddleware(RequestDelegate next, ILogger<AdminSafeListMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context, IServiceManager serviceManager)
        {
            var blackIps = await serviceManager.BlackIpsService.GetAll();
            var remoteIp = context.Connection.RemoteIpAddress;
            var badIp = false;
            foreach (var address in blackIps)
            {
                if (address.Name == remoteIp.ToString())
                {
                    badIp = true;
                    break;
                }
            }

            if (badIp)
            {
                context.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                return;
            }

            await _next.Invoke(context);
        }
    }
}
