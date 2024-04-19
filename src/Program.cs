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
        public Book[] sort(Book[] book)
        {
            var sortList = from newList in book
                           orderby newList.genre descending, newList.author descending, newList.name descending
                           select newList;
            return sortList.ToArray();
        }
        public BookControl(int num)
        {
            books = new Book[num];
        }
        public void saveInFile(Book[] book)
        {
            using (StreamWriter writer = new StreamWriter("test.txt", false, System.Text.Encoding.UTF8))
            {
                for (int i = 0; i < book.Length; i++)
                {
                    writer.WriteLine(book[i].genre + ";" + book[i].author + ";" + book[i].name);
                }

            }
        }
        public void printMass()
        {
         
                Console.WriteLine("{0,5}{1,10}{2,30}{3,30}", "№","Жанр", "Автор", "Название");
                Console.WriteLine("_______________________________________________________________________________");
            int a = 1;
                foreach (var b in books)
                {
                    Console.WriteLine("{0,5}{1,10}{2,30}{3,30}", a,b.genre, b.author, b.name);
                a++;
                }
                Console.WriteLine("-------------------------------------------------------------------------------");
            
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
            Console.WriteLine("\nОтсортированный массив:");
            bc.books = bc.sort(bc.books);
            bc.printMass();
            bc.saveInFile(bc.books);
            Console.WriteLine("Данные сохранены в файл:\"test.txt\"");
            Console.ReadKey();
        }
    }
}
