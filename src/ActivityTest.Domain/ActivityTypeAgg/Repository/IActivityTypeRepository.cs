using ActivityTest.Domain.Common.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivityTest.Domain.ActivityTypeAgg.Repository
{
    public interface IActivityTypeRepository : IBaseRepository<ActivityType>
    {
        void Delete(ActivityType activityType);
    }
}
