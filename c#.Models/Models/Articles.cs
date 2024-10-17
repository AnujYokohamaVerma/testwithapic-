using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ApolloWeb.Models
{
    public class Articles
    {
        [Key]
        public int Id { get; set; }
        
        
        [DisplayName("Article Title ")]
        public string Title { get; set; }

        [DisplayName("Summary")]
        public string Summary { get; set; }

        [DisplayName("Artical")]
        public string Artical { get; set; }
        [DisplayName("Date Created")]
        public DateTime CreatedDate { get; set; }
        [DisplayName("Date Edited")]
        public DateTime ModifiedDate { get; set; }

        [DisplayName("Image File")]

        [ValidateNever]
        public string ImageFile { get; set; }

    }


}
