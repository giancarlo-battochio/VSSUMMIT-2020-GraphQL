using GraphQL;
using GraphQL.Types;
using VSSUMMIT.Demo00.ExternalAPI;

namespace VSSUMMIT.Demo00
{
    public class ExampleQuery : ObjectGraphType<object>
    {
        public ExampleQuery(UserRepository userRepo, PostRepository postRepo, FollowerRepository followerRepo, GitHubApi gitHubApi)
        {
            Name = "Query";
            Description = "Simple query example, exposes (user, post and follower)";

            Field<ListGraphType<UserType>>(
                "users",
                arguments: new QueryArguments(
                    new QueryArgument<IntGraphType> { Name = "offset" },
                    new QueryArgument<IntGraphType> { Name = "limit", DefaultValue = 10}
                ),
                resolve: ctx =>
                {
                    var offset = ctx.GetArgument<int>("offset");
                    var limit = ctx.GetArgument<int>("limit");

                    //if (limit == 0)
                    //{
                    //    ctx.Errors.Add(new ExecutionError("The argument [limit] must be greater than 0."));
                    //    return null;
                    //}
                    //if (limit == 0)
                    //    limit = 10;

                    return userRepo.GetAllUsers(offset, limit);
                }
            );

            Field<UserType>(
                "userById",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id" }
                ),
                resolve: ctx =>
                {
                    var id = ctx.GetArgument<int>("id");
                    return userRepo.GetUserById(id);
                }
            );

            Field<ListGraphType<PostType>>(
                "posts",
                resolve: ctx => postRepo.GetAll()
            );

            Field<ListGraphType<FollowersType>>(
                "followers",
                resolve: ctx => followerRepo.GetAll()
            );

            //Field<ListGraphType<GitHubBranchType>>(
            //    "branches",
            //    resolve: ctx => gitHubApi.GetBranches()
            //);
        }
    }
}
