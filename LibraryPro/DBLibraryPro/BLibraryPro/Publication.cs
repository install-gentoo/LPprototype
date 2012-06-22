using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DLibraryPro;


namespace BLibraryPro
{
   public class Publication
    {
       public string PublicationCode { get; set; }
       public string PublicationDesc { get; set; }
        public string CountryCode { get; set; }
       public DateTime EstDate { get; set; }

      
             
   
       public Publication() { }
        public Publication(string new_code)
        {
            DLibraryPro.Publication.Populate(this, new_code);
        }
       
     public string SavePublication()
     {
        //DLibraryPro.Publication DPublication = new DLibraryPro.Publication();
         return DLibraryPro.Publication.SavePublication(this);
        // throw new NotImplementedException();
     }

     public static DataTable GetPublication(string paramFilterValues)
     {
         return DLibraryPro.Publication.GetPublication(paramFilterValues);
     }

     public string UpdatePublication()
     {
         return DLibraryPro.Publication.UpdatePublication(this);
     }

     public string DeletePublication()
     {
         return DLibraryPro.Publication.DeletePublication(this);
     }
    }
}
