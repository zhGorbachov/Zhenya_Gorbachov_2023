using MythAndLegend.Data;
using MythAndLegend.Data.Entities;
using MythAndLegend.Services.Interfaces;

namespace MythAndLegend.Services;

public class MythService : StoryService, IMythService
{
    public void AddMyth(Myth myth)
    {
        if (string.IsNullOrEmpty(myth.StoryCode))
        {
            myth.StoryCode = CreateCode(myth.Name);
        }

        Storage.Myths.Add(myth);
    }

    public Story? GetMythByCode(string code)
    {
        return Storage.Myths.FirstOrDefault(x => x.StoryCode.Equals(code));
    }
}