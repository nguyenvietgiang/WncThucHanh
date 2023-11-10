using System;
using System.Collections.Generic;

namespace MVC04.Models
{
    public partial class Vegetable
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int Number { get; set; }
        public int SeasonId { get; set; }

        public virtual Season Season { get; set; } = null!;
    }
}
