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
            var bookDTO = new BookDTO { Id = id, Title = book.Title, Price = book.Price };
            return bookDTO;
        }
    }
}
