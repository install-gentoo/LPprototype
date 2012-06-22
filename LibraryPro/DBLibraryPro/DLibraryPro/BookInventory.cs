using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OracleClient;

namespace DLibraryPro
{
    public class BookInventory
    {
        public static string SaveBookInventory(BLibraryPro.BookInventory ObjBookInventory)
        {
            DataAccess da = new DataAccess();
            string new_id = BLibraryPro.MISC.GetNewID("BOOKINVENTORY");

            string sql = string.Format(@"INSERT
                        INTO M_BOOK_INVENTORY
                          (BOOK_SN,BOOK_LOT_NO,BOOK_CODE,ENTRY_DATE,ENTERED_BY)
                          VALUES('" + new_id + @"','" + ObjBookInventory.BookLotNo + @"','" + ObjBookInventory.BookCode + @"','" + ObjBookInventory.EntryDate + @"','" + ObjBookInventory.EntryBy + @"') "
             );

            da.ExecuteNonQuery(sql, CommandType.Text);
            return "Data added Successfully";
        }
        public static string UpdateBookInventory(BLibraryPro.BookInventory BookInventory)
        {
            DataAccess da = new DataAccess();

            string sql = string.Format(@"UPDATE M_BOOK_INVENTORY
                                        SET  BOOK_LOT_NO = '" + BookInventory.BookLotNo + @"',
                                        BOOK_CODE = '" + BookInventory.BookCode + @"',
                                        ENTRY_DATE = '" + BookInventory.EntryDate + @"',
                                        ENTERED_BY = '" + BookInventory.EntryBy + @"'
                                        WHERE BOOK_SN = '" + BookInventory.BookSn + "'");
            da.ExecuteNonQuery(sql, CommandType.Text);
            return "Data Updated Successfully";
        }

        public static string DeleteBookInventory(BLibraryPro.BookInventory BookInventory)
        {
            DataAccess da = new DataAccess();
            string sql = string.Format(@"DELETE FROM M_BOOK_INVENTORY WHERE BOOK_SN = '" + BookInventory.BookSn + "'");
            da.ExecuteNonQuery(sql, CommandType.Text);
            return "Data Deleted Successfully";
        }

        public static DataTable GetBookInventories(string paramFilterValues)
        {
            DataAccess da = new DataAccess();

            string sql = @"SELECT M_BOOK_INVENTORY.BOOK_SN,
            M_BOOK_INVENTORY.BOOK_LOT_NO,
            M_BOOK_INVENTORY.BOOK_CODE,
            M_BOOK_INVENTORY.ENTRY_DATE,
            M_BOOK_INVENTORY.ENTERED_BY
            FROM M_BOOK_INVENTORY";

            return da.ExecuteDataTable(sql, CommandType.Text);
        }

        public static void Populate(BLibraryPro.BookInventory BookInventory, string new_code)
        {
            DataAccess da = new DataAccess();
            string sql = @"SELECT M_BOOK_INVENTORY.BOOK_SN,
                            M_BOOK_INVENTORY.BOOK_LOT_NO,
                            M_BOOK_INVENTORY.BOOK_CODE,
                            M_BOOK_INVENTORY.ENTRY_DATE,
                            M_BOOK_INVENTORY.ENTERED_BY
                            FROM M_BOOK_INVENTORY 
                            where BOOK_SN = '" + new_code + "'";
            OracleDataReader odr = da.ExecuteReader(sql, CommandType.Text);
            if (odr.Read())
            {
                BookInventory.BookSn = new_code;
                BookInventory.BookLotNo = Convert.ToInt32(odr["BOOK_LOT_NO"].ToString());
                BookInventory.BookCode = Convert.ToInt32(odr["BOOK_CODE"].ToString());
                BookInventory.EntryDate = Convert.ToDateTime(odr["ENTRY_DATE"].ToString());
                BookInventory.EntryBy = odr["ENTERED_BY"].ToString();
            }
        }
    }
}
