using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public static class DependencyInjectionService
    {
        public static IServiceCollection addCommon(this IServiceCollection services)
        {
            return services;
        }
    }
}
