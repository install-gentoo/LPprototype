using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace BLibraryPro
{
    public class Author
    {
        public string AuthorCode { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string CountryCode { get; set; }
        
        public Author() { }
        public Author(string new_code)
        {
            DLibraryPro.Author.Populate(this, new_code);
        }

        public string SaveAuthor()
        {
            return DLibraryPro.Author.SaveAuthor(this);   
        }

        public string UpdateAuthor()
        {
            return DLibraryPro.Author.UpdateAuthor(this);
        }

        public string DeleteAuthor()
        {
            return DLibraryPro.Author.DeleteAuthor(this);
        }

        public static DataTable GetAuthors(string paramFilterValues)
        {
            return DLibraryPro.Author.GetAuthors(paramFilterValues);
        }
    }
}
