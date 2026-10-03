using System.Linq.Expressions;
using System.Runtime.CompilerServices;

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

// the value stores in choice variable 
    int choice;
// changed to a tryParse & loop until the user has entered a valid option from menu/not a letter
    while (!int.TryParse(Console.ReadLine(), out choice) || choice > 5 || choice< 1)
{
    Console.Write("Ange ett heltal eller en siffra från menyn: ");
}

// what the differents choices lead to
    if (choice == 1)
    {
        Console.Write("Namn: ");
        string name = Console.ReadLine();
        // program will only continue when Name is no longer empty
        while(name == null || name == "")
        {
            // lets user know that name cant be empty and gives another chance
            Console.WriteLine("Namnet kan inte vara tomt");
            Console.Write("Namn: ");
            name = Console.ReadLine();
        }

        Console.Write("Pris: ");
        // changed int.parse to try.parse like previously to check for int without crasching
        // & made sure user cant input a negative int 
        int price;
        while (!int.TryParse(Console.ReadLine(), out price)|| price < 0 )
        {
        Console.Write("Skriv priset med siffror eller ett positivt tal: ");
        }        

        try
        {
            list.Add(new Item(name, price)); // adds the name and price to the list            
        }
        // catch for negative price
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine($"Fel: {ex.Message}");
        }
        // catch for empty name
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Fel: {ex.Message}");
        }
    }
    else if (choice == 2)
    {
        Console.Write("Nummer: ");
        int number;
        // while loop makes sure you can only input a number, thats atleast 1 and it has to in the list.
        while (!int.TryParse(Console.ReadLine(), out number) || number > list.Count || number < 1)
        {
        Console.Write("Skriv talet med siffror eller ett tal i listan: ");
        }  
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
