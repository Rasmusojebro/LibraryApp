using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class SmallBook : Book
    {
        public SmallBook(Author auth, string t, int p)
        {
            Id = NextId;
            Type = "small";
            AuthorId = auth.Id;
            Title = t;
            base.pages = p;
            Books.Add(this);
            NextId++;
        }

    }
}
