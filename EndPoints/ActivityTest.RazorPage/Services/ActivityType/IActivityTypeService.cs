using ActivityTest.Application.ActivityType.Add;
using ActivityTest.Application.ActivityType.Delete;
using ActivityTest.Application.ActivityType.Edit;
using ActivityTest.Application.Common;
using ActivityTest.Query.ActivityTypeQuery.DTOs;
using ActivityTest.RazorPage.Models;

namespace ActivityTest.RazorPage.Services.ActivityType;
public interface IActivityTypeService
{
    Task<ApiResult?> Add(AddActivityTypeCommand command);
    Task<ApiResult?> Edit(EditActivityTypeCommand command);
    Task<ApiResult?> DeleteComment(DeleteActivityTypeCommand command);

    Task<ActivityTypeDTO?> GettById(int Id);
    Task<List<ActivityTypeDTO>?> GetList();
}