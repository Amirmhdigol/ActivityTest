using ActivityTest.Query.ActivityTypeQuery.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivityTest.Query.ActivityTypeQuery.GetById;
public record GetActivityTypeByIdQuery(int Id) : IRequest<ActivityTypeDTO?>;
