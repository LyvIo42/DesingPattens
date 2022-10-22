using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memento
{
    //bir hafıza oluşturmak ona geri dönüşü saglamak
    class Program
    {
        static void Main(string[] args)
        {
            Book book = new Book
            {
                IsBn = "1234",
                Title = "Sefiller",
                Author = "Victor Hugo"

            };
            book.ShowBook();
            CareTaker history = new CareTaker();
            history.Memento = book.CreateUndo();
            book.IsBn = "54321";
            book.Title = "VİCTOR HUGO";
            book.ShowBook();
            book.RestoreFormUndo(history.Memento);
            book.ShowBook();
            Console.ReadLine();
        }
    }
    class Book
    {
        private string _title;
        private string _author;
        private string _ısban;
        private DateTime _lastEdited;
        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                SetLastEdited();
            }

        }
        public string Author
        {
            get { return _author; }
            set
            {
                _author = value;
                SetLastEdited();
            }
        }
        public string IsBn
        {
            get { return _ısban; }
            set
            {
                _ısban = value;
                SetLastEdited();
            }
        }
        private void SetLastEdited()
        {
            _lastEdited = DateTime.UtcNow;
        }
        public Memento CreateUndo()
        {
            return new Memento(_ısban, _title, _author, _lastEdited);
        }

        public void RestoreFormUndo(Memento memento)
        {
            _title = memento.Title;
            _author = memento.Author;
            _ısban = memento.IsBn;
            _lastEdited = memento.LastEdited;
        }
        public void ShowBook()
        {
            Console.WriteLine("{0},{1},{2} edited:{3}", IsBn, Title, Author, _lastEdited);
        }

    }
    public class Memento
    {
        public string IsBn { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime LastEdited { get; set; }
        public Memento(string isbn, string title, string author, DateTime lastEdit)
        {
            IsBn = isbn;
            Title = title;
            Author = author;
            LastEdited = lastEdit;
        }
    }
    class CareTaker
    {
        public Memento Memento { get; set; }
    }

}
