using SQLite;
using System;

namespace jtrakmobile.Models
{
    public class Book
    {
        public Guid Id { get; set; }
        [Ignore]
        public string Title { get; set; }
        [Ignore]
        public int AuthorId { get; set; }
        public string Author { get; set; }
    }
}
