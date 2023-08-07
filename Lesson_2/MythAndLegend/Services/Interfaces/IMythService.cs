using MythAndLegend.Data.Entities;

namespace MythAndLegend.Services.Interfaces;

public interface IMythService : IStoryService
{
    public void AddMyth(Myth myth);

    public Story? GetMythByCode(string code);
}