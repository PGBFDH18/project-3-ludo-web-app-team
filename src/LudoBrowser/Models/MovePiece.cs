using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LudoBrowser.Models
{
    public class MovePiece
    {
        public int PlayerId { get; set; }
        public int PieceId { get; set; }
        public int NumberOfFields { get; set; }
    }
}
