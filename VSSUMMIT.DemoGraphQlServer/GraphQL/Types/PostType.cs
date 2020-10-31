using GraphQL.Types;

namespace VSSUMMIT.Demo00
{
    public class PostType : ObjectGraphType<Post>
    {
        public PostType()
        {
            Name = "Posts";
            Field(x => x.Id, type: typeof(IdGraphType)).Description("Post ID");
            Field(x => x.Title, nullable: true).Description("Post title");
            Field(x => x.Content, type: typeof(StringGraphType)).Description("Post content");
        }
    }
}
