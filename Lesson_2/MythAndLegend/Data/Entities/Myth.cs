namespace MythAndLegend.Data.Entities;

public class Myth : Story
{
    public string Fact { get; set; }

    public override void Tell()
    {
        Console.WriteLine($"Myth {StoryCode} - {Name} \n" +
                          $"{Content} \n" +
                          $"Fact: {Fact}");
        base.Tell();
    }
}