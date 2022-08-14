using ActivityTest.Domain.ActivityTypeAgg.Repository;
using ActivityTest.Infrastructure.Persistent.Ef;
using ActivityTest.Infrastructure.Persistent.Ef.ActivityTypeAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivityTest.Infrastructure.Utilities
{
    public static class InfrastructureDI
    {
        public static void Init(this IServiceCollection services, string connectionString)
        {   
            services.AddTransient<IActivityTypeRepository, ActivityTypeRepository>();

            services.AddDbContext<ActivityContext>(option =>
            {
                option.UseSqlServer(connectionString);
            });
        }
    }
}
