using EF.Domain.Catalogs;
using System;
using System.Collections.Generic;

namespace EF.Domain.Items
{
    public class Book : LibraryItem
    {
        public string Author { get; private set; }
        public string ISBN { get; private set; }
        public int PageCount { get; private set; }
        public Book()
            : base()
        {
            // parameterless constructor used by EF
        }
        
        public Book(ItemStatus status, Language language, string title, Catalog catalog, string author, string isbn) :
            base(status, language, title, catalog)
        {
            Author = author;
            ISBN = isbn;
        }

        public Book(ItemStatus status, Language language, string title, Catalog catalog, string author, string isbn, int pageCount) :
            this(status, language, title, catalog, author, isbn)
        {
            PageCount = pageCount;
        }
    }
}
