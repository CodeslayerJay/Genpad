using System;
using System.Collections.Generic;
using System.Text;

namespace Genpad.Engine.Models
{
    public class Card
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Note { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

    }
}
