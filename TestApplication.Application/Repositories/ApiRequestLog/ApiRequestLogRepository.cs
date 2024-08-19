using Ardalis.GuardClauses;
using Microsoft.EntityFrameworkCore;
using TestApplication.Application.Common.Interfaces;
using TestApplication.Domain.Entities;
using TestApplication.Domain.Enums;

namespace TestApplication.Application.Repositories.ApiRequestLog;

public class ApiRequestLogRepository : IApiRequestLogRepository
{
    private readonly ITestDataDbContext _context;
    public ApiRequestLogRepository(ITestDataDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Get API request log by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<ApiRequestLogEntity?> GetApiRequestLogAsync(int id)
    {
        return await _context.ApiRequestLogs.FirstOrDefaultAsync(a => a.Id == id);
    }

    /// <summary>
    /// Adding API Request Log
    /// </summary>
    /// <param name="apiId"></param>
    /// <param name="requestDateTimeUtc"></param>
    /// <param name="requestMethod"></param>
    /// <param name="requestPath"></param>
    /// <param name="requestQuery"></param>
    /// <param name="requestBody"></param>
    /// <param name="requestScheme"></param>
    /// <param name="requestHost"></param>
    /// <param name="requestContentType"></param>
    /// <param name="responseContentType"></param>
    /// <param name="responseStatus"></param>
    /// <param name="responseBody"></param>
    /// <param name="responseDateTimeUtc"></param>
    /// <param name="submittedBy"></param>
    /// <returns></returns>
    public async Task<ApiRequestLogEntity> AddApiRequestLogAsync(eAPI apiId,
                                                                DateTime requestDateTimeUtc,
                                                                string requestMethod,
                                                                string requestPath,
                                                                string requestQuery,
                                                                string requestBody,
                                                                string requestScheme,
                                                                string requestHost,
                                                                string requestContentType,
                                                                string responseContentType,
                                                                string responseStatus,
                                                                string responseBody,
                                                                DateTime responseDateTimeUtc)
    {
        Guard.Against.NullOrEmpty(requestMethod, nameof(requestMethod));
        Guard.Against.NullOrEmpty(requestPath, nameof(requestPath));
        Guard.Against.NullOrEmpty(requestScheme, nameof(requestScheme));
        Guard.Against.NullOrEmpty(requestHost, nameof(requestHost));
        Guard.Against.NullOrEmpty(responseStatus, nameof(responseStatus));

        var apiRequestLog = new ApiRequestLogEntity
        {
            ApiId = (int)apiId,
            RequestDateTimeUtc = requestDateTimeUtc,
            RequestMethod = requestMethod,
            RequestPath = requestPath,
            RequestScheme = requestScheme,
            RequestBody = string.IsNullOrEmpty(requestBody) ? null : requestBody,
            RequestQuery = string.IsNullOrEmpty(requestQuery) ? null : requestQuery,
            RequestContentType = requestContentType,
            RequestHost = requestHost,
            ResponseBody = responseBody,
            ResponseDateTimeUtc = responseDateTimeUtc,
            ResponseContentType = responseContentType,
            ResponseStatus = responseStatus
        };

        _context.ApiRequestLogs.Add(apiRequestLog);

        await _context.SaveChangesAsync(new CancellationToken());

        return apiRequestLog;
    }
}
