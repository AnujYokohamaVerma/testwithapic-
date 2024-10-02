using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace testwithapic_.Models
{
    public class MyProperty
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("New Property")]
        public string Name { get; set; }
        [DisplayName("Display Order")]
        public int DisplayOrder { get; set; }
    }
}
