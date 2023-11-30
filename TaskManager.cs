using System.Text;

namespace lab11;

public class TaskManager
{
    public async Task Generate(Part[] persons, int threadNumber)
    {
        if (persons != null && threadNumber > 0)
        {
            int chunkSize = persons.Length / threadNumber;
            Task[] tasks = new Task[threadNumber];
            for (int i = 0; i < threadNumber; i++)
            {
                var startIndex = i * chunkSize;
                var endIndex = (i == threadNumber-1) ? persons.Length : (i + 1) * chunkSize;

                tasks[i] = GeneratePersons(persons, startIndex, endIndex);
            }
            await Task.WhenAll(tasks);
        }
        else
        {
            throw new ArgumentNullException("Element can not be null");
        }
    }

    private Task GeneratePersons(Part[] persons, int startIndex, int endIndex)
    {
        for (var i = startIndex; i < endIndex; i++)
        {
            persons[i] = new Part()
            {
                Id = i,
                Name = GenerateName(),
                Quantity = Random.Shared.Next(1,20),
                Price = Random.Shared.Next(1,50)*100
            };
        }
        
        return Task.CompletedTask;
    }

    private string GenerateName()
    {
        int length = Random.Shared.Next(5, 8);
        StringBuilder builder = new StringBuilder();
        for (int i = 0; i < length; i++)
        {
            builder.Append((char)Random.Shared.Next(97, 123));
        }

        builder[0] = char.ToUpper(builder[0]);
        return builder.ToString();
    }
}