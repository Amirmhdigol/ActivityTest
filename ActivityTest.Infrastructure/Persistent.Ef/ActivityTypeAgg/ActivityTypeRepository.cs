using ActivityTest.Domain.ActivityTypeAgg;
using ActivityTest.Domain.ActivityTypeAgg.Repository;
using ActivityTest.Infrastructure.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivityTest.Infrastructure.Persistent.Ef.ActivityTypeAgg;
public class ActivityTypeRepository : BaseRepository<ActivityType>, IActivityTypeRepository
{
    public ActivityTypeRepository(ActivityContext context) : base(context)
    {
    }

    public void Delete(ActivityType activityType)
    {
        _context.ActivityTypes.Remove(activityType);
    }
}