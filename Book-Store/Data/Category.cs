
using System.ComponentModel.DataAnnotations;

namespace Book_Store.Data
{
    public class Category
    {
        [Key]
        public int BookCategoryId { get; set; }
        [Display(Name ="Category")]
        public string BookCategoryName { get; set; }
    }
}
