using Business.Middlewares;
using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolvers
{
    public static class MiddlewaresInjection
    {
        public static IApplicationBuilder AddMiddlewares(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<BaseRequestHandler>();
        }
    }
}
