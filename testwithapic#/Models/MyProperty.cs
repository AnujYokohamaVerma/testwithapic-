using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace testwithapic_.Models
{
    public class MyProperty
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public int DisplayOrder { get; set; }
    }
}
