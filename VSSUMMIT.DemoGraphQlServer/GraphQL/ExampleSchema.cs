using GraphQL.Types;
using GraphQL.Utilities;
using System;

namespace VSSUMMIT.Demo00
{
    public class ExampleSchema : Schema
    {
        public ExampleSchema(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            Query = serviceProvider.GetRequiredService<ExampleQuery>();
            Mutation = serviceProvider.GetRequiredService<ExampleMutation>();

            Description = "A simple GraphQL schema...";
        }
    }
}
