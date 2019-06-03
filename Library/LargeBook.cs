using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class LargeBook : Books
    {
        public LargeBook(Author auth, string t, int p)
        {
            id = nextId;
            type = "large";
            authorId = auth.id;
            title = t;
            base.p = p;
            books.Add(this);
            nextId++;
        }
    }
}
