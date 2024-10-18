using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom.Mediator.Pattern
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddMediator(this IServiceCollection services)
        {
            
            return services;
        }
    }
}
