using ActivityTest.Application.Common;
using ActivityTest.Domain.ActivityTypeAgg;
using ActivityTest.Domain.ActivityTypeAgg.Repository;
using ActivityTest.Infrastructure.Persistent.Ef;
using MediatR;

namespace ActivityTest.Application.ActivityType.Add
{
    public class AddActivityTypeCommandHandler : IRequestHandler<AddActivityTypeCommand, OperationResult>
    {
        private readonly ActivityContext _context;
        public AddActivityTypeCommandHandler(ActivityContext context)
        {
            _context = context;
        }

        public async Task<OperationResult> Handle(AddActivityTypeCommand request, CancellationToken cancellationToken)
        {
            var activityType = new ActivityTest.Domain.ActivityTypeAgg.ActivityType(request.Code, request.IsActive, request.Name);
            var activityTypeLog = new ActivityTypeLog(request.LogInformation);

            using var transaction = _context.Database.BeginTransaction();

            try
            {
                _context.Logs.Add(activityTypeLog);
                await _context.SaveChangesAsync(cancellationToken);

                _context.ActivityTypes.Add(activityType);
                await _context.SaveChangesAsync(cancellationToken);

                transaction.Commit();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.InnerException?.Message);
                return OperationResult.Error("server error", OperationResultStatus.Error);
            }

            return OperationResult.Success();
        }
    }
}