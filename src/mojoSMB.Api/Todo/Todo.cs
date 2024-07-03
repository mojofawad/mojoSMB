using System.ComponentModel.DataAnnotations;

public class Todo
{
    public int Id { get; set; }
    [Required] public string? Title { get; set; } = default!;
    public string? Description { get; set; }
    public DateTime DateAdded { get; set; }
    public DateTime? DueDateTime { get; set; }
    public bool IsDone { get; set; }

    [Required] public string UserId { get; set; } = default;

}

public class TodoItem
{
    public int Id { get; set; }
    [Required] public string? Title { get; set; } = default!;
    public string? Description { get; set; }
    public DateTime DateAdded { get; set; }
    public DateTime? DueDateTime { get; set; }
    public bool IsDone { get; set; }
}

public static class TodoMappingExtensions
{
    public static TodoItem AsTodoItem(this Todo todo)
    {
        return new()
        {
            Id = todo.Id,
            Title = todo.Title,
            Description = todo.Description,
            DateAdded = todo.DateAdded,
            DueDateTime = todo.DueDateTime,
            IsDone = todo.IsDone
        };
    }
}