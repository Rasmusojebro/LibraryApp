using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class SmallBook : Books
    {
         
        public SmallBook(Author auth, string t, int p)
        {
            id = nextId;
            type = "small";
            authorId = auth.id;
            title = t;
            pages = p;
            books.Add(this);
            nextId++;
        }

    }
}
