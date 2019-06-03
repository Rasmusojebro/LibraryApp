using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class MediumBook : Books
    {
        public MediumBook(Author auth, string t, int p)
        {
            id = nextId;
            type = "medium";
            authorId = auth.id;
            title = t;
            base.p = p;
            books.Add(this);
            nextId++;
        }
    }
}