using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    public class Book
    {
        public string  genre { get; set; }
        public string author { get; set; }
        public string name { get; set; }
        public Book(string genre, string author, string name)
        {
            this.genre = genre;
            this.author = author;
            this.name = name;
        }
    }
    public class BookControl
    {
       public List<Book> books = new List<Book>();
        public void addBooks(string genre,string author,string name)
        {
            books.Add(new Book(genre, author, name));
        }
        public List<Book> sort(List<Book> book)
        {
            var sortList = from newList in book
                           orderby newList.genre, newList.author, newList.name
                           select newList;
            return (List<Book>)sortList;
        }
        public void saveInFile(List<Book> book)
        {
            using (StreamWriter writer = new StreamWriter("test.txt", false, System.Text.Encoding.UTF8))
            {
                for (int i = 0; i < book.Count; i++)
                {
                    writer.WriteLine(book[i].genre + ";" + book[i].author + ";" + book[i].name);
                }

            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            
        }
    }
}
