using BookCatalog.Models;

namespace BookCatalog.Repo
{
    public class InMemBookRepo : IBook
    {

        private List<Book> _Books;

        public InMemBookRepo()
        {
            _Books = new() { new Book { Id = Guid.NewGuid(), Title = "Book 0", Price = 10 } };
        }

        public Book GetBook(Guid id)
        {
            var book = _Books.Where(x => x.Id == id).FirstOrDefault();
            return book;
        }

        public IEnumerable<Book> GetBooks()
        {
            return _Books;

        }
        public void CreateBook(Book book)
        {
            throw new NotImplementedException();
        }

        public void DeleteBook(Guid id, Book book)
        {
            throw new NotImplementedException();
        }

        public void UpdateBook(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
