using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace BLibraryPro
{
    public class Category
    {
        public string CategoryCode { get; set; }
        public string CategoryDesc { get; set; }
        public string remarks { get; set; }

        public Category() { }
        public Category(string new_code)
        {
            DLibraryPro.Category.Populate(this, new_code);
        }
       
        public string SaveCategory()
        {
            return DLibraryPro.Category.SaveCategory(this);     

        }

        public string UpdateCategory()
        {
            return DLibraryPro.Category.UpdateCategory(this);
        }

        public string DeleteCatagory()
        {
            return DLibraryPro.Category.DeleteCategory(this);
        }
        public static DataTable GetCategories(string paramFilterValues)
        {
            //if (this.CategoryCode < 0) { this.CategoryCode = 0; }
            return DLibraryPro.Category.GetCategories(paramFilterValues);
        }
    }
}
