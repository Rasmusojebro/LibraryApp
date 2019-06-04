using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class LargeBook : Book
    {
        public LargeBook(Author auth, string t, int p)
        {
            Id = NextId;
            Type = "large";
            AuthorId = auth.Id;
            Title = t;
            base.p = p;
            Books.Add(this);
            NextId++;
        }
    }
}
