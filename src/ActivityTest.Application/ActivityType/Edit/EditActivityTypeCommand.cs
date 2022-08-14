using ActivityTest.Application.Common;
using MediatR;

namespace ActivityTest.Application.ActivityType.Edit;

public record EditActivityTypeCommand(int Id, string Name, int Code, bool IsActive) : IRequest<OperationResult>;
