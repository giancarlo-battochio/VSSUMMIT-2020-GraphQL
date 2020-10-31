using GraphQL.Types;

namespace VSSUMMIT.Demo00
{
    public class UserInputType : InputObjectGraphType
    {
        public UserInputType()
        {
            Name = "UserInput";
            Field<NonNullGraphType<StringGraphType>>("name");
            Field<StringGraphType>("address");
            Field<DateTimeGraphType>("birthday");
        }
    }
}
