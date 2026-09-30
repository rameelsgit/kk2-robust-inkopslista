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
    }

    public override string ToString()
    {
        return $"{Name} - {Price} kr";
    }
}
