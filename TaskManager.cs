using System.Text;

namespace lab11;

public class TaskManager
{
    public async Task Generate(Part[] parts, int threadNumber)
    {
        if (parts != null && threadNumber > 0)
        {
            int chunkSize = parts.Length / threadNumber;
            Task[] tasks = new Task[threadNumber];
            for (int i = 0; i < threadNumber; i++)
            {
                var startIndex = i * chunkSize;
                var endIndex = (i == threadNumber-1) ? parts.Length : (i + 1) * chunkSize;

                tasks[i] = GenerateParts(parts, startIndex, endIndex);
            }
            await Task.WhenAll(tasks);
        }
        else
        {
            throw new ArgumentNullException("Element can not be null");
        }
    }


    private Task GenerateParts(Part[] parts, int startIndex, int endIndex)
    {
        for (var i = startIndex; i < endIndex; i++)
        {
            parts[i] = new Part()
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
        int length = Random.Shared.Next(2,12);
        StringBuilder builder = new StringBuilder();
        for (int i = 0; i < length; i++)
        {
            int temp = Random.Shared.Next(0, 2);
            builder.Append((char)(temp == 0 ? (Random.Shared.Next(48, 58)) : (Random.Shared.Next(97, 123))));
        }
        builder[0] = char.ToUpper(builder[0]);
        return builder.ToString();
    }
}