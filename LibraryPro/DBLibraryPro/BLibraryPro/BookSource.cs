using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace BLibraryPro
{
    public class BookSource
    {
        public string SourceTypeCode { get; set; }
        public string SourceDesc { get; set; }
        public string remarks { get; set; }

        public BookSource() { }
        public BookSource(string new_code)
        {
            DLibraryPro.BookSource.Populate(this, new_code);
        }
       
        public string SaveSource()
        {
            return DLibraryPro.BookSource.SaveSource(this);     

        }

        public string UpdateSource()
        {
            return DLibraryPro.BookSource.UpdateSource(this);
        }

        public string DeleteSource()
        {
            return DLibraryPro.BookSource.DeleteSource(this);
        }

        public static DataTable GetSources(string paramFilterValues)
        {
            return DLibraryPro.BookSource.GetSources(paramFilterValues);
        }
    }
}
