using System.Linq;
using CommanderGQL.Data;
using CommanderGQL.Models;
using HotChocolate;
using HotChocolate.Types;

namespace CommanderGQL.GraphQL.Commands
{
    public class CommandType : ObjectType<Command>
    {
        protected override void Configure(IObjectTypeDescriptor<Command> descriptor)
        {
            descriptor.Description("Represents any executable command");

            descriptor.Field(p => p.Platform)
                      .ResolveWith<Resolvers>(p => p.GetPlatform(default!, default))
                      .UseDbContext<ApplicationDbContext>()
                      .Description("This is the platform to which the command belong");
        }

        private class Resolvers
        {
            public Platform GetPlatform(Command command, [ScopedService] ApplicationDbContext context)
            {
                return context.Platforms.FirstOrDefault(p => p.Id == command.PlatformId);
            }
        }
    }
}