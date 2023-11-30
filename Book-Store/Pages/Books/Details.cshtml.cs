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
    public class DetailsModel : PageModel
    {
        private readonly Book_Store.Datalayer.Application _context;
        public List<SelectListItem> GetBookCategoury { get; set; }
        public DetailsModel(Book_Store.Datalayer.Application context)
        {
            _context = context;
        }

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
    }
}
