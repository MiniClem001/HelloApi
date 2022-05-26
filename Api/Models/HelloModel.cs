namespace Api.Models;

public class HelloModel
{
    public DateTime At { get; init; } = DateTime.Now;

    public string Name { get; init; } = "World";

    public string Greetings => $"Hello {Name}";
}
