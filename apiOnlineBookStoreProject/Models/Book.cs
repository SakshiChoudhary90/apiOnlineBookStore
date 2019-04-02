using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiOnlineBookStoreProject.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public string BookName { get; set; }
        public float BookPrice { get; set; }
        public string BookType { get; set; }
        public string BookImage { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }
        public int PublicationId { get; set; }
        public Publication Publication { get; set; }
        public int BookCategoryId { get; set; }
        public BookCategory BookCategory { get; set; }
    }
}
