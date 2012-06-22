using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace BLibraryPro
{
    public class Book
    {
        public int BookCode { get; set; }
        public string BookDesc { get; set; }
        public string PublicationCode { get; set; }
        public string CategoryCode { get; set; }
        public string ActiveFlag { get; set; }
        public string ReasonForInactive { get; set; }
        
        public Book() { }
        public Book(string new_code)
        {
            DLibraryPro.Book.Populate(this, new_code);
        }

        public string SaveBook()
        {
            return DLibraryPro.Book.SaveBook(this);   
        }

        public string UpdateBook()
        {
            return DLibraryPro.Book.UpdateBook(this);
        }

        public string DeleteBook()
        {
            return DLibraryPro.Book.DeleteBook(this);
        }

        public static DataTable GetBooks(string paramFilterValues)
        {
            return DLibraryPro.Book.GetBooks(paramFilterValues);
        }
        public static DataTable GetDDLBooks(string paramFilterValues)
        {
            return DLibraryPro.Book.GetDDLBooks(paramFilterValues);
        }
        public static DataTable GetBookSN(string paramFilterValues)
        {
            return DLibraryPro.Book.GetBookSN(paramFilterValues);
        }
        public string IssueBook(string query)
        {
            return DLibraryPro.Book.IssueBook(query,this);
        }
    }
}
