// One item on the shopping list.
class Item
{
    // variable name and price have the properties get and set.
    // get allows us to read and set allows us to change the variables
    public string Name { get; set; }
    public int Price { get; set; }

    public Item(string name, int price)
    {
        Name = name;
        Price = price;
        if (name == null || name == "")
        {
            // if the name is empty this agrument exception is thrown
            throw new ArgumentException("Namnet kan inte vara tomt");
        }

        if (price < 0)
        {
            // if the price is negative this exception is thrown
            throw new ArgumentOutOfRangeException("Priset får inte vara negativt");
        }
    }

    public override string ToString()
    {
        return $"{Name} - {Price} kr";
    }
}
