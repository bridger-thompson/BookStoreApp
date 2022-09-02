using System;
using System.Collections.Generic;

namespace BookstoreApp.api.Data
{
    public partial class Author
    {
        public Author()
        {
            Tables = new HashSet<Table>();
        }

        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Bio { get; set; }

        public virtual ICollection<Table> Tables { get; set; }
    }
}
