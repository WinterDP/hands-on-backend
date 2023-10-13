using EventsLogger.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EventsLogger.Endpoints
{
    public static class EntryEndpoints
    {
        public static RouteGroupBuilder MapEntries(this IEndpointRouteBuilder routes)
        {
            var group = routes.MapGroup("entry");

            group.MapGet("/", async ([FromServices] InMemEntryRepository repository) =>
            {

                return await repository.GetEntryAsync();
            });
            return group;
        }
    }
}