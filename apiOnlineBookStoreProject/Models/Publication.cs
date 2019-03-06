using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiOnlineBookStoreProject.Models
{
    public class Publication
    {
        public int PublicationId { get; set; }
        public string PublicationName { get; set; }
        public string PublicationDescription { get; set; }
        public List<Book> Books { get; set; }
    }
}
