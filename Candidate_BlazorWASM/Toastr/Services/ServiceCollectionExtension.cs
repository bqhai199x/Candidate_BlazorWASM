using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidae_Blazor.Toastr.Services
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddBlazorToastr(this IServiceCollection services)
            => services.AddScoped<ToastrService>();
    }
}
