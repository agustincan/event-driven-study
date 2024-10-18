using Post.Read.Api.Domain.Entities;

namespace Post.Read.Api.Responses
{
    public class PostLookupResponse
    {
        public List<PostEntity> Posts { get; set; }
        public string Message { get; set; }
    }
}