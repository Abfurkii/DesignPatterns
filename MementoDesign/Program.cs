using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MementoDesign
{
    class Program
    {
        static void Main(string[] args)
        {
            Book book = new Book { Isbn = "5648654", Name = "Aklından bir sayı tut", Author = "John Verdon" };
            book.ShowBook();

            GetMemento memento = new GetMemento();
            memento.Memento = book.CreateUndo();

            book.Author = "JOHN VERDON";
            book.ShowBook();

            book.RestoreFromUndo(memento.Memento);
            book.ShowBook();

            Console.ReadLine();
        }
    }
    public class Book
    {
        private string _isbn;
        private string _name;
        private string _author;
        private DateTime _dateTime;
        public string Isbn
        {
            get
            {
                return _isbn;
            }
            set
            {
                _isbn = value;
                SetDateTime();
            }
        }
        public string Name { get { return _name; } set { _name = value; SetDateTime(); } }
        public string Author { get { return _author; } set { _author = value; SetDateTime(); } }
        private void SetDateTime()
        {
            _dateTime = DateTime.Now;
        }
        public Memento CreateUndo()
        {
            return new Memento(_isbn,_name,_author,_dateTime);
        } 
        public void RestoreFromUndo(Memento memento)
        {
            _isbn = memento.Isbn;
            _name = memento.Name;
            _author = memento.Author;
            _dateTime = memento.DateTime;
        }
        public void ShowBook()
        {
            Console.WriteLine("{0}, {1}, {2} edited : {3}", _isbn, _name, _author, _dateTime);
        }
    }
    public class Memento
    {
        public string Isbn { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public DateTime DateTime { get; set; }
        public Memento(string isbn,string name,string author,DateTime dateTime)
        {
            Isbn = isbn;
            Name = name;
            Author = author;
            DateTime = dateTime;
        }
    }
    public class GetMemento
    {
        public Memento Memento { get; set; }
    }
}
