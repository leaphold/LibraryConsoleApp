namespace LibraryFinal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Meddelande Välkommen samt choice=0 programRunning=true
            Console.WriteLine(" ,_,\r\n[0,0] \r\n|)__) \r\n-”-”-\nVälkommen till Biblioteket! \n\nVälj tjänst i menyn nedan genom att skriva in nummret till det alternativet:\n");
            bool programRunning = true;
            Library library = new Library();
            string input = "0";
            int choice = 0;
            bool result = true;

            //Sålänge programrunning är true kommer vi befinna os inom while loopen dvs programmet körs.
            while (programRunning)
            {
                if (result)// Sålänge valet som användaren gör är ett av alternativen
                {
                    switch (choice) //Menyn och de olika valen
                    {
                        case 0://Startmenyn - går automatiskt in hör då choice är 0

                            Console.WriteLine("1.Lägg till en bok till biblioteket\n" +
                            "2.Ta bort bok från biblioteket\n" +
                            "3.Visa tillgängliga böcker\n" +
                            "4.Avsluta programmet\n");

                            input = Console.ReadLine();
                            result = int.TryParse(input, out choice);

                        break;

                        case 1://val 1 Skapa bok - kör funktionen CreateBook

                            library.CreateBook();
                            choice = 0;//Går tillbaka till startmenyn

                        break;

                        case 2://Kör funktion för att välja vilken bok som ska tas bort samt tar bort den

                            library.indexToDelete();
                            choice = 0;

                        break;

                        case 3:// skriver ut tillgängliga böcker samt all info om dem

                            library.PrintCollection();
                            choice = 0;

                        break;

                        case 4://Avslutar program och ugglan säger hejdå

                            Console.WriteLine("Avslutar program...\n\n\n" +
                            "                                         ,_,\r\n" +
                            "                                        [0,0] - Hej då, välkommen åter! \r\n" +
                            "                                        |)__) \r\n" +
                            "                                        -”-”-\n\n\n");
                            programRunning = false;

                        break;

                        default://Om fel val matas in - finns redan i if satsen men denna ifall ifall.

                            Console.WriteLine("Ogilttligt alternatv, var vänlig försök igen");
                            choice = 0;

                        break;
                    }
                }
                else //Om fel val eller inget matas in.
                {
                    Console.WriteLine($"Ogiltligt val, försök igen och välj en siffra mellan 1-4\n");
                    result = true;
                }
            }
        }
    }
}