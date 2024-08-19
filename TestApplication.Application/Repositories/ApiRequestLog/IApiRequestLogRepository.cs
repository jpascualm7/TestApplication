using TestApplication.Domain.Entities;
using TestApplication.Domain.Enums;

namespace TestApplication.Application.Repositories.ApiRequestLog;

public interface IApiRequestLogRepository
{
    Task<ApiRequestLogEntity> AddApiRequestLogAsync(eAPI apiId,
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
                                                    DateTime responseDateTimeUtc);

    /// <summary>
    /// Get API request log by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<ApiRequestLogEntity?> GetApiRequestLogAsync(int id);
}
