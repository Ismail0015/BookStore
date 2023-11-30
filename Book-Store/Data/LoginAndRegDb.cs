using System.ComponentModel.DataAnnotations;

namespace Book_Store.Data
{
    public class LoginAndRegDb
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

    }
}
