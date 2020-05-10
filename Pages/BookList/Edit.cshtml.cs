using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using asprazor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace asprazor.Pages.BookList
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Book Book { get; set; }
        public async Task OnGet(int id)
        {
            Book = await _db.Book.FindAsync(id);
        }

        public async Task<IActionResult> OnPost() {
            if(ModelState.IsValid) {
                var eBook = await _db.Book.FindAsync(Book.Id);
                eBook.Name = Book.Name;
                eBook.ISBN = Book.ISBN;
                eBook.Author = Book.Author;
                eBook.PublishDate = Book.PublishDate;
                await _db.SaveChangesAsync();
                return RedirectToPage("Index");
            } else {
                return Page();
            }
        }
    }
}
