using BookCatalog.Dtos;
using BookCatalog.Models;
using BookCatalog.Repo;
using Microsoft.AspNetCore.Mvc;

namespace BookCatalog.Controllers
{
    [ApiController]
    [Route("books")]
    public class BooksController:ControllerBase
    {
        private IBook _BookRepo;
        public BooksController(IBook bookRepo)
        {
            _BookRepo = bookRepo;
            //_BookRepo = new InMemBookRepo(); 
        }
        [HttpGet]
        public ActionResult<IEnumerable<BookDTO>> GetBooks()
        {
            return _BookRepo.GetBooks().ToList().Select(x => new BookDTO { Id = x.Id, Title = x.Title, Price = x.Price }).ToList(); 
        }

        [HttpGet("{id}")]
        public ActionResult<BookDTO> GetBook(Guid id)
        {
            var book = _BookRepo.GetBook(id);
            if (book == null)
                return NotFound();

            var bookDTO = new BookDTO { Id = id, Title = book.Title, Price = book.Price };
            return bookDTO;
        }

        [HttpPost]
        public ActionResult CreateBook(CreateOrUpdateBook book)
        {
            var  myBook = new Book();
            myBook.Id = Guid.NewGuid();
            myBook.Title = book.Title;
            myBook.Price = book.Price;

            _BookRepo.CreateBook(myBook);
            return Ok();
        }

        [HttpPut]
        public ActionResult UpdateBook(Guid id, CreateOrUpdateBook book)
        {
            var myBook = _BookRepo.GetBook(id);

            if (myBook == null)
                return NotFound();

            myBook.Title = book.Title;
            myBook.Price = book.Price;

            _BookRepo.UpdateBook(id, myBook);

            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteBook(Guid id)
        {
            var myBook = _BookRepo.GetBook(id);
            if (myBook == null)
                return NotFound();

            _BookRepo.DeleteBook(id);
            return Ok();
        }
    }
}
