using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Extensions
{
    public static class UseDelayForDevelopment
    {
        public static void DelayForDevelopment(this IApplicationBuilder app)
        {
            app.Use(async (context, next) =>
            {
                await Task.Delay(2000);

                await next.Invoke();
            });
        }
    }
}
