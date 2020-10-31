using GraphQL.Types;

namespace VSSUMMIT.Demo00
{
    public class FollowersType : ObjectGraphType<Follower>
    {
        public FollowersType()
        {
            Name = "Followers";
            Field(x => x.Id, type: typeof(IdGraphType)).Description("Follower ID");
            Field(x => x.UserId, type: typeof(IdGraphType)).Description("User Id");
            Field(x => x.FollowUserId, type: typeof(IdGraphType)).Description("Followed user Id");
            Field(x => x.Name, type: typeof(StringGraphType)).Description("");
        }
    }
}
