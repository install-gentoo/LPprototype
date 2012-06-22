using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OracleClient;

namespace DLibraryPro
{
    public class MemberType
    {
        public static string SaveMemberType(BLibraryPro.MemberType ObjMemberType)
        {
            DataAccess da = new DataAccess();
            string new_id = BLibraryPro.MISC.GetNewID("MEMBERTYPE");

            string sql = string.Format(@"INSERT
                        INTO M_LIBRARY_MEMBER_TYPE
                          (TYPE_CODE ,TYPE_DESC,ACTIVE_FLAG,REASON_FOR_INACTIVE)
                          VALUES('" + new_id + @"',' " + ObjMemberType.TypeDesc + @"','" + ObjMemberType.ActiveFlag + @"','" + ObjMemberType.Reason + @"' ) "
             );

            da.ExecuteNonQuery(sql, CommandType.Text);
            return "Data added Successfully";
        }
        public static string UpdateMemberType(BLibraryPro.MemberType memberType)
        {
            DataAccess da = new DataAccess();
            string sql = string.Format(@"UPDATE M_LIBRARY_MEMBER_TYPE
                                        SET  TYPE_DESC = '" + memberType.TypeDesc + @"',
                                         ACTIVE_FLAG= '" + memberType.ActiveFlag + @"',
                                         REASON_FOR_INACTIVE= '" + memberType.Reason + @"'
                                         WHERE TYPE_CODE = '" + memberType.MemberTypeCode + "'");
            da.ExecuteNonQuery(sql, CommandType.Text);
            return "Data Updated Successfully";
        }

        public static string DeleteMemberType(BLibraryPro.MemberType memberType)
        {
            DataAccess da = new DataAccess();
            string sql = string.Format(@"DELETE FROM M_LIBRARY_MEMBER_TYPE WHERE TYPE_CODE = '" + memberType.MemberTypeCode + "'");
            da.ExecuteNonQuery(sql, CommandType.Text);
            return "Data Deleted Successfully";
        }

        public static DataTable GetMemberTypes(string paramFilterValues)
        {
            DataAccess da = new DataAccess();
            string sql = @"SELECT M_LIBRARY_MEMBER_TYPE.TYPE_CODE,
                              M_LIBRARY_MEMBER_TYPE.TYPE_DESC,
                              M_LIBRARY_MEMBER_TYPE.ACTIVE_FLAG,
                              M_LIBRARY_MEMBER_TYPE.REASON_FOR_INACTIVE
                            FROM M_LIBRARY_MEMBER_TYPE
                            where TYPE_DESC like '%" + paramFilterValues + "%'";
            return da.ExecuteDataTable(sql, CommandType.Text);
        }

        public static void Populate(BLibraryPro.MemberType MemberType, string new_code)
        {
            DataAccess da = new DataAccess();
            string sql = @"SELECT M_LIBRARY_MEMBER_TYPE.TYPE_CODE,
                              M_LIBRARY_MEMBER_TYPE.TYPE_DESC,
                              M_LIBRARY_MEMBER_TYPE.ACTIVE_FLAG,
                              M_LIBRARY_MEMBER_TYPE.REASON_FOR_INACTIVE
                            FROM M_LIBRARY_MEMBER_TYPE
                            where TYPE_CODE = '" + new_code + "'";
            OracleDataReader odr = da.ExecuteReader(sql, CommandType.Text);
            if (odr.Read())
            {
                MemberType.MemberTypeCode = new_code;
                MemberType.TypeDesc = odr["TYPE_DESC"].ToString();
                MemberType.ActiveFlag = odr["ACTIVE_FLAG"].ToString();
                MemberType.Reason = odr["REASON_FOR_INACTIVE"].ToString();
            }
        }
    }
}
