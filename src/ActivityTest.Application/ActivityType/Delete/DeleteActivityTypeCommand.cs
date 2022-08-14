using ActivityTest.Application.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivityTest.Application.ActivityType.Delete
{
    public record DeleteActivityTypeCommand(int Id) : IRequest<OperationResult>;
}