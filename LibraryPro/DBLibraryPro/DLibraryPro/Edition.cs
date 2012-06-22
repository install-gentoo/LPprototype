using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.OracleClient;
using System.Data;
using System.Text;
using DLibraryPro;

namespace DLibraryPro
{
   public  class Edition
    {
       public static string SaveEdition(BLibraryPro.Edition ObjEdition)
        {
            DataAccess da = new DataAccess();
            string new_id = BLibraryPro.MISC.GetNewID("EDITION");
            string sql = string.Format(@"INSERT
                        INTO M_EDITION
                          (EDITION_CODE ,EDITION_DESC,REMARKS)
                          VALUES('" + new_id + @"',' " + ObjEdition.EditionDesc + @"','" + ObjEdition.Remarks + @"' ) "
             );

            da.ExecuteNonQuery(sql, CommandType.Text);
            return "Data added Successfully";
        }

       public static string UpdateEditon(BLibraryPro.Edition ObjEdition)
        {
            DataAccess da = new DataAccess();
            string sql = string.Format(@"UPDATE M_EDITION
                                        SET  EDITION_DESC = '" + ObjEdition.EditionDesc + @"',
                                         REMARKS= '" + ObjEdition.Remarks + @"'
                                         WHERE EDITION_CODE = '" + ObjEdition.EditionCode + "'");
            da.ExecuteNonQuery(sql, CommandType.Text);
            return "Data Updated Successfully";
        }

       public static string DeleteEdition(BLibraryPro.Edition ObjEdition)
        {
            DataAccess da = new DataAccess();
            string sql = string.Format(@"DELETE FROM M_EDITION WHERE EDITION_CODE = '" + ObjEdition.EditionCode + "'");
            da.ExecuteNonQuery(sql, CommandType.Text);
            return "Data Deleted Successfully";
        }

       public static DataTable GetEditions(string paramFilterValues)
       {
           DataAccess da = new DataAccess();
           string sql = @"SELECT M_EDITION.EDITION_CODE,
                              M_EDITION.EDITION_DESC,
                              M_EDITION.REMARKS
                            FROM M_EDITION
                            where EDITION_DESC like '%" + paramFilterValues + "%'";
            return da.ExecuteDataTable(sql, CommandType.Text);
       }

       public static void Populate(BLibraryPro.Edition edition, string new_code)
       {
           DataAccess da = new DataAccess();
           string sql = @"SELECT M_EDITION.EDITION_CODE,
                              M_EDITION.EDITION_DESC,
                              M_EDITION.REMARKS
                            FROM M_EDITION
                            where EDITION_CODE = '" + new_code + "'";
           OracleDataReader odr = da.ExecuteReader(sql, CommandType.Text);
           if (odr.Read())
           {
               edition.EditionCode = new_code;
               edition.EditionDesc = odr["EDITION_DESC"].ToString();
               edition.Remarks = odr["REMARKS"].ToString();
           }
       }
    }
}
