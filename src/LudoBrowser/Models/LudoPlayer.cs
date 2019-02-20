using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LudoBrowser.Models
{
    public class LudoPlayer
    {
        public string Color { get; set; }

        public int Id { get; set; }

        [StringLength(25, MinimumLength = 1)]
        [Required]
        public string Name { get; set; }
    }
}
