using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace BLibraryPro
{
    public class BookLot
    {
        public int BookLotNo { get; set; }
        public int BookCode { get; set; }
        public string EditionCode { get; set; }
        public int YearOfPublication { get; set; }
        public string ISBN { get; set; }
        public float Price { get; set; }
        public int NoOfPage { get; set; }
        public string SourceTypeCode { get; set; }
        public DateTime ReceivedOn { get; set; }
        public int NoOfBooks { get; set; }
        
        public BookLot() { }
        public BookLot(string new_code)
        {
            DLibraryPro.BookLot.Populate(this, new_code);
        }

        public string SaveBookLot(string UserName, string Author)
        {
            return DLibraryPro.BookLot.SaveBookLot(this, UserName, Author);   
        }

        public string UpdateBookLot()
        {
            return DLibraryPro.BookLot.UpdateBookLot(this);
        }

        public string DeleteBookLot()
        {
            return DLibraryPro.BookLot.DeleteBookLot(this);
        }

        public static DataTable GetBookLots(string paramFilterValues)
        {
            return DLibraryPro.BookLot.GetBookLots(paramFilterValues);
        }
    }
}
