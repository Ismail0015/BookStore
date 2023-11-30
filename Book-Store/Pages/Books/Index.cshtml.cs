using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Book_Store.Data;
using Book_Store.Datalayer;

namespace Book_Store.Pages.Books
{
    public class IndexModel : PageModel
    {
        private readonly Book_Store.Datalayer.Application _context;

        public string TitleSort { get; set; }
        public string AuthorSort { get; set; }
        public string CategorySort { get; set; }
        public string DateSort { get; set; }
        public string RatingSort { get; set; }

        public string Filter { get; set; }

        public IndexModel(Book_Store.Datalayer.Application context)
        {
            _context = context;
        }

        public IList<BookEntity> BookEntity { get;set; } = default!;

        public async Task OnGetAsync(string sortOrder, string search)
        {
            if (_context.BookCollection != null)
            {
                TitleSort = sortOrder == "title_asc_sort" ? "title_desc_sort" : "title_asc_sort";
                AuthorSort = sortOrder == "author_asc_sort" ? "author_desc_sort" : "author_asc_sort";
                CategorySort = sortOrder == "category_asc_sort" ? "category_desc_sort" : "category_asc_sort";
                DateSort = sortOrder == "date_asc_sort" ? "date_desc_sort" : "date_asc_sort";
                RatingSort = sortOrder == "rating_asc_sort" ? "rating_desc_sort" : "rating_asc_sort";

                if (!String.IsNullOrEmpty(search))
                {
                    BookEntity = await _context.BookCollection.Where(x => x.Title.Contains(search)
                    || x.AuthorName.Contains(search) || x.BookCategorys.BookCategoryName.Contains(search)).ToListAsync();
                }
                else
                {
                    BookEntity = await _context.BookCollection.ToListAsync();
                }
   
                foreach (var obj in BookEntity)
                {
                    obj.BookCategorys = await _context.BookCategorys.FirstOrDefaultAsync(x=>
                    x.BookCategoryId == obj.BookCategoryId);
                }
                switch (sortOrder)
                {
                    case "title_asc_sort":
                        BookEntity = BookEntity.OrderBy(s => s.Title).ToList();
                        break;
                    case "title_desc_sort":
                        BookEntity = BookEntity.OrderByDescending(s => s.Title).ToList();
                        break;

                    case "author_asc_sort":
                        BookEntity = BookEntity.OrderBy(s => s.AuthorName).ToList();
                        break;
                    case "author_desc_sort":
                        BookEntity = BookEntity.OrderByDescending(s => s.AuthorName).ToList();
                        break;

                    case "category_asc_sort":
                        BookEntity = BookEntity.OrderBy(s => s.BookCategorys.BookCategoryName).ToList();
                        break;
                    case "category_desc_sort":
                        BookEntity = BookEntity.OrderByDescending(s => s.BookCategorys.BookCategoryName).ToList();
                        break;

                    case "date_asc_sort":
                        BookEntity = BookEntity.OrderBy(s => s.ReleaseDate).ToList();
                        break;
                    case "date_desc_sort":
                        BookEntity = BookEntity.OrderByDescending(s => s.ReleaseDate).ToList();
                        break;
                    case "rating_asc_sort":
                        BookEntity = BookEntity.OrderBy(s => s.Rating).ToList();
                        break;
                    case "rating_desc_sort":
                        BookEntity = BookEntity.OrderByDescending(s => s.Rating).ToList();
                        break;
                    default:
                        BookEntity = BookEntity.OrderBy(s => s.Rating).ToList();
                        break;
                }
            }
        }
    }
}
