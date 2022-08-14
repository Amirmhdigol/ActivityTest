using ActivityTest.Api.Controllers;
using ActivityTest.Application.Common;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ActivityTest.Api.ApiHelper
{
    public class Utilities : ControllerBase
    {
        protected ApiResult CommandResult(OperationResult operation)
        {
            return new ApiResult
            {
                IsSuccess = operation.Status == OperationResultStatus.Success,
                MetaData = new()
                {
                    Message = operation.Message,
                    AppStatusCode = operation.Status.MapOperationStatus()
                }
            };
        }
        public ApiResult<TData?> CommandResult<TData>(OperationResult<TData> result, HttpStatusCode statusCode = HttpStatusCode.OK
    , string locationUrl = null)
        {
            bool isSuccess = result.Status == OperationResultStatus.Success;
            //if (isSuccess)
            //{
            //    HttpContext.Response.StatusCode = (int)statusCode;
            //    if (!string.IsNullOrWhiteSpace(locationUrl))
            //    {
            //        HttpContext.Response.Headers.Add("location", locationUrl);
            //    }
            //}
            return new ApiResult<TData?>
            {
                IsSuccess = isSuccess,
                Data = isSuccess ? result.Data : default,
                MetaData = new MetaData
                {
                    AppStatusCode = result.Status.MapOperationStatus(),
                    Message = result.Message,
                }
            };
        }
        public ApiResult<TData> QueryResult<TData>(TData data)
        {
            return new ApiResult<TData>
            {
                IsSuccess = true,
                Data = data,
                MetaData = new MetaData
                {
                    AppStatusCode = AppStatusCode.Success,
                    Message = "Operation Done",
                }
            };
        }

    }
}

public static class EnumHelper
{
    public static AppStatusCode MapOperationStatus(this OperationResultStatus status)
    {
        switch (status)
        {
            case OperationResultStatus.Success: return AppStatusCode.Success;
            case OperationResultStatus.NotFound: return AppStatusCode.NotFound;
            case OperationResultStatus.Error: return AppStatusCode.LogicError;
        }
        return AppStatusCode.LogicError;
    }
}