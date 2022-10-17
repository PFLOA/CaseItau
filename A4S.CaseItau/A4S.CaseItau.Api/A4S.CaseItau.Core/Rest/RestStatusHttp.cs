using Microsoft.AspNetCore.Mvc;
using A4S.CaseItau.Core.Enum;

namespace A4S.CaseItau.Core.Rest
{
    public static class RestStatusHttp
    {
        public static IActionResult ReturnStatus(EnumTypeResult status, object result)
        {
            return status switch
            {
                EnumTypeResult.Ok => new OkObjectResult(result),
                EnumTypeResult.Created => new OkObjectResult(result),
                EnumTypeResult.Accepted => new OkObjectResult(result),
                EnumTypeResult.InvalidInput => new BadRequestObjectResult(result),
                EnumTypeResult.NotFound => new NotFoundObjectResult(result),
                EnumTypeResult.Forbidden => new NotFoundObjectResult(result),
                EnumTypeResult.InternalError => new BadRequestObjectResult(result),
                EnumTypeResult.ServiceUnavaliable => new BadRequestObjectResult(result),
                _ => new OkResult(),
            };
        }
    }
}
