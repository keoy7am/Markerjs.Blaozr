using Markerjs.Blazor.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Markerjs.Blazor
{
    public static class DependencyInjectionRegister
    {
        public static void AddMarkerJs(this IServiceCollection services) => services.AddScoped<MarkerJSService>();
    }
}
