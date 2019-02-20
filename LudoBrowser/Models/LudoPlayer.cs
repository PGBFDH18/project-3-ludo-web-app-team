using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LudoBrowser.Models
{
    public class LudoPlayer
    {
        [Required]
        public string Color { get; set; }

        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
