using lab11;
using System.Diagnostics;

internal class Program
{
    private static async Task Main(string[] args)
    {
        Part[] parts = new Part[10000];
        TaskManager taskManager = new TaskManager();
        var taskInfo = taskManager.Generate(parts, 8);
        await taskInfo;
        FilterParts filter = new FilterParts();
        var result = filter.GetQuantityGroupsByName(parts, "6", 4);
    }
}