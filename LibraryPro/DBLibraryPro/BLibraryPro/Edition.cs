using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DLibraryPro;

namespace BLibraryPro
{
   public class Edition
    {
        public string EditionCode { get; set; }
        public string EditionDesc { get; set; }
        public string Remarks { get; set; }

        public Edition() { }
        public Edition(string new_code)
        {
            DLibraryPro.Edition.Populate(this, new_code);
        }

        public string SaveEdition()
        {
            return DLibraryPro.Edition.SaveEdition(this);
        }

        public string UpdateEditon()
        {
            return DLibraryPro.Edition.UpdateEditon(this);
        }

        public string DeleteEdition()
        {
            return DLibraryPro.Edition.DeleteEdition(this);
        }

        public static DataTable GetEditions(string paramFilterValues)
        {
            return DLibraryPro.Edition.GetEditions(paramFilterValues);
        }
    }
}
