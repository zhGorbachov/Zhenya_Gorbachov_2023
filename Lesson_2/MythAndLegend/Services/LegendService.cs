using MythAndLegend.Data;
using MythAndLegend.Data.Entities;
using MythAndLegend.Services.Interfaces;

namespace MythAndLegend.Services;

public class LegendService : StoryService, ILegendService
{
    public void AddLegend(Legend legend)
    {
        if (string.IsNullOrEmpty(legend.StoryCode))
        {
            legend.StoryCode = CreateCode(legend.Name);
        }
        
        Storage.MythsAndLegends.Add(legend);
    }

    public Story? GetLegendByCode(string code)
    {
        return Storage.MythsAndLegends.FirstOrDefault(x => x.StoryCode.Equals(code));
    }
}