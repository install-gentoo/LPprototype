using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OracleClient;

namespace DLibraryPro
{
     public class FinePolicy
    {
         public static string SaveFinePolicy(BLibraryPro.FinePolicy ObjFinePolicy)
        {
            DataAccess da = new DataAccess();
            int new_id = Convert.ToInt32(BLibraryPro.MISC.GetNewID("FINEPOLICY"));

            string sql = string.Format(@"INSERT
                        INTO M_LIB_FINE_POLICY
                          (FINE_CODE ,FINE_DESC,FROM_DAYS,TO_DAYS,FINE_PER_DAY,ACTIVE_FLAG,REASON_FOR_INACTIVE)
                          VALUES('" + new_id + @"',' " + ObjFinePolicy.FinePolicyDesc + @"','" + ObjFinePolicy.FromDays + @"','" + ObjFinePolicy.ToDays + @"','" + ObjFinePolicy.FinePerDay + @"','" + ObjFinePolicy.ActiveFlag + @"','" + ObjFinePolicy.Reason + @"' ) "
             );

            da.ExecuteNonQuery(sql, CommandType.Text);
            return "Data added Successfully";
        }
         public static string UpdateFinePolicy(BLibraryPro.FinePolicy FinePolicy)
        {
            DataAccess da = new DataAccess();
            string sql = string.Format(@"UPDATE M_LIB_FINE_POLICY
                                        SET  FINE_DESC = '" + FinePolicy.FinePolicyDesc + @"',
                                        FROM_DAYS= '" + FinePolicy.FromDays + @"',
                                        TO_DAYS= '" + FinePolicy.ToDays + @"',
                                        FINE_PER_DAY= '" + FinePolicy.FinePerDay + @"',
                                        ACTIVE_FLAG= '" + FinePolicy.ActiveFlag + @"',
                                        REASON_FOR_INACTIVE= '" + FinePolicy.Reason + @"'
                                        WHERE FINE_CODE = '" + FinePolicy.FinePolicyCode + "'");
            da.ExecuteNonQuery(sql, CommandType.Text);
            return "Data Updated Successfully";
        }

         public static string DeleteFinePolicy(BLibraryPro.FinePolicy FinePolicy)
        {
            DataAccess da = new DataAccess();
            string sql = string.Format(@"DELETE FROM M_LIB_FINE_POLICY WHERE FINE_CODE = '" + FinePolicy.FinePolicyCode + "'");
            da.ExecuteNonQuery(sql, CommandType.Text);
            return "Data Deleted Successfully";
        }

         public static DataTable GetFinePolicies(string paramFilterValues)
        {
            DataAccess da = new DataAccess();
            string sql = @"SELECT M_LIB_FINE_POLICY.FINE_CODE,
                              M_LIB_FINE_POLICY.FINE_DESC,
                              M_LIB_FINE_POLICY.FROM_DAYS,
                              M_LIB_FINE_POLICY.TO_DAYS,
                              M_LIB_FINE_POLICY.FINE_PER_DAY,
                              M_LIB_FINE_POLICY.ACTIVE_FLAG,
                              M_LIB_FINE_POLICY.REASON_FOR_INACTIVE
                            FROM M_LIB_FINE_POLICY
                            where FINE_DESC like '%" + paramFilterValues + "%'";
            return da.ExecuteDataTable(sql, CommandType.Text);
        }

         public static void Populate(BLibraryPro.FinePolicy FinePolicy, string new_code)
        {
            DataAccess da = new DataAccess();
            string sql = @"SELECT M_LIB_FINE_POLICY.FINE_CODE,
                              M_LIB_FINE_POLICY.FINE_DESC,
                              M_LIB_FINE_POLICY.FROM_DAYS,
                              M_LIB_FINE_POLICY.TO_DAYS,
                              M_LIB_FINE_POLICY.FINE_PER_DAY,
                              M_LIB_FINE_POLICY.ACTIVE_FLAG,
                              M_LIB_FINE_POLICY.REASON_FOR_INACTIVE
                            FROM M_LIB_FINE_POLICY
                            where FINE_CODE = '" + new_code + "'";
            OracleDataReader odr = da.ExecuteReader(sql, CommandType.Text);
            if (odr.Read())
            {
                FinePolicy.FinePolicyCode = Convert.ToInt32(new_code);
                FinePolicy.FinePolicyDesc = odr["FINE_DESC"].ToString();
                FinePolicy.FromDays = Convert.ToInt32(odr["FROM_DAYS"]);
                FinePolicy.ToDays = Convert.ToInt32(odr["TO_DAYS"]);
                FinePolicy.FinePerDay = float.Parse(odr["FINE_PER_DAY"].ToString());
                FinePolicy.ActiveFlag = odr["ACTIVE_FLAG"].ToString();
                FinePolicy.Reason = odr["REASON_FOR_INACTIVE"].ToString();
            }
        }
    }
}
