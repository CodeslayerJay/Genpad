using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Genpad.DTOs
{
    public class CardDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Note { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
