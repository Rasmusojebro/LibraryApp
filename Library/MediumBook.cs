using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class MediumBook : Book
    {
        public MediumBook(Author author, string title, int pages)
        {
            Id = NextId;
            Type = "medium";
            AuthorId = author.Id;
            Title = title;
            base.Pages = pages;
            Books.Add(this);
            NextId++;
        }
    }
}