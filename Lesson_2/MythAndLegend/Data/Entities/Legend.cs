namespace MythAndLegend.Data.Entities;

public class Legend : Story
{
    public string Object { get; set; }

    public override void Tell()
    {
        Console.WriteLine($"Legend {StoryCode} - {Name} \n" +
                          $"Legend tells about {Object} \n" +
                          $"{Content}");
        base.Tell();
    }
}