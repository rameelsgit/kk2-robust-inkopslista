ShoppingList list = new ShoppingList("items.txt");
list.Load();

while (true)
{
    // a menu that gives the user choices 
    Console.WriteLine();
    list.Print();
    Console.WriteLine();
    Console.WriteLine("1. Lägg till vara");
    Console.WriteLine("2. Ta bort vara");
    Console.WriteLine("3. Spara");
    Console.WriteLine("4. Sök vara");
    Console.WriteLine("5. Avsluta");
    Console.Write("Välj: ");

// the choice should be recived as a string. int choice is the number the user chooses to type 
    int choice = int.Parse(Console.ReadLine());

// what the differents choices lead to
    if (choice == 1)
    {
        Console.Write("Namn: ");
        string name = Console.ReadLine();
        Console.Write("Pris: ");
        int price = int.Parse(Console.ReadLine());
        list.Add(new Item(name, price)); // adds the name and price to the list
    }
    else if (choice == 2)
    {
        Console.Write("Nummer: ");
        int number = int.Parse(Console.ReadLine());
        list.RemoveAt(number);
    }
    else if (choice == 3)
    {
        list.Save();
    }
    else if (choice == 4)
    {
        Console.Write("Namn att söka efter: ");
        string wanted = Console.ReadLine();
        Item found = list.Find(wanted);

        if (found == null)
        {
            Console.WriteLine("Varan finns inte i listan.");
        }
        else
        {
            Console.WriteLine($"Hittade: {found}");
        }
    }
    else if (choice == 5)
    {
        break;
    }
}
