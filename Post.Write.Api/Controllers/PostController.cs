using Common.Shared;
using Custom.Mediator.Pattern.Infrastucture;

namespace Post.Write.Api.Controllers
{
    public class PostController: BaseController<PostController>
    {
        private readonly ILogger<PostController> logger;
        private readonly ICommandDispatcher commandDispatcher;

        public PostController(
            ILogger<PostController> logger,
            ICommandDispatcher commandDispatcher):base(logger)
        {
            this.logger = logger;
            this.commandDispatcher = commandDispatcher;
        }
    }
}
