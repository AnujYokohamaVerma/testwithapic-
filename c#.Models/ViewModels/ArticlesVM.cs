using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApolloWeb.Models;

namespace Apollo.Models.ViewModels
{
    public class ArticlesVM
    {
        public Articles Articles { get; set; }
       
    }
}
