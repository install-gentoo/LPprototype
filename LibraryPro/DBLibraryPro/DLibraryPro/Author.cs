using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OracleClient;

namespace DLibraryPro
{
    public class Author
    {
        public static string SaveAuthor(BLibraryPro.Author ObjAuthor)
        {
            DataAccess da = new DataAccess();
            string new_id = BLibraryPro.MISC.GetNewID("AUTHOR");

            string sql = string.Format(@"INSERT
                        INTO M_AUTHOR
                          (AUTHOR_CODE,FNAME,MNANE,LNAME,COUNTRY_CODE)
                          VALUES('" + new_id + @"','" + ObjAuthor.FirstName + @"','" + ObjAuthor.MiddleName + @"','" + ObjAuthor.LastName + @"','" + ObjAuthor.CountryCode + @"') "
             );

            da.ExecuteNonQuery(sql, CommandType.Text);
            return new_id;
        }
        public static string UpdateAuthor(BLibraryPro.Author Author)
        {
            DataAccess da = new DataAccess();

            string sql = string.Format(@"UPDATE M_AUTHOR
                                        SET  FNAME = '" + Author.FirstName + @"',
                                        MNANE = '" + Author.MiddleName + @"',
                                        LNAME = '" + Author.LastName + @"',
                                        COUNTRY_CODE = '" + Author.CountryCode + @"'
                                        WHERE AUTHOR_CODE = '" + Author.AuthorCode + "'");
            da.ExecuteNonQuery(sql, CommandType.Text);
            return "Data Updated Successfully";
        }

        public static string DeleteAuthor(BLibraryPro.Author Author)
        {
            DataAccess da = new DataAccess();
            string sql = string.Format(@"DELETE FROM M_AUTHOR WHERE AUTHOR_CODE = '" + Author.AuthorCode + "'");
            da.ExecuteNonQuery(sql, CommandType.Text);
            return "Data Deleted Successfully";
        }

        public static DataTable GetAuthors(string paramFilterValues)
        {
            DataAccess da = new DataAccess();

            string sql = @"SELECT M_AUTHOR.AUTHOR_CODE,
            M_AUTHOR.FNAME || ' ' || M_AUTHOR.MNANE || ' ' || M_AUTHOR.LNAME as NAME,
            M_AUTHOR.COUNTRY_CODE
            FROM M_AUTHOR 
            where FNAME like '%" + paramFilterValues + "%' OR MNANE like '%" + paramFilterValues + "%' OR LNAME like '%" + paramFilterValues + "%'";

            return da.ExecuteDataTable(sql, CommandType.Text);
        }

        public static void Populate(BLibraryPro.Author Author, string new_code)
        {
            DataAccess da = new DataAccess();
            string sql = @"SELECT M_AUTHOR.AUTHOR_CODE,
                            M_AUTHOR.FNAME,
                            M_AUTHOR.MNANE,
                            M_AUTHOR.LNAME,
                            M_AUTHOR.COUNTRY_CODE
                            FROM M_AUTHOR 
                            where AUTHOR_CODE = '" + new_code + "'";
            OracleDataReader odr = da.ExecuteReader(sql, CommandType.Text);
            if (odr.Read())
            {
                Author.AuthorCode = new_code;
                Author.FirstName = odr["FNAME"].ToString();
                Author.MiddleName = odr["MNANE"].ToString();
                Author.LastName = odr["LNAME"].ToString();
                Author.CountryCode = odr["COUNTRY_CODE"].ToString();
            }
        }
    }
}
