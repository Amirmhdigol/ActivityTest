using ActivityTest.Application.Common;
using ActivityTest.Domain.ActivityTypeAgg.Repository;
using MediatR;

namespace ActivityTest.Application.ActivityType.Delete
{
    public class DeleteActivityTypeCommandHandler : IRequestHandler<DeleteActivityTypeCommand, OperationResult>
    {
        private readonly IActivityTypeRepository _repository;

        public DeleteActivityTypeCommandHandler(IActivityTypeRepository repository)
        {
            _repository = repository;
        }

        public async Task<OperationResult> Handle(DeleteActivityTypeCommand request, CancellationToken cancellationToken)
        {
            var activityType = await _repository.GetAsync(request.Id);

            if (activityType == null)
                return OperationResult.NotFound();

            _repository.Delete(activityType);
            try
            {
                await _repository.Save();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.InnerException.Message);
                return OperationResult.Error("server error", OperationResultStatus.Error);
            }

            return OperationResult.Success();
        }
    }
}