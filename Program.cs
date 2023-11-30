using lab11;
using System.Diagnostics;

internal class Program
{
    private static async Task Main(string[] args)
    {
        Person[] persons = new Person[10000];

        TaskManager taskManager = new TaskManager();
        var taskInfo = taskManager.Generate(persons, 8);

        await taskInfo;

        FilterPersons filter = new FilterPersons();

        var result = filter.GetGenderGroupsByName(persons, "a", 15);


    }
}