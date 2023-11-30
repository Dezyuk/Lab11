namespace lab11;

public class PersonComparer : IComparer<Person>
{
    private string _propertyToSort;

    public PersonComparer(string propertyToSort)
    {
        _propertyToSort = propertyToSort;
    }

    public int Compare(Person x, Person y)
    {
        // Compare by the specified property
        switch (_propertyToSort.ToLower())
        {
            case "id":
                return x.Id.CompareTo(y.Id);
            case "name":
                return string.Compare(x.Name, y.Name, StringComparison.Ordinal);
            case "age":
                return x.Age.CompareTo(y.Age);
            case "gender":
                return x.Gender.CompareTo(y.Gender);
            default:
                throw new ArgumentException("Invalid property name for sorting");
        }
    }
}