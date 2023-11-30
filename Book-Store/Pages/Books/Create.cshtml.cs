using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Book_Store.Data;
using Book_Store.Datalayer;

namespace Book_Store.Pages.Books
{
    public class CreateModel : PageModel
    {
        private readonly Book_Store.Datalayer.Application _context;

        public List<SelectListItem> GetBookCategoury { get; set; }
        public CreateModel(Book_Store.Datalayer.Application context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            GetBookCategoury = _context.BookCategorys.Select(i => new SelectListItem
            {
                Text = i.BookCategoryName,
                Value = i.BookCategoryId.ToString()
            }).ToList();

            return Page();
        }

        [BindProperty]
        public BookEntity BookEntity { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.BookCollection == null || BookEntity == null)
            {
                return Page();
            }

            _context.BookCollection.Add(BookEntity);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
