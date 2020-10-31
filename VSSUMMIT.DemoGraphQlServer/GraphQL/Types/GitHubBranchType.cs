using GraphQL.Types;
using VSSUMMIT.Demo00.ExternalAPI;

namespace VSSUMMIT.Demo00

{
    public class GitHubBranchType : ObjectGraphType<GitHubBranch>
    {
        public GitHubBranchType()
        {
            Name = "GitHubApi";
            Field(x => x.Name).Description("Git Hub branch Name.");
        }
    }
}
