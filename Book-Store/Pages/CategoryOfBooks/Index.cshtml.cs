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
    public class IndexModel : PageModel
    {
        private readonly Book_Store.Datalayer.Application _context;

        public IndexModel(Book_Store.Datalayer.Application context)
        {
            _context = context;
        }

        public IList<Category> Category { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.BookCategorys != null)
            {
                Category = await _context.BookCategorys.ToListAsync();
            }
        }
    }
}
