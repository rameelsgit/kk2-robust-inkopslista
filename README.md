# Fel rapport

1. FELET:
   I ShoppingList.cs, System.IndexOutOfRangeException
   Programmet craschar när man kör dotnet run (load() metoden), eftersom .split(\n) hämtade med en tom sträng med "File.ReadAllText" så textfilen sparades alltid med en tom rad men det fanns inget pris och namn vilket gör att den kraschade.
   HUR JAG LÖSTE:
   Jag löste detta genom att använda "File.ReadAllLines" vilket delar upp raderna automatiskt och kan hoppa över tomma rader. Jag tog bort FileReadAllText() och Spit(\n).

2. FELET:
   Unhandled exception. System.FormatException
   Programmet kraschar när man skiver in en bokstav i meny valet.
   HUR JAG LÖSTE:
   Jag bytte till int.TryParse eftersom den testar om det är ett heltal utan att krascha.
   Jag lade till den i en while-loop vilket även testar om det är en siffra i menyn, alltså inte lägre än 1 och inte större än 5.

3. FELET:
   Unhandled exception. System.FormatException (felet var i Program.cs)
   Felet är samma som i meny valet när man kunde skriva in en bokstav där den förväntade en siffra.
   Programmet kraschade nu när jag skrev in bokstäver där priset skulle inmatas på "Lägg till vara"
   HUR JAG LÖSTE:
   bytte int.Parse till int.Try.Parse i en while-loop för att testa för ett heltal utan krasch
   och såg till att priset måste vara ett positivt tal.

4. FELET:
   System.FormatException (felet var i Program.cs)
   Problemet var att man kunde skriva in bokstäver när man ville att en vara skulle tas bort.
   Man kunde även ange en siffra som inte fanns i listan av varor.
   HUR JAG LÖSTE:
   Först gjorde jag samma ändring som tidigare där jag ändrade till en try.Parse i en while-loop som kan checka ett heltal utan att krasha. Andra steget var att lägga till en Count egenskap i ShoppingList.cs den kan läsa hur många varor det finns i listan. I while-loopen lade jag till vilkoren att siffran är minst 1 och att siffran måste finnas i Items listan.

5. FELET: Programmet skrev ut fel totalsumma.
   Anledningen var att index började på 1 istället för 0, alltså räknades inte vara nr 1 med. Den började räkna från vara 2.
   HUR JAG LÖSTE:
   Jag skrev om int i = 1 till int i = 0 i for-loopen.

6. FELET: Sökvaran dök ej upp
   Sökvaran hittades inte om första bokstaven ej var uppercase.
   HUR JAG LÖSTE:
   Jag löste detta genom att lägga till .ToLower på if-satsen så att det inte spelar någon roll hur användaren skriver in det.

7. FELET: Unhandled exception. System.IO.FileNotFoundException
   När jag bytte namn på filen kraschade programmet eftersom kommandot "file.ReadAllLines" läser med item.txt och när den inte fanns gick det inte att köra.
   HUR JAG LÖSTE:
   Jag lade till en if-sats i load() metoden som kollar om filen existerar eller ej, finns den inte så avbryter den med "return;". Istället kör den programmet med en tom lista.
