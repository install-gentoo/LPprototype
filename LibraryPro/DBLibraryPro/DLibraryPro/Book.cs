using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OracleClient;

namespace DLibraryPro
{
    public class Book
    {
        public static string SaveBook(BLibraryPro.Book ObjBook)
        {
            DataAccess da = new DataAccess();
            int new_id = Convert.ToInt32(BLibraryPro.MISC.GetNewID("BOOK"));

            string sql = string.Format(@"INSERT
                        INTO M_BOOK
                          (BOOK_CODE,BOOK_DESC,PUBLICATION_CODE,CATEGORY_CODE,ACTIVE_FLAG,REASON_FOR_INACTIVE)
                          VALUES('" + new_id + @"','" + ObjBook.BookDesc + @"','" + ObjBook.PublicationCode + @"','" + ObjBook.CategoryCode + @"','" + ObjBook.ActiveFlag + @"','" + ObjBook.ReasonForInactive + @"') "
             );

            da.ExecuteNonQuery(sql, CommandType.Text);
            return new_id.ToString();
        }
        public static string UpdateBook(BLibraryPro.Book Book)
        {
            DataAccess da = new DataAccess();

            string sql = string.Format(@"UPDATE M_BOOK
                                        SET  BOOK_DESC = '" + Book.BookDesc + @"',
                                        PUBLICATION_CODE = '" + Book.PublicationCode + @"',
                                        CATEGORY_CODE = '" + Book.CategoryCode + @"',
                                        ACTIVE_FLAG = '" + Book.ActiveFlag + @"',
                                        REASON_FOR_INACTIVE = '" + Book.ReasonForInactive + @"'
                                        WHERE BOOK_CODE = '" + Book.BookCode + "'");
            da.ExecuteNonQuery(sql, CommandType.Text);
            return "Data Updated Successfully";
        }

        public static string DeleteBook(BLibraryPro.Book Book)
        {
            DataAccess da = new DataAccess();
            string sql = string.Format(@"DELETE FROM M_BOOK WHERE BOOK_CODE = '" + Book.BookCode + "'");
            da.ExecuteNonQuery(sql, CommandType.Text);
            return "Data Deleted Successfully";
        }

        public static DataTable GetBooks(string paramFilterValues)
        {
            DataAccess da = new DataAccess();

            string sql = @"SELECT M_BOOK.BOOK_CODE,
            M_BOOK.BOOK_DESC,
            M_BOOK.PUBLICATION_CODE,
            M_BOOK.CATEGORY_CODE,
            M_BOOK.ACTIVE_FLAG,
            M_BOOK.REASON_FOR_INACTIVE,
            M_PUBLICATION.PUBLICATION_DESC,
            M_BOOK_CATEGORY.CATEGORY_DESC,
            M_AUTHOR.FNAME || ' ' || M_AUTHOR.MNANE || ' ' || M_AUTHOR.LNAME as AUTHORNAME,
            M_AUTHOR.AUTHOR_CODE,
            M_BOOK_LOT.BOOK_LOT_NO,
            M_BOOK_SOURCE.SOURCE_DESC
            FROM M_BOOK inner join M_PUBLICATION on M_BOOK.PUBLICATION_CODE = M_PUBLICATION.PUBLICATION_CODE inner join M_BOOK_CATEGORY
on M_BOOK.CATEGORY_CODE=M_BOOK_CATEGORY.CATEGORY_CODE inner join M_BOOK_AUTHORS on M_BOOK_AUTHORS.BOOK_CODE=M_BOOK.BOOK_CODE 
inner join M_AUTHOR on M_BOOK_AUTHORS.AUTHOR_CODE=M_AUTHOR.AUTHOR_CODE inner join M_BOOK_LOT on M_BOOK_LOT.BOOK_CODE=M_BOOK.BOOK_CODE inner join M_BOOK_SOURCE 
on M_BOOK_SOURCE.SOURCE_TYPE_CODE=M_BOOK_LOT.SOURCE_TYPE_CODE
            where BOOK_DESC like '%" + paramFilterValues + "%'";

            return da.ExecuteDataTable(sql, CommandType.Text);
        }

        public static DataTable GetDDLBooks(string paramFilterValues)
        {
            DataAccess da = new DataAccess();

            string sql = @"SELECT M_BOOK.BOOK_CODE,
            M_BOOK.BOOK_DESC,
            M_BOOK.PUBLICATION_CODE,
            M_BOOK.CATEGORY_CODE,
            M_BOOK.ACTIVE_FLAG,
            M_BOOK.REASON_FOR_INACTIVE
            FROM M_BOOK 
            where BOOK_DESC like '%" + paramFilterValues + "%'";

            return da.ExecuteDataTable(sql, CommandType.Text);
        }

        public static DataTable GetBookSN(string paramFilterValues) 
        {
            DataAccess da = new DataAccess();

            string sql = @"SELECT BOOK_CODE, BOOK_SN FROM M_BOOK_INVENTORY";

            return da.ExecuteDataTable(sql, CommandType.Text);
        }

        public static void Populate(BLibraryPro.Book Book, string new_code)
        {
            DataAccess da = new DataAccess();
            string sql = @"SELECT M_BOOK.BOOK_CODE,
                            M_BOOK.BOOK_DESC,
                            M_BOOK.PUBLICATION_CODE,
                            M_BOOK.CATEGORY_CODE,
                            M_BOOK.ACTIVE_FLAG,
                            M_BOOK.REASON_FOR_INACTIVE
                            FROM M_BOOK
                            where BOOK_CODE = '" + new_code + "'";
            OracleDataReader odr = da.ExecuteReader(sql, CommandType.Text);
            if (odr.Read())
            {
                Book.BookCode = Convert.ToInt32(new_code);
                Book.BookDesc = odr["BOOK_DESC"].ToString();
                Book.PublicationCode = odr["PUBLICATION_CODE"].ToString();
                Book.CategoryCode = odr["CATEGORY_CODE"].ToString();
                Book.ActiveFlag = odr["ACTIVE_FLAG"].ToString();
                Book.ReasonForInactive = odr["REASON_FOR_INACTIVE"].ToString();
            }
        }

        public static string IssueBook(string sql, BLibraryPro.Book IssueBook)
        {

            DataAccess da = new DataAccess();
            da.ExecuteNonQuery(sql, CommandType.Text);
            return "Updated successfully to Database";
        }
    }
}
