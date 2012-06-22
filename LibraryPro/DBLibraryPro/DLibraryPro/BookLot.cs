using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DLibraryPro;
using System.Data.OracleClient;
using System.Data;

namespace DLibraryPro
{
    public class BookLot
    {
        public static string SaveBookLot(BLibraryPro.BookLot ObjBookLot, string UserName, string Author)
        {
            DataAccess da = new DataAccess();
            string new_id = BLibraryPro.MISC.GetNewID("BOOKLOT");

            string sql = string.Format(@"INSERT
                        INTO M_BOOK_LOT
                          (BOOK_LOT_NO,BOOK_CODE,EDITION_CODE,YEAR_OF_PUBLICATION,ISBN,PRICE,NO_OF_PAGES,SOURCE_TYPE_CODE,RECEIVED_ON,NO_OF_BOOKS)
                          VALUES('" + new_id + @"','" + ObjBookLot.BookCode + @"','" + ObjBookLot.EditionCode + @"','" + ObjBookLot.YearOfPublication + @"','" + ObjBookLot.ISBN + @"','" + ObjBookLot.Price + @"','" + ObjBookLot.NoOfPage + @"','" + ObjBookLot.SourceTypeCode + @"',to_date('" + Convert.ToDateTime(ObjBookLot.ReceivedOn).ToShortDateString() + "','MM/dd/yyyy'),'" + ObjBookLot.NoOfBooks + @"') "
             );

            da.ExecuteNonQuery(sql, CommandType.Text);

            //insert data into inventory table
            string Inv_new_id = BLibraryPro.MISC.GetNewID("BOOKINVENTORY");

            string sqlInv = string.Format(@"INSERT
                        INTO M_BOOK_INVENTORY
                          (BOOK_SN,BOOK_LOT_NO,BOOK_CODE,ENTRY_DATE,ENTERED_BY)
                          VALUES('" + Inv_new_id + @"','" + new_id + @"','" + ObjBookLot.BookCode + @"',to_date('" + Convert.ToDateTime(ObjBookLot.ReceivedOn).ToShortDateString() + "','MM/dd/yyyy'),'" + UserName + @"') "
             );

            da.ExecuteNonQuery(sqlInv, CommandType.Text);

            //insert data into book author table
            string sqlBookAuthor = string.Format(@"INSERT
                        INTO M_BOOK_AUTHORS
                          (BOOK_LOT_NO,BOOK_CODE,AUTHOR_CODE)
                          VALUES('" + new_id + @"','" + ObjBookLot.BookCode + @"','" + Author + @"') "
             );

            da.ExecuteNonQuery(sqlBookAuthor, CommandType.Text);

            return "Data added Successfully";
        }
        public static string UpdateBookLot(BLibraryPro.BookLot BookLot)
        { 
            DataAccess da = new DataAccess();

            string reccivedOn = "to_date('" + Convert.ToDateTime(BookLot.ReceivedOn).ToShortDateString() + "','MM/dd/yyyy')";
            string sql = string.Format(@"UPDATE M_BOOK_LOT
                                        SET  BOOK_CODE = '" + BookLot.BookCode + @"',
                                        EDITION_CODE = '" + BookLot.EditionCode + @"',
                                        YEAR_OF_PUBLICATION = '" + BookLot.YearOfPublication + @"',
                                        ISBN = '" + BookLot.ISBN + @"',
                                        PRICE = '" + BookLot.Price + @"',
                                        NO_OF_PAGES = '" + BookLot.NoOfPage + @"',
                                        SOURCE_TYPE_CODE = '" + BookLot.SourceTypeCode + @"',
                                        RECEIVED_ON = " + reccivedOn + @",
                                        NO_OF_BOOKS = '" + BookLot.NoOfBooks + @"'
                                        WHERE BOOK_LOT_NO = '" + BookLot.BookLotNo + "'");
            da.ExecuteNonQuery(sql, CommandType.Text);

            string sqlInv = string.Format(@"UPDATE M_BOOK_INVENTORY
                                        SET BOOK_CODE = '" + BookLot.BookCode + @"'
                                        WHERE BOOK_LOT_NO = '" + BookLot.BookLotNo + "'");
            da.ExecuteNonQuery(sqlInv, CommandType.Text);
            
            return "Data Updated Successfully";
        }

        public static string DeleteBookLot(BLibraryPro.BookLot BookLot)
        {
            DataAccess da = new DataAccess();
            string sql = string.Format(@"DELETE FROM M_BOOK_LOT WHERE BOOK_LOT_NO = '" + BookLot.BookLotNo + "'");
            da.ExecuteNonQuery(sql, CommandType.Text);
            
            return "Data Deleted Successfully";
        }

        public static DataTable GetBookLots(string paramFilterValues)
        {
            DataAccess da = new DataAccess();

            string sql = @"SELECT M_BOOK_LOT.BOOK_LOT_NO,
            M_BOOK_LOT.BOOK_CODE,
            M_BOOK_LOT.EDITION_CODE,
            M_BOOK_LOT.YEAR_OF_PUBLICATION,
            M_BOOK_LOT.ISBN,
            M_BOOK_LOT.PRICE,
            M_BOOK_LOT.NO_OF_PAGES,
            M_BOOK_LOT.SOURCE_TYPE_CODE,
            M_BOOK_LOT.RECEIVED_ON,
            M_BOOK_LOT.NO_OF_BOOKS,
            M_BOOK.BOOK_DESC,
            M_EDITION.EDITION_DESC,
            M_BOOK_SOURCE.SOURCE_DESC
            FROM M_BOOK_LOT inner join M_BOOK on M_BOOK.BOOK_CODE=M_BOOK_LOT.BOOK_CODE inner join M_EDITION on M_EDITION.EDITION_CODE=M_BOOK_LOT.EDITION_CODE
            inner join M_BOOK_SOURCE on M_BOOK_SOURCE.SOURCE_TYPE_CODE=M_BOOK_LOT.SOURCE_TYPE_CODE";

            return da.ExecuteDataTable(sql, CommandType.Text);
        }

        public static void Populate(BLibraryPro.BookLot BookLot, string new_code)
        {
            DataAccess da = new DataAccess();
            string sql = @"SELECT M_BOOK_LOT.BOOK_LOT_NO,
                            M_BOOK_LOT.BOOK_CODE,
                            M_BOOK_LOT.EDITION_CODE,
                            M_BOOK_LOT.YEAR_OF_PUBLICATION,
                            M_BOOK_LOT.ISBN,
                            M_BOOK_LOT.PRICE,
                            M_BOOK_LOT.NO_OF_PAGES,
                            M_BOOK_LOT.SOURCE_TYPE_CODE,
                            M_BOOK_LOT.RECEIVED_ON,
                            M_BOOK_LOT.NO_OF_BOOKS
                            FROM M_BOOK_LOT 
                            where BOOK_LOT_NO = '" + new_code + "'";
            OracleDataReader odr = da.ExecuteReader(sql, CommandType.Text);
            if (odr.Read())
            {
                BookLot.BookLotNo = Convert.ToInt32(new_code);
                BookLot.BookCode = Convert.ToInt32(odr["BOOK_CODE"].ToString());
                BookLot.EditionCode = odr["EDITION_CODE"].ToString();
                BookLot.YearOfPublication = Convert.ToInt32(odr["YEAR_OF_PUBLICATION"].ToString());
                BookLot.ISBN = odr["ISBN"].ToString();
                BookLot.Price = float.Parse(odr["PRICE"].ToString());
                BookLot.NoOfPage = Convert.ToInt32(odr["NO_OF_PAGES"].ToString());
                BookLot.SourceTypeCode = odr["SOURCE_TYPE_CODE"].ToString();
                BookLot.ReceivedOn = Convert.ToDateTime(odr["RECEIVED_ON"].ToString());
                BookLot.NoOfBooks = Convert.ToInt32(odr["NO_OF_BOOKS"].ToString());
            }
        }
    }
}
