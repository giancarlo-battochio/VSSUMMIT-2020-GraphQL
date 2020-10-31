using GraphQL.Types;
using System;
using System.Collections.Generic;

namespace VSSUMMIT.Demo00
{
    public class UserType : ObjectGraphType<User>
    {
        public UserType(PostRepository postRepo, FollowerRepository followerRepo, UserRepository userRepo)
        {
            Name = "User";
            Field(x => x.Id, type: typeof(IdGraphType)).Description("User ID");
            Field(x => x.Name, nullable: true, type: typeof(StringGraphType)).Description("User Name");
            Field(x => x.Address, type: typeof(StringGraphType)).Description("User Address");
            Field(x => x.Birthday, type: typeof(DateTimeGraphType)).Description("User BirthDay");
            Field<ListGraphType<PostType>>(
                "posts",
                resolve: ctx =>
                {
                    return postRepo.GetPostByUserId(ctx.Source.Id);
                });
            Field<ListGraphType<FollowersType>>(
                "follower",
                resolve: ctx =>
                {
                    return followerRepo.GetPostByFollowedUserId(ctx.Source.Id);
                });
        }
    }
}
