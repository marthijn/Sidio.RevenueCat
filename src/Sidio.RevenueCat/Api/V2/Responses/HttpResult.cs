using System.Diagnostics.CodeAnalysis;
using System.Net;
using RestSharp;
using Sidio.RevenueCat.Api.Common;

namespace Sidio.RevenueCat.Api.V2.Responses;

public sealed class HttpResult<T>
    where T : ObjectResponse
{
    public HttpResult(RestResponse<T> response)
    {
        Data = response.Data;
        Headers = new HeaderResponse(
            response.Headers?.FirstOrDefault(x => x.Name == "RevenueCat-Rate-Limit-Current-Usage"),
            response.Headers?.FirstOrDefault(x => x.Name == "RevenueCat-Rate-Limit-Current-Limit"));
        StatusCode = response.StatusCode;
    }

    public T? Data { get; set; }

    public HeaderResponse? Headers { get; set; }

    public HttpStatusCode StatusCode { get; set; }

    [MemberNotNullWhen(true, nameof(Data))]
    public bool IsSuccess => StatusCode == HttpStatusCode.OK;
}