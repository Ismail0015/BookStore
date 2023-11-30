using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Book_Store.Data;
using Book_Store.Datalayer;

namespace Book_Store.Pages.Books
{
    public class EditModel : PageModel
    {
        private readonly Book_Store.Datalayer.Application _context;
        public List<SelectListItem> GetBookCategoury { get; set; }
        public EditModel(Book_Store.Datalayer.Application context)
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

            GetBookCategoury = _context.BookCategorys.Select(i => new SelectListItem
            {
                Text = i.BookCategoryName,
                Value = i.BookCategoryId.ToString()
            }).ToList();

            var bookentity =  await _context.BookCollection.FirstOrDefaultAsync(m => m.BookId == id);
            bookentity.BookCategorys = await _context.BookCategorys.FirstOrDefaultAsync(x =>
                  x.BookCategoryId == bookentity.BookCategoryId);

            if (bookentity == null)
            {
                return NotFound();
            }
            BookEntity = bookentity;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(BookEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookEntityExists(BookEntity.BookId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool BookEntityExists(int id)
        {
          return (_context.BookCollection?.Any(e => e.BookId == id)).GetValueOrDefault();
        }
    }
}
