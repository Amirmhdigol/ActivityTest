using ActivityTest.Application.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivityTest.Application.ActivityType.Add
{
    public class AddActivityTypeCommand : IRequest<OperationResult>
    {
        public string Name { get; set; }
        public int Code { get; set; }
        public bool IsActive { get; set; }
        public string LogInformation { get; set; }
    }
}