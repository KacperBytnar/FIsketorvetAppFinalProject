using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FisketorvetWebAppProject.Models
{
    public class Events
    {
        [Range(1, 100)]
        public int Id { get; set; }

        [Required, MinLength(5), MaxLength(40)]
        public string Title { get; set; }

        [Required]
        public string Image { get; set; }

        public string Description { get; set; }

    }
}
