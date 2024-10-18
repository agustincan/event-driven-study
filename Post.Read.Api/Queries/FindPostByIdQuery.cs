using Custom.Mediator.Pattern.Queries;

namespace Post.Read.Api.Queries
{
    internal class FindPostByIdQuery : BaseQuery
    {
        public Guid Id { get; set; }
    }
}