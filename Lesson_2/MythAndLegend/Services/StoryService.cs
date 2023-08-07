using MythAndLegend.Services.Interfaces;

namespace MythAndLegend.Services;

public class StoryService : IStoryService
{
    public string CreateCode(string name)
    {
        var code = $"{name.First()}{name.Last()}-{name.Length}";

        return code;
    }
}