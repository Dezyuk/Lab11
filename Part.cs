namespace lab11;

public class Part
{
    private int _id;
    private string _name;
    private int _quantity;
    private int _price;

    public int Id
    {
        get => _id;
        init => _id = value;
    }

    public string Name
    {
        get => _name;
        set => _name = value ?? throw new ArgumentNullException(nameof(value));
    }

    public int Quantity
    {
        get => _quantity;
        set => _quantity = value;
    }

    public int Price
    {
        get => _price;
        set => _price = value;
    }
}