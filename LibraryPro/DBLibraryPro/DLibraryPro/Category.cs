using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OracleClient;

namespace DLibraryPro
{
    public class Category
    {
        public static string SaveCategory(BLibraryPro.Category ObjCategory)
        {
            DataAccess da = new DataAccess();
            string new_id = BLibraryPro.MISC.GetNewID("CATEGORY");
                string sql = string.Format(@"INSERT
                        INTO M_BOOK_CATEGORY
                          (CATEGORY_CODE ,CATEGORY_DESC,REMARKS)
                          VALUES('" + new_id + @"',' " + ObjCategory.CategoryDesc + @"','" + ObjCategory.remarks + @"' ) "
                 );

            da.ExecuteNonQuery(sql, CommandType.Text);
            return "Data added Successfully";
        }

        public static string UpdateCategory(BLibraryPro.Category category)
        {
            DataAccess da = new DataAccess();
            string sql = string.Format(@"UPDATE M_BOOK_CATEGORY
                                        SET  CATEGORY_DESC = '" + category.CategoryDesc + @"',
                                         REMARKS= '" + category.remarks + @"'
                                         WHERE CATEGORY_CODE = '" + category.CategoryCode + "'");
            da.ExecuteNonQuery(sql, CommandType.Text);
            return "Data Updated Successfully";
        }

        public static string DeleteCategory(BLibraryPro.Category category)
        {
            DataAccess da = new DataAccess();
            string sql = string.Format(@"DELETE FROM M_BOOK_CATEGORY WHERE CATEGORY_CODE = '" + category.CategoryCode + "'");
            da.ExecuteNonQuery(sql,CommandType.Text);
            return "Data Deleted Successfully";
        }

        public static DataTable GetCategories(string paramFilterValues)
        {
            DataAccess da = new DataAccess();
            string sql = @"SELECT M_BOOK_CATEGORY.CATEGORY_CODE,
                              M_BOOK_CATEGORY.CATEGORY_DESC,
                              M_BOOK_CATEGORY.REMARKS
                            FROM M_BOOK_CATEGORY
                            where category_desc like '%" + paramFilterValues + "%'";
            return da.ExecuteDataTable(sql, CommandType.Text);
        }

        public static void Populate(BLibraryPro.Category category, string new_code)
        {
            DataAccess da = new DataAccess();
            string sql = @"SELECT M_BOOK_CATEGORY.CATEGORY_CODE,
                              M_BOOK_CATEGORY.CATEGORY_DESC,
                              M_BOOK_CATEGORY.REMARKS
                            FROM M_BOOK_CATEGORY
                            where category_code = '" + new_code + "'";
            OracleDataReader odr = da.ExecuteReader(sql, CommandType.Text);
            if (odr.Read())
            {
                category.CategoryCode = new_code;
                category.CategoryDesc = odr["CATEGORY_DESC"].ToString();
                category.remarks = odr["REMARKS"].ToString();
            }
        }
       
    }
}