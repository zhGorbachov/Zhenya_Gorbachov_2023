using MythAndLegend.Data.Entities;

namespace MythAndLegend.Data;

public static class Storage
{
    // represents a database, please don't drop it 
    // but you can change it 
    
    public static List<Story> MythsAndLegends = new List<Story>();

    public static List<Myth> Myths = new List<Myth>();
    public static List<Legend> Legends = new List<Legend>();

    static Storage()
    {
        Myths.Add(new Myth
        {
            StoryCode = "ELF-O",
            Name = "ELFO",
            Fact = "Likes marshmello and ale",
            Content = "There is a true elf in this dark world. Creature full of honor and respect, \n" +
                      "but without bear. Why is he so good, may be because of great decisions."
        });
        
        Myths.Add(new Myth
        {
            StoryCode = "F-20",
            Name = "Some Ficus",
            Fact = "Fridge is the sense of his life",
            Content = "Just a human, or a plant, I don't know"
        });
        
        Myths.Add(new Myth
        {
            StoryCode = "MGL",
            Name = "Some machine gun of love",
            Fact = "Sometimes cleans Garbage in your code", // Harbage is not Garbage
            Content = "The weapon of mass destruction, hits right in the heart"
        });
        
        Legends.Add(new Legend
        {
            StoryCode = "CC#D",
            Name = "Clear .Net Dev exists",
            Object = ".Net developer",
            Content = "Legend tells that there is a true clean .Net developer in the world. \n" +
                      "What a lie, everybody knows .Net dev must be an Angular developer, full stack or tester \n" +
                      "with an ultimate skill to fix printers"
        });
    }
}