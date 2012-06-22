using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OracleClient;

namespace DLibraryPro
{
    public class BookSource
    {
        public static string SaveSource(BLibraryPro.BookSource ObjSource)
        {
            DataAccess da = new DataAccess();
            string new_id = BLibraryPro.MISC.GetNewID("SOURCE");
            
            string sql = string.Format(@"INSERT
                        INTO M_BOOK_SOURCE
                          (SOURCE_TYPE_CODE ,SOURCE_DESC,REMARKS)
                          VALUES('" + new_id + @"',' " + ObjSource.SourceDesc + @"','" + ObjSource.remarks + @"' ) "
             );

            da.ExecuteNonQuery(sql, CommandType.Text);
            return "Data added Successfully";
        }
        public static string UpdateSource(BLibraryPro.BookSource source)
        {
            DataAccess da = new DataAccess();
            string sql = string.Format(@"UPDATE M_BOOK_SOURCE
                                        SET  SOURCE_DESC = '" + source.SourceDesc + @"',
                                         REMARKS= '" + source.remarks + @"'
                                         WHERE SOURCE_TYPE_CODE = '" + source.SourceTypeCode + "'");
            da.ExecuteNonQuery(sql, CommandType.Text);
            return "Data Updated Successfully";
        }

        public static string DeleteSource(BLibraryPro.BookSource source)
        {
            DataAccess da = new DataAccess();
            string sql = string.Format(@"DELETE FROM M_BOOK_SOURCE WHERE SOURCE_TYPE_CODE = '" + source.SourceTypeCode + "'");
            da.ExecuteNonQuery(sql, CommandType.Text);
            return "Data Deleted Successfully";
        }

        public static DataTable GetSources(string paramFilterValues)
        {
            DataAccess da = new DataAccess();
            string sql = @"SELECT M_BOOK_SOURCE.SOURCE_TYPE_CODE,
                              M_BOOK_SOURCE.SOURCE_DESC,
                              M_BOOK_SOURCE.REMARKS
                            FROM M_BOOK_SOURCE
                            where SOURCE_DESC like '%" + paramFilterValues + "%'";
            return da.ExecuteDataTable(sql, CommandType.Text);
        }

        public static void Populate(BLibraryPro.BookSource source, string new_code)
        {
            DataAccess da = new DataAccess();
            string sql = @"SELECT M_BOOK_SOURCE.SOURCE_TYPE_CODE,
                              M_BOOK_SOURCE.SOURCE_DESC,
                              M_BOOK_SOURCE.REMARKS
                            FROM M_BOOK_SOURCE
                            where SOURCE_TYPE_CODE = '" + new_code + "'";
            OracleDataReader odr = da.ExecuteReader(sql, CommandType.Text);
            if (odr.Read())
            {
                source.SourceTypeCode = new_code;
                source.SourceDesc = odr["SOURCE_DESC"].ToString();
                source.remarks = odr["REMARKS"].ToString();
            }
        }
    }
}
