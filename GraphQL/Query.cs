using System.Linq;
using CommanderGQL.Data;
using CommanderGQL.Models;
using HotChocolate;
using HotChocolate.Data;

namespace CommanderGQL.GraphQL
{
    public class Query
    {
        [UseDbContext(typeof(ApplicationDbContext))]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Platform> GetPlatform([ScopedService] ApplicationDbContext context)
        {
            return context.Platforms;
        }

        [UseFiltering]
        [UseSorting]
        [UseDbContext(typeof(ApplicationDbContext))]
        public IQueryable<Command> GetCommand([ScopedService] ApplicationDbContext context)
        {
            return context.Commands;
        }
    }
}