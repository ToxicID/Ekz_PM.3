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
        public Book[] books;
        public void addBooks(string genre,string author,string name, int index)
        {
            books[index] = new Book(genre, author, name);
        }
        public List<Book> sort(List<Book> book)
        {
            var sortList = from newList in book
                           orderby newList.genre, newList.author, newList.name
                           select newList;
            return (List<Book>)sortList;
        }
        public BookControl(int num)
        {
            books = new Book[num];
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
            
            int num;
            while (true)
            {
                Console.Write("Введите количество добавляемых книг:");

                if (!(int.TryParse(Console.ReadLine(), out num)))
                {
                    Console.WriteLine("Введено не число");
                    continue;
                }
                else if(num <= 0)
                {
                    Console.WriteLine("Количество не может быть отрицательным или равным нулю");
                    continue;
                }

                else
                    break;
            }
            string genre;
            string author;
            string name;
            BookControl bc = new BookControl(num);
            for (int i = 0; i < num; i++)
            {
                Console.WriteLine($"Заполнение {i+1} книги:");
                Console.Write("\tВведите жанр:");
                genre = Console.ReadLine();
                Console.Write("\tВведите автора:");
                author = Console.ReadLine();
                Console.Write("\tВведите название:");
                name = Console.ReadLine();
                bc.addBooks(genre,author,name,i);
            }
        }
    }
}
