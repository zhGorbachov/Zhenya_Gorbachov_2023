using MythAndLegend.Data.Entities;

namespace MythAndLegend.Services.Interfaces;

public interface ILegendService : IStoryService
{
    public void AddLegend(Legend legend);
    public Story? GetLegendByCode(string code);
}