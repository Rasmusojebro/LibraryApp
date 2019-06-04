using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class LargeBook : Book
    {
        public LargeBook(Author author, string title, int pages)
        {
            Id = NextId;
            Type = "large";
            AuthorId = author.Id;
            Title = title;
            Pages = pages;
            Books.Add(this);
            NextId++;
        }
    }
}
