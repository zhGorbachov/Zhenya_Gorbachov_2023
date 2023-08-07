namespace MythAndLegend.Data.Entities;

public abstract class Story
{
    public string StoryCode { get; set; }
    public string Name { get; set; }
    public string Content { get; set; }

    public virtual void Tell()
    {
        Console.WriteLine("------------------------------");
    }
}