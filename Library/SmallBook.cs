using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class SmallBook : Book
    {
        public SmallBook(Author author, string title, int pages)
        {
            Id = NextId;
            Type = "small";
            AuthorId = author.Id;
            Title = title;
            Pages = pages;
            Books.Add(this);
            NextId++;
        }

    }
}
