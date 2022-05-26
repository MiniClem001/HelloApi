using Api.Models;

namespace Api.Services;

public interface IGreetter
{
    List<HelloModel> History { get; }

    HelloModel Greet(string? name);
}

public abstract class Greeter : IGreetter
{
    public List<HelloModel> History => _history;

    protected readonly List<HelloModel> _history = new();

    public abstract HelloModel Greet(string? name);
}


public class HelloService : Greeter
{
    public override HelloModel Greet(string? name)
    {
        var hello = new HelloModel { Name = name ?? "World" };

        _history.Add(hello);

        return hello;
    }
}