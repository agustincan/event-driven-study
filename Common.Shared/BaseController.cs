using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Common.Shared
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class BaseController<T>: ControllerBase
    {
        protected readonly ILogger<T> _logger;

        public BaseController(ILogger<T> logger)
        {
            this._logger = logger;
        }
        protected ActionResult ErrorResponse(Exception ex, string safeErrorMessage)
        {
            _logger.LogError(ex, safeErrorMessage);

            return StatusCode(StatusCodes.Status500InternalServerError, new BaseResponse
            {
                Message = safeErrorMessage
            });
        }
    }
}
