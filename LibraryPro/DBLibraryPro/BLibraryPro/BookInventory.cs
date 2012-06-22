using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace BLibraryPro
{
    public class BookInventory
    {
        public string BookSn { get; set; }
        public int BookLotNo { get; set; }
        public int BookCode { get; set; }
        public DateTime EntryDate { get; set; }
        public string EntryBy { get; set; }
        
        public BookInventory() { }
        public BookInventory(string new_code)
        {
            DLibraryPro.BookInventory.Populate(this, new_code);
        }

        public string SaveBookInventory()
        {
            return DLibraryPro.BookInventory.SaveBookInventory(this);   
        }

        public string UpdateBookInventory()
        {
            return DLibraryPro.BookInventory.UpdateBookInventory(this);
        }

        public string DeleteBookInventory()
        {
            return DLibraryPro.BookInventory.DeleteBookInventory(this);
        }

        public static DataTable GetBookInventories(string paramFilterValues)
        {
            return DLibraryPro.BookInventory.GetBookInventories(paramFilterValues);
        }
    }
}
