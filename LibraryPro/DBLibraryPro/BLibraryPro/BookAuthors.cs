using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace BLibraryPro
{
    public class BookAuthors
    {
        public int BookLotNo { get; set; }
        public int BookCode { get; set; }
        public string AuthorCode { get; set; }
        
        public BookAuthors() { }
        public BookAuthors(string new_code)
        {
            //DLibraryPro.BookAuthors.Populate(this, new_code);
        }

        public string SaveBookAuthor()
        {
            return DLibraryPro.BookAuthors.SaveBookAuthor(this);   
        }

        public string UpdateBookAuthor()
        {
            return DLibraryPro.BookAuthors.UpdateBookAuthor(this);
        }

        public string DeleteBookAuthor()
        {
            return DLibraryPro.BookAuthors.DeleteBookAuthor(this);
        }

        public static DataTable GetBookAuthors(string paramFilterValues)
        {
            return DLibraryPro.BookAuthors.GetBookAuthors(paramFilterValues);
        }
    }
}
