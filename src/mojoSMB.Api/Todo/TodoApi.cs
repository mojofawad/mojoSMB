using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace mojoSMB.Api;

internal static class TodoApi
{
    public static RouteGroupBuilder MapTodos(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/todos");
        
        group.MapGet("/", async (ApiDbContext db) => await db.Todos.ToListAsync());
        
        group.MapGet("/{id}", async (ApiDbContext db, int id) => await db.Todos.FindAsync(id));
        
        group.MapPost("/", async (ApiDbContext db, Todo todo) =>
        {
            db.Todos.Add(todo);
            await db.SaveChangesAsync();
            return Results.Created($"/todos/{todo.Id}", todo);
        });
        
        group.MapPut("/{id}", async (ApiDbContext db, int id, Todo todo) =>
        {
            if (id != todo.Id)
            {
                return Results.BadRequest("Id mismatch");
            }
            
            db.Todos.Update(todo);
            await db.SaveChangesAsync();
            return Results.NoContent();
        });
        
        group.MapDelete("/{id}", async (ApiDbContext db, int id) =>
        {
            var todo = await db.Todos.FindAsync(id);
            if (todo is null)
            {
                return Results.NotFound();
            }
            
            db.Todos.Remove(todo);
            await db.SaveChangesAsync();
            return Results.NoContent();
        });

        return group;
    }
}