using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryFinal
{   //Klass för bok och vilken info som behlver finnas om boken
    internal class Book
    {
        public string Title;
        public string Author;
        public string ISBN;
        public int Avaliable;

        //Konstruktor
        public Book(string title, string author, string isbn, int avaliable)
        {

            Title = title;
            Author = author;
            ISBN = isbn;
            Avaliable = avaliable;

        }
    }
}
