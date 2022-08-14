using ActivityTest.Infrastructure.Persistent.Ef;
using ActivityTest.Query.ActivityTypeQuery.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ActivityTest.Query.ActivityTypeQuery.GetById;

public class GetActivityTypeByIdQueryHandler : IRequestHandler<GetActivityTypeByIdQuery, ActivityTypeDTO>
{
    private readonly ActivityContext _context;
    public GetActivityTypeByIdQueryHandler(ActivityContext context)
    {
        _context = context;
    }
    public async Task<ActivityTypeDTO> Handle(GetActivityTypeByIdQuery request, CancellationToken cancellationToken)
    {
        var activityType = await _context.ActivityTypes.FirstOrDefaultAsync(a => a.Id == request.Id, cancellationToken);

        var model =  new ActivityTypeDTO
        {
            Id = request.Id,
            CreationDate = activityType.CreationDate,
            Code = activityType.Code,
            Name = activityType.Name,
            IsActive = activityType.IsActive,
        };

        return model;
    }
}
