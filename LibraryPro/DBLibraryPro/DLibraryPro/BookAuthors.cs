using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OracleClient;

namespace DLibraryPro
{
    public class BookAuthors
    {
        public static string SaveBookAuthor(BLibraryPro.BookAuthors ObjBookAuthors)
        {
            DataAccess da = new DataAccess();
            //string new_id = BLibraryPro.MISC.GetNewID("AUTHOR");

            string sql = string.Format(@"INSERT
                        INTO M_BOOK_AUTHORS
                          (BOOK_LOT_NO,BOOK_CODE,AUTHOR_CODE)
                          VALUES('" + ObjBookAuthors.BookLotNo + @"','" + ObjBookAuthors.BookCode + @"','" + ObjBookAuthors.AuthorCode + @"')"
             );

            da.ExecuteNonQuery(sql, CommandType.Text);
            return "Data added Successfully";
        }
        public static string UpdateBookAuthor(BLibraryPro.BookAuthors BookAuthors)
        {
            DataAccess da = new DataAccess();

            string sql = string.Format(@"UPDATE M_BOOK_AUTHORS
                                        SET  BOOK_LOT_NO = '" + BookAuthors.BookLotNo + @"',
                                        BOOK_CODE = '" + BookAuthors.BookCode + @"',
                                        AUTHOR_CODE = '" + BookAuthors.AuthorCode + @"'
                                        WHERE AUTHOR_CODE = '" + BookAuthors.AuthorCode + "'");
            da.ExecuteNonQuery(sql, CommandType.Text);
            return "Data Updated Successfully";
        }

        public static string DeleteBookAuthor(BLibraryPro.BookAuthors BookAuthors)
        {
            DataAccess da = new DataAccess();
            string sql = string.Format(@"DELETE FROM M_BOOK_AUTHORS WHERE AUTHOR_CODE = '" + BookAuthors.AuthorCode + "'");
            da.ExecuteNonQuery(sql, CommandType.Text);
            return "Data Deleted Successfully";
        }

        public static DataTable GetBookAuthors(string paramFilterValues)
        {
            DataAccess da = new DataAccess();

            string sql = @"SELECT M_BOOK_AUTHORS.AUTHOR_CODE,
            M_BOOK_AUTHORS.FNAME,
            M_BOOK_AUTHORS.MNAME,
            M_BOOK_AUTHORS.LNAME,
            M_BOOK_AUTHORS.COUNTRY_CODEE
            FROM M_BOOK_AUTHORS 
            where FNAME like '%" + paramFilterValues + "%' OR MNAME like '%" + paramFilterValues + "%' OR LNAME like '%" + paramFilterValues + "%'";

            return da.ExecuteDataTable(sql, CommandType.Text);
        }

    }
}
