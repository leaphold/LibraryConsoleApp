using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryFinal
{
    internal class Library
    {
        //Lista för att spara böcker
        List<Book> libraryList = new List<Book>();

        //Skapar tre böcker att utgå ifrån
        public Library()
        {
            libraryList.Add(new Book("Historien om Sverige : från istiden till renässansen", "Kristina Ekero Eriksson, Bo Eriksson", " 2023-10-20", 1));
            libraryList.Add(new Book("Tankar efter en pandemi : och lärdomarna inför nästa", "Anders Tegnell, Fanny Härgestam", "2023-11-03", 2));
            libraryList.Add(new Book("Min barndoms jul", "av Astrid Lindgren, Fredrik Eriksson", " 2023-10-20", 3));
        }

        //Funktion för att spkapa bok samt lägga till den i listan
        public void CreateBook()
        {
            bool result = true;//

            Console.WriteLine("Vad är titlen på den boken du vill lägga till?");
            string title = Console.ReadLine();
            Console.WriteLine("vad är författarens för- och efternamn?");
            string author = Console.ReadLine();
            Console.WriteLine("Vad är bokens ISBN nummer?");
            string isbn = Console.ReadLine();
            Console.WriteLine("Hur många exemplar av boken läggs till?");
            string input = Console.ReadLine();

            result = int.TryParse(input, out int avaliable);//TryPare ifall att inmatningen av int inte blir korrekt

            if (result == true)
            {
                libraryList.Add(new Book(title, author, isbn, avaliable));
                Console.WriteLine($"{avaliable}st av boken {title}, ISBN {isbn}, av {author} lades till i ditt bibliotek");
            }
            else
            {
                Console.WriteLine("Ogiltlig inmatning, försök igen");
            }
        }

        //Funktion för att skriva ut böcker som finns sparade i biblioteket samt all info om dem
        public void PrintCollection()
        {
            Console.WriteLine("-----------Följande böcker finns i ditt bibliotek-----------\n\n");

            foreach (Book book in libraryList)
            {
                Console.WriteLine($"Titel: {book.Title}");
                Console.WriteLine($"Författare: {book.Author}");
                Console.WriteLine($"ISBN: {book.ISBN}");
                Console.WriteLine($"Tillgänglig för utlåning {book.Avaliable}\n\n");
            }
        }


        //funktion för att skriva ut bara titel och författare samt tilldela dem ett nummer för att senare kunna välja bland dem
        public void PrintTitle()
        {
            int count = 0;
            foreach (Book avaliable in libraryList)
            {
                Console.WriteLine($"{count}.{avaliable.Title} av {avaliable.Author}\n");
                count++;
            }

        }

        //Funktion för att ta bort böcker från listan. Ett ex åt gången och helt om inga ex återstår.
        public void indexToDelete()
        {
            bool result = true;
            int choice = 0;

            //Ber användaren välja bok efter korresponderande nummer.
            Console.WriteLine("Välj bok som du önskar ta bort:\n");
            PrintTitle();

            string input = Console.ReadLine();
            result = int.TryParse(input, out choice);//TryParse ifall fel inmatning eller val görs

            int itemsInList = libraryList.Count;

            if (itemsInList > choice)//om ett giltigt nummer skrivs in
            {
                Book selectedBook = libraryList[choice];

                if (result == true)
                {


                    if (selectedBook.Avaliable > 0)//så länge det finns exemplar av boken
                    {
                        selectedBook.Avaliable--;
                        Console.WriteLine($"\n Du har tagit bort ett exemplar av: {selectedBook.Title} av {selectedBook.Author}\n");

                        if (selectedBook.Avaliable == 0)// om inga exemplar finns kvar tas boken bort från listan helt
                        {
                            libraryList.RemoveAt(choice);
                        }

                        Console.WriteLine("----------------------------------------\n");
                        Console.WriteLine("Följande böcker finns nu kvar:");
                        PrintTitle();
                        Console.WriteLine("----------------------------------------\n");
                    }

                    else if (selectedBook.Avaliable == 0)//om inga exemplar finns kvar tas boken bort från listan helt
                    {


                        libraryList.RemoveAt(choice);
                        Console.WriteLine($"Du har tagit bort:{selectedBook.Title} från ditt bibliotek, inga exemplar återstår");

                        choice = 0;

                    }

                }
                else// om ogiltig inmatning
                {
                    Console.WriteLine("Ogitligt val, försök igen\n");

                }

            }
            else// om ogiltig inmatning
            {
                Console.WriteLine("Ogiltligt val, eller felaktig inmatning, försök igen!\n");
            }
        }

    }
}
