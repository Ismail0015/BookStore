using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Book_Store.Data;
using Book_Store.Datalayer;

namespace Book_Store.Pages.CategoryOfBooks
{
    public class DetailsModel : PageModel
    {
        private readonly Book_Store.Datalayer.Application _context;

        public DetailsModel(Book_Store.Datalayer.Application context)
        {
            _context = context;
        }

      public Category Category { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.BookCategorys == null)
            {
                return NotFound();
            }

            var category = await _context.BookCategorys.FirstOrDefaultAsync(m => m.BookCategoryId == id);
            if (category == null)
            {
                return NotFound();
            }
            else 
            {
                Category = category;
            }
            return Page();
        }
    }
}
