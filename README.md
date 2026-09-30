# Fel rapport

1. FELET: I ShoppingList.cs, System.IndexOutOfRangeException
   Programmet craschar när man kör dotnet run (load() metoden), eftersom .split(\n) hämtade med en tom sträng med "File.ReadAllText" så textfilen sparades alltid med en tom rad men det fanns inget pris och namn vilket gör att den kraschade.
   HUR JAG LÖSTE: Jag löste detta genom att använda "File.ReadAllLines" vilket delar upp raderna automatiskt och kan hoppa över tomma rader. Jag tog bort FileReadAllText() och Spit(\n).

2. FELET: Unhandled exception. System.FormatException
   Programmet kraschar när man skiver in en bokstav i meny valet.
   HUR JAG LÖSTE: Jag bytte till int.TryParse eftersom den testar om det är ett heltal utan att krascha.
   Jag lade till den i en while-loop vilket även testar om det är en siffra i menyn, alltså inte lägre än 1 och inte större än 5.

3. 
