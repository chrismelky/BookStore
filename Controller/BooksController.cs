using System;
using System.Collections.Generic;
using System.Linq;
using asprazor.Model;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace asprazor.Controller
{

    [ApiController]
    [Route("api/[controller]")]
    public class BooksController: ControllerBase
    {
        
        private readonly ApplicationDbContext _db;
        public BooksController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IEnumerable<Book> getAll() {
            var book = from s in _db.Book select s;
            return book.ToList();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> getOne(int id) {
            
            var book = await _db.Book.FindAsync(id);
            if (book == null) {
                return NotFound();
            }
            return book;

        }

        [HttpPost]
        public async Task<Book> create(Book book) {
            await _db.AddAsync(book);
            await _db.SaveChangesAsync();
            return book;
        }

        [HttpDelete("{id}")]
        public async Task<Book> delete(int id) {
            var book = await _db.Book.FindAsync(id);
            _db.Book.Remove(book);
            await _db.SaveChangesAsync();
            return book;
        }


    }


}