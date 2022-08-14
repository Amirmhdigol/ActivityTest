using ActivityTest.Application.Common;
using ActivityTest.Domain.ActivityTypeAgg.Repository;
using MediatR;

namespace ActivityTest.Application.ActivityType.Edit;

public class EditActivityTypeCommandHandler : IRequestHandler<EditActivityTypeCommand, OperationResult>
{
    private readonly IActivityTypeRepository _repository;
    public EditActivityTypeCommandHandler(IActivityTypeRepository repository)
    {
        _repository = repository;
    }

    public async Task<OperationResult> Handle(EditActivityTypeCommand request, CancellationToken cancellationToken)
    {
        var activityType = await _repository.GetTracking(request.Id);

        if (activityType == null)
            return OperationResult.NotFound();

        activityType.Edit(request.Name, request.IsActive, request.Code);
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