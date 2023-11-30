using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Book_Store.Data;
using Book_Store.Datalayer;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Book_Store.Pages.Books
{
    public class DeleteModel : PageModel
    {
        private readonly Book_Store.Datalayer.Application _context;
        public List<SelectListItem> GetBookCategoury { get; set; }
        public DeleteModel(Book_Store.Datalayer.Application context)
        {
            _context = context;
        }

        [BindProperty]
      public BookEntity BookEntity { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.BookCollection == null)
            {
                return NotFound();
            }
           

            var bookentity = await _context.BookCollection.FirstOrDefaultAsync(m => m.BookId == id);
            bookentity.BookCategorys = await _context.BookCategorys.FirstOrDefaultAsync(x =>
                  x.BookCategoryId == bookentity.BookCategoryId);

            if (bookentity == null)
            {
                return NotFound();
            }
            else 
            {
                BookEntity = bookentity;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.BookCollection == null)
            {
                return NotFound();
            }
            var bookentity = await _context.BookCollection.FindAsync(id);

            if (bookentity != null)
            {
                BookEntity = bookentity;
                _context.BookCollection.Remove(BookEntity);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
