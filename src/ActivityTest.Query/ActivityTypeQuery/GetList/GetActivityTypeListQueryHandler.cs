using ActivityTest.Infrastructure.Persistent.Ef;
using ActivityTest.Query.ActivityTypeQuery.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ActivityTest.Query.ActivityTypeQuery.GetList;

public class GetActivityTypeListQueryHandler : IRequestHandler<GetActivityTypeListQuery, List<ActivityTypeDTO>>
{
    private readonly ActivityContext _context;
    public GetActivityTypeListQueryHandler(ActivityContext context)
    {
        _context = context;
    }

    public async Task<List<ActivityTypeDTO>> Handle(GetActivityTypeListQuery request, CancellationToken cancellationToken)
    {
        var activityTypeList = await _context.ActivityTypes.OrderByDescending(a => a.Id).Select(b => new ActivityTypeDTO
        {
            CreationDate = b.CreationDate,
            Id = b.Id,
            Name = b.Name,
            Code = b.Code,
            IsActive = b.IsActive,
        }).ToListAsync(cancellationToken);
        return activityTypeList;
    }
}