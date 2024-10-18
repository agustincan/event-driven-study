using Common.Shared;
using Custom.Mediator.Pattern.Infrastucture;
using Microsoft.AspNetCore.Mvc;
using Post.Read.Api.Domain.Entities;
using Post.Read.Api.Queries;
using Post.Read.Api.Responses;

namespace Post.Read.Api.Controllers
{
    public class PostController : BaseController<PostController>
    {
        private readonly IQueryDispatcher<PostEntity> _queryDispatcher;

        public PostController(ILogger<PostController> logger,
            IQueryDispatcher<PostEntity> queryDispatcher):base(logger)
        {
            this._queryDispatcher = queryDispatcher;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllPostsAsync()
        {
            try
            {
                var posts = await _queryDispatcher.SendAsync(new FindAllPostsQuery());
                return NormalResponse(posts);
            }
            catch (Exception ex)
            {
                const string SAFE_ERROR_MESSAGE = "Error while processing request to retrieve all posts!";
                return ErrorResponse(ex, SAFE_ERROR_MESSAGE);
            }
        }

        [HttpGet("byId/{postId}")]
        public async Task<ActionResult> GetByPostIdAsync(Guid postId)
        {
            try
            {
                var posts = await _queryDispatcher.SendAsync(new FindPostByIdQuery { Id = postId });

                if (posts == null || !posts.Any())
                    return NoContent();

                return Ok(new PostLookupResponse
                {
                    Posts = posts,
                    Message = "Successfully returned post!"
                });
            }
            catch (Exception ex)
            {
                const string SAFE_ERROR_MESSAGE = "Error while processing request to find post by ID!";
                return ErrorResponse(ex, SAFE_ERROR_MESSAGE);
            }
        }


        private ActionResult NormalResponse(List<PostEntity> posts)
        {
            if (posts == null || !posts.Any())
                return NoContent();

            var count = posts.Count;
            return Ok(new PostLookupResponse
            {
                Posts = posts,
                Message = $"Successfully returned {count} post{(count > 1 ? "s" : string.Empty)}!"
            });
        }
    }
}
