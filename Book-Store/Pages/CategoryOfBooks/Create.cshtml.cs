using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Book_Store.Data;
using Book_Store.Datalayer;

namespace Book_Store.Pages.CategoryOfBooks
{
    public class CreateModel : PageModel
    {
        private readonly Book_Store.Datalayer.Application _context;

        public CreateModel(Book_Store.Datalayer.Application context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Category Category { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.BookCategorys == null || Category == null)
            {
                return Page();
            }

            _context.BookCategorys.Add(Category);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
