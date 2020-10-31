using GraphQL;
using GraphQL.Types;
using System.Diagnostics;

namespace VSSUMMIT.Demo00
{
    public class ExampleMutation : ObjectGraphType<object>
    {
        public ExampleMutation(UserRepository userRepo)
        {
            Name = "Mutation";
            Description = "Use this mutation to add, update or delete the Users, Posts or Followers.";

            Field<UserType>(
              "createUser",
              arguments: new QueryArguments(
                new QueryArgument<NonNullGraphType<UserInputType>> { Name = "user" }
              ),
              resolve: ctx =>
              {
                  var user = ctx.GetArgument<User>("user");
                  return userRepo.AddUser(user);
              });

            Field<UserType>(
                "updateUser",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<UserInputType>> { Name = "user" },
                    new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "userId" }),
                resolve: ctx =>
                {
                    var user = ctx.GetArgument<User>("user");
                    var userId = ctx.GetArgument<int>("userId");
                    var lastStateUser = userRepo.GetUserById(userId);
                    if (lastStateUser == null)
                    {
                        ctx.Errors.Add(new ExecutionError("Couldn't find last state of user."));
                        return null;
                    }
                    return userRepo.UpdateUser(lastStateUser, user);
                }
            );

            Field<UserType>(
                "deleteUser",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "userId" }),
                resolve: ctx =>
                {
                    var userId = ctx.GetArgument<int>("userId");
                    return userRepo.DeleteUser(userId);
                }
            );
        }
    }
}