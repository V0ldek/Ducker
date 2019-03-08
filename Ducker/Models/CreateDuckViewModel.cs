using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Ducker.Data.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Ducker.Models
{
    [Display(Name = "Create duck.")]
    public class CreateDuckViewModel
    {
        [Display(Name = "Name")]
        [MaxLength(32)]
        [Required]
        [RegularExpression(@"^[A-Za-ząćęłńóśźżĄĆĘŁŃÓŚŹŻ]*$")]
        public string Name { get; set; }

        [Display(Name = "Color")]
        [Required]
        public string Color { get; set; }
        
        public List<SelectListItem> Colors { get; }

        public Color ColorAsEnum => Enum.Parse<Color>(Color);

        public CreateDuckViewModel()
        {
            var colorsArray = Enum.GetNames(typeof(Color));

            Colors = colorsArray.Select(c => new SelectListItem(c, c)).ToList();
        }
    }
}
