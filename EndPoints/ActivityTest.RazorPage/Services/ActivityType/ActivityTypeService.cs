using ActivityTest.Application.ActivityType.Add;
using ActivityTest.Application.ActivityType.Delete;
using ActivityTest.Application.ActivityType.Edit;
using ActivityTest.Application.Common;
using ActivityTest.Query.ActivityTypeQuery.DTOs;
using ActivityTest.RazorPage.Models;

namespace ActivityTest.RazorPage.Services.ActivityType;
public class ActivityTypeService : IActivityTypeService
{
    #region Ctor
    private readonly HttpClient _httpClient;

    public ActivityTypeService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    #endregion

    public async Task<ApiResult?> Add(AddActivityTypeCommand command)
    {
        var result = await _httpClient.PostAsJsonAsync("https://localhost:7039/api/ActivityType", command);
        return await result.Content.ReadFromJsonAsync<ApiResult>();
    }

    public async Task<ApiResult?> DeleteComment(DeleteActivityTypeCommand command)
    {
        var result = await _httpClient.PutAsJsonAsync("https://localhost:7039/api/ActivityType", command);
        return await result.Content.ReadFromJsonAsync<ApiResult>();
    }

    public async Task<ApiResult?> Edit(EditActivityTypeCommand command)
    {
        var result = await _httpClient.PutAsJsonAsync("https://localhost:7039/api/ActivityType/Delete", command);
        return await result.Content.ReadFromJsonAsync<ApiResult>();
    }

    public async Task<List<ActivityTypeDTO>?> GetList()
    {
        var result = await _httpClient.GetFromJsonAsync<ApiResult<List<ActivityTypeDTO>>>("https://localhost:7039/api/ActivityType");
        return result?.Data;
    }

    public async Task<ActivityTypeDTO?> GettById(int id)
    {
        var result = await _httpClient.GetFromJsonAsync<ApiResult<ActivityTypeDTO>>($"https://localhost:7039/api/ActivityType/{id}");
        return result?.Data;
    }
}