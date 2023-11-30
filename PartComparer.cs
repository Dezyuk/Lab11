namespace lab11;

public class PartComparer : IComparer<Part>
{
    private string _propertyToSort;

    public PartComparer(string propertyToSort)
    {
        _propertyToSort = propertyToSort;
    }

    public int Compare(Part x, Part y)
    {
        // Compare by the specified property
        switch (_propertyToSort.ToLower())
        {
            case "id":
                return x.Id.CompareTo(y.Id);
            case "name":
                return string.Compare(x.Name, y.Name, StringComparison.Ordinal);
            case "quantity":
                return x.Quantity.CompareTo(y.Quantity);
            case "price":
                return x.Price.CompareTo(y.Price);
            default:
                throw new ArgumentException("Invalid property name for sorting");
        }
    }
}