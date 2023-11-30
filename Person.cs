using System.Collections;

namespace lab11;

public class Person
{
    private int _id;
    private string _name;
    private int _age;
    private int _gender;

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

    public int Age
    {
        get => _age;
        set => _age = value;
    }

    public int Gender
    {
        get => _gender;
        set => _gender = value;
    }
}