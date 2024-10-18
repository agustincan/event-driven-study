using Common.Shared;
using Custom.Mediator.Pattern.Infrastucture;
using Microsoft.AspNetCore.Mvc;
using Post.Write.Api.Commands;
using Post.Write.Api.Responses;

namespace Post.Write.Api.Controllers
{
    public class CommentController: BaseController<CommentController>
    {
        private readonly ILogger<CommentController> _logger;
        private readonly ICommandDispatcher _commandDispatcher;

        public CommentController(
            ILogger<CommentController> logger,
            ICommandDispatcher commandDispatcher):base(logger)
        {
            this._logger = logger;
            this._commandDispatcher = commandDispatcher;
        }

        [HttpPost]
        public async Task<ActionResult> NewPostAsync(NewPostCommand command)
        {
            var id = Guid.NewGuid();
            command.Id = id;
            try
            {
                await _commandDispatcher.SendAsync(command);

                var response = new NewPostResponse
                {
                    Message = "New post creation request completed successfully!",
                    Id = id
                };

                return CreatedAtAction(nameof(NewPostAsync), response);
            }
            catch (InvalidOperationException ex)
            {
                _logger.Log(LogLevel.Warning, ex, "Client made a bad request.");

                return BadRequest(new BaseResponse
                {
                    Message = ex.Message
                });
            }
            catch (Exception ex)
            {
                const string SAFE_ERROR_MESSAGE = $"Error while processing request to create a new post!.";
                _logger.Log(LogLevel.Error, ex, SAFE_ERROR_MESSAGE);

                return StatusCode(StatusCodes.Status500InternalServerError, new NewPostResponse
                {
                    Message = SAFE_ERROR_MESSAGE,
                    Id = id
                });
            }
        }
    }
}
