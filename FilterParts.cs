namespace lab11;

public class FilterParts
{
    public Part[] SearchByName(Part[] parts, string search)
    {
        return parts
            .Where(p => p.Name.ToLower().StartsWith(search.ToLower()))
            .ToArray();
    }

    public Part[] SearchByQuantity(Part[] parts, int quantity)
    {
        return parts.Where(p => p.Quantity == quantity).ToArray();
    }

    public Part[] SearchByPrice(Part[] parts, int price)
    {
        return parts.Where(p => p.Price == price).ToArray();
    }

    public int GetMaxQuantity(Part[] parts)
    {
        return parts.Max(p => p.Quantity);
    }

    public int GetMinQuantity(Part[] parts)
    {
        return parts.Min(p => p.Quantity);
    }

    public double GetAveragePrice(Part[] parts)
    {
        return parts.Sum(p => p.Price) / (double)parts.Length;
    }

    public Dictionary<int, IEnumerable<Part>> GetQuantityGroupsByName(Part[] parts, string search, int quantity)
    {
        var result = parts
            .Where(p => p.Name.ToLower().Contains(search.ToLower())
                        && p.Quantity == quantity)
            .GroupBy(p => p.Id)
            .ToDictionary(k => k.Key, v => v.Select(s => s));

        return result;
    }
}