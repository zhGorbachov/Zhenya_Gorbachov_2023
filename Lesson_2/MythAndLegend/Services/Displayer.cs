using MythAndLegend.Data;
using MythAndLegend.Data.Entities;
using MythAndLegend.Services.Interfaces;

namespace MythAndLegend.Services;

public class Display : IDisplay
{
    private readonly ILegendService _legendService;
    private readonly IMythService _mythService;
    
    public Display()
    {
        _legendService = new LegendService();
        _mythService = new MythService();
    }

    public void DisplayByCode(string code)
    {
        var legend = _legendService.GetLegendByCode(code);
        var myth = _mythService.GetMythByCode(code);

        if (legend is not null)
        {
            legend.Tell();
        }
        else if (myth is not null)
        {
            myth.Tell();
        }
        else
        {
            Console.WriteLine($"No myth or legend with code {code}");
        }
    }

    public void AddNewStory()
    {
        Console.WriteLine("Enter story type (myth/legend)");
        var input = Console.ReadLine();
        
        if (input == "legend")
        {
            Console.WriteLine("Enter name of the legend");
            var name = Console.ReadLine();
            Console.WriteLine("Enter object of the legend");
            var storyObject = Console.ReadLine();
            Console.WriteLine("Enter the story");
            var storyText = Console.ReadLine();

            var story = new Legend()
            {
                Name = name,
                Object = storyObject,
                Content = storyText
            };
            
            Storage.Legends.Add(story);
        }
        else if (input == "myth")
        {
            Console.WriteLine("Enter name of the myth");
            var name = Console.ReadLine();
            Console.WriteLine("Enter the story");
            var storyText = Console.ReadLine();
            Console.WriteLine("Enter some fact");
            var fact = Console.ReadLine();

            var story = new Myth()
            {
                Name = name,
                Fact = fact,
                Content = storyText
            };
            
            Storage.Myths.Add(story);
        }
        else
        {
            Console.WriteLine("Oops, wrong input");
        }
    }
}