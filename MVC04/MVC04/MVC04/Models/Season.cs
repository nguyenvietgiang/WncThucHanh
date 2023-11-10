using System;
using System.Collections.Generic;

namespace MVC04.Models
{
    public partial class Season
    {
        public Season()
        {
            Vegetables = new HashSet<Vegetable>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Vegetable> Vegetables { get; set; }
    }
}
