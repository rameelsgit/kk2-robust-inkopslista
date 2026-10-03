// Creating my own exception to use for the budget
class BudgetExceededException(string message) : Exception(message);

// Holds the items and takes care of loading and saving them.
class ShoppingList
{
    private List<Item> items = new List<Item>();
    private string path;
    // adding the budget variable 
    private int budget; 

    public int Count
    {
        get { return items.Count;}
    }
    // this is a constructor 
    public ShoppingList(string path, int budget)
    {
        this.path = path;
        // makes sure the list has a bugdet & keeping track of the budget
        this.budget = budget;
    }

    public void Add(Item item)
    {
        // if-statement that checks if Total() method + the new item thats being addeds price
        // is bigger than the budget
        if (Total() + item.Price > budget)
        {
            throw new BudgetExceededException($"Du har sprängt budgeten på {budget} kr :( Du har {budget - Total()} kr kvar"); 
        }
        items.Add(item);
    }
    


    // Removes the item the user sees as number 1, 2, 3 ...
    public void RemoveAt(int number)
    {
        items.RemoveAt(number - 1);
    }

    // Adds up the price of every item on the list.
    public int Total()
    {
        int sum = 0;

        // changed int i = 1 till 0, because it was the reason it countet the total sum wrong
        for (int i = 0; i < items.Count; i++)
        {
            sum += items[i].Price;
        }

        return sum;
    }

    // Looks up an item by its name. Returns null if there is no such item.
    public Item Find(string name)
    {
        foreach (Item item in items)
        {
            // added .ToLower so that upper or lower case doesnt matter
            if (item.Name.ToLower() == name.ToLower())
            {
                return item;
            }
        }

        return null;
    }

    public void Print()
    {
        for (int i = 0; i < items.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {items[i]}");
        }

        Console.WriteLine($"Totalt: {Total()} kr");
    }

    // Writes one item per line, as "price;name".
    public void Save()
    {
        List<string> lines = new List<string>();

        foreach (Item item in items)
        {
            lines.Add($"{item.Price};{item.Name}");
        }

        try
        {
            File.WriteAllText(path, string.Join("\r\n", lines));
            Console.WriteLine("Listan är sparad.");
        }
        // IOException to show a specific exception when its not able to save.
        catch(IOException)
        {
            Console.WriteLine("Listan kunde inte sparas.");
        }
    }

    // Reads the file back into the list.
    public void Load()
    {
        // i have added an if-statement that checks if the file exist.
        // if it doesnt exist it runs the program with an empty list.
        if (!File.Exists(path))
        {
            return; 
        }
        string[] lines = File.ReadAllLines(path);

        foreach (string line in lines)
        {
            string[] parts = line.Split(';');
            items.Add(new Item(parts[1], int.Parse(parts[0])));
        }
    }
}
