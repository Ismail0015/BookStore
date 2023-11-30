using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Book_Store.Data
{
    public class BookEntity
    {
        [Key]
        public int BookId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string AuthorName { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [datavalidation(ErrorMessage = "Date is less than the current time")]
        public DateTime ReleaseDate { get; set; }
        [Required]
        [StringLength(1, ErrorMessage = "Input should be 1 to 9")]
        public string Rating { get; set; }

        [Display(Name = "Category")]
        public int BookCategoryId { get; set; }

        [ForeignKey("BookCategoryId")]
        public virtual Category? BookCategorys { get; set; }

    }
    public class datavalidation : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            DateTime today = Convert.ToDateTime(value);
            return today <= DateTime.Now;
        }
    }
}

