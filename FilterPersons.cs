namespace lab11;

public class FilterPersons
{
    public Person[] SearchByName(Person[] persons, string search)
    {
        return persons
            .Where(p => p.Name.ToLower().StartsWith(search.ToLower()))
            .ToArray();
    }

    public Person[] SearchByAge(Person[] persons, int age)
    {
        return persons.Where(p => p.Age == age).ToArray();
    }

    public Person[] SearchByGender(Person[] persons, int gender)
    {
        return persons.Where(p => p.Gender == gender).ToArray();
    }

    public int GetMaxAge(Person[] persons)
    {
        return persons.Max(p => p.Age);
    }
    
    public int GetMinAge(Person[] persons)
    {
        return persons.Min(p => p.Age);
    }
    
    public double GetAverageAge(Person[] persons)
    {
        return persons.Sum(p => p.Age) / (double)persons.Length;
    }

    public Dictionary<int, IEnumerable<Person>> GetGenderGroupsByName(Person[] persons, string search, int age)
    {
        var result = persons
            .Where(p => p.Name.ToLower().StartsWith(search.ToLower())
                        && p.Age == age)
            .GroupBy(p => p.Gender)
            .ToDictionary(k => k.Key, v => v.Select(s => s));

        return result;
    }
}