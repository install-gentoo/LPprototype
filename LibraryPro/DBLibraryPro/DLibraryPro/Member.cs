using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OracleClient;

namespace DLibraryPro
{
    public class Member
    {
        public static string SaveMember(BLibraryPro.Member ObjMember)
        {
            DataAccess da = new DataAccess();
            string new_id = BLibraryPro.MISC.GetNewID("MEMBER");

            string sql = string.Format(@"INSERT
                        INTO M_MEMBER
                          (MEMBER_CODE,TYPE_CODE,FNAME,MNAME,LNAME,CITY_CODE,REGISTERED_BY,REGISTERED_DATE,ACTIVE_FLAG,REASON_FOR_INACTIVE,INACTIVE_DATE,INACTIVATED_BY)
                          VALUES('" + new_id + @"','" + ObjMember.TypeCode + @"','" + ObjMember.FirstName + @"','" + ObjMember.MiddleName + @"','" + ObjMember.LastName + @"','" + ObjMember.CityCode + @"','" + ObjMember.RegisteredBy + @"',to_date('" + Convert.ToDateTime(ObjMember.RegisteredDate).ToShortDateString() + "','MM/dd/yyyy'),'" + ObjMember.ActiveFlag + @"','" + ObjMember.InactiveReason + @"',to_date('" + Convert.ToDateTime(ObjMember.InactivedDate).ToShortDateString() + "','MM/dd/yyyy'),'" + ObjMember.InactivatedBy + @"' ) "
             );

            da.ExecuteNonQuery(sql, CommandType.Text);
            return "Data added Successfully";
        }
        public static string UpdateMember(BLibraryPro.Member Member)
        {
            DataAccess da = new DataAccess();

            string inactiveDate ="to_date('" + Convert.ToDateTime(Member.InactivedDate).ToShortDateString() + "','MM/dd/yyyy')";

            string sql = string.Format(@"UPDATE M_MEMBER
                                        SET  TYPE_CODE = '" + Member.TypeCode + @"',
                                        FNAME = '" + Member.FirstName + @"',
                                        MNAME = '" + Member.MiddleName + @"',
                                        LNAME = '" + Member.LastName + @"',
                                        CITY_CODE = '" + Member.CityCode + @"',
                                        ACTIVE_FLAG = '" + Member.ActiveFlag + @"',
                                        REASON_FOR_INACTIVE = '" + Member.InactiveReason + @"',
                                        INACTIVE_DATE = " + inactiveDate + @",
                                        INACTIVATED_BY = '" + Member.InactivatedBy + @"'
                                        WHERE MEMBER_CODE = '" + Member.MemberCode + "'");
            da.ExecuteNonQuery(sql, CommandType.Text);
            return "Data Updated Successfully";
        }

        public static string DeleteMembers(BLibraryPro.Member Member)
        {
            DataAccess da = new DataAccess();
            string sql = string.Format(@"DELETE FROM M_MEMBER WHERE MEMBER_CODE = '" + Member.MemberCode + "'");
            da.ExecuteNonQuery(sql, CommandType.Text);
            return "Data Deleted Successfully";
        }

        public static DataTable GetMembers(string paramFilterValues)
        {
            DataAccess da = new DataAccess();

//            string sql = @"SELECT M_MEMBER.MEMBER_CODE,
//                            M_MEMBER.TYPE_CODE,
//                            M_MEMBER.FNAME || ' ' || M_MEMBER.MNAME || ' ' || M_MEMBER.LNAME as NAME,
//                            M_MEMBER.CITY_CODE,
//                            M_MEMBER.REGISTERED_BY,
//                            M_MEMBER.REGISTERED_DATE,
//                            M_MEMBER.ACTIVE_FLAG,
//                            M_MEMBER.REASON_FOR_INACTIVE,
//                            M_MEMBER.INACTIVE_DATE,
//                            M_MEMBER.INACTIVATED_BY
//                            FROM M_MEMBER
//                            where FNAME like '%" + paramFilterValues + "%' OR MNAME like '%" + paramFilterValues + "%' OR LNAME like '%" + paramFilterValues + "%'";

            string sql = @"SELECT MEMBER_CODE,
            M_MEMBER.TYPE_CODE,
            M_MEMBER.FNAME || ' ' || M_MEMBER.MNAME || ' ' || M_MEMBER.LNAME as NAME,
            CITY_CODE,
            REGISTERED_BY,
            REGISTERED_DATE,
            M_MEMBER.ACTIVE_FLAG,
            M_MEMBER.REASON_FOR_INACTIVE,
            INACTIVE_DATE,
            INACTIVATED_BY,
            M_LIBRARY_MEMBER_TYPE.TYPE_DESC
            FROM M_MEMBER inner join M_LIBRARY_MEMBER_TYPE
            on M_MEMBER.TYPE_CODE =M_LIBRARY_MEMBER_TYPE.TYPE_CODE
            where FNAME like '%" + paramFilterValues + "%' OR MNAME like '%" + paramFilterValues + "%' OR LNAME like '%" + paramFilterValues + "%'";

            return da.ExecuteDataTable(sql, CommandType.Text);
        }

        public static DataTable GetMemberCardCodes(string paramFilterValues)
        {
            DataAccess da = new DataAccess();

            string sql = @"SELECT MEMBER_CARD_CODE, MEMBER_CODE FROM M_MEMBER_CARD";
            return da.ExecuteDataTable(sql, CommandType.Text);

        }
        public static void Populate(BLibraryPro.Member Member, string new_code)
        {

            DataAccess da = new DataAccess();
            string sql = @"SELECT M_MEMBER.MEMBER_CODE,
                            M_MEMBER.TYPE_CODE,
                            M_MEMBER.FNAME,
                            M_MEMBER.MNAME,
                            M_MEMBER.LNAME,
                            M_MEMBER.CITY_CODE,
                            M_MEMBER.REGISTERED_BY,
                            M_MEMBER.REGISTERED_DATE,
                            M_MEMBER.ACTIVE_FLAG,
                            M_MEMBER.REASON_FOR_INACTIVE,
                            M_MEMBER.INACTIVE_DATE,
                            M_MEMBER.INACTIVATED_BY
                            FROM M_MEMBER
                            where MEMBER_CODE = '" + new_code + "'";
            OracleDataReader odr = da.ExecuteReader(sql, CommandType.Text);
            if (odr.Read())
            {
                Member.MemberCode = new_code;
                Member.TypeCode = odr["TYPE_CODE"].ToString();
                Member.FirstName = odr["FNAME"].ToString();
                Member.MiddleName = odr["MNAME"].ToString();
                Member.LastName = odr["LNAME"].ToString();
                Member.CityCode = odr["CITY_CODE"].ToString();
                Member.RegisteredBy = odr["REGISTERED_BY"].ToString();
                Member.RegisteredDate = Convert.ToDateTime(odr["REGISTERED_DATE"].ToString());
                Member.ActiveFlag = odr["ACTIVE_FLAG"].ToString();
                Member.InactiveReason = odr["REASON_FOR_INACTIVE"].ToString();
                Member.InactivedDate = Convert.ToDateTime(odr["INACTIVE_DATE"].ToString());
                Member.InactivatedBy = odr["INACTIVATED_BY"].ToString();
            }
        }


    }
}
