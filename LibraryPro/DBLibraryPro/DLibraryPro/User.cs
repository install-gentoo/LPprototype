using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OracleClient;

namespace DLibraryPro
{
  public class User
    {
      public static bool VerifyUser(BLibraryPro.User oparamObjBUser)
      {
          DataAccess da = new DataAccess();
          //da.AddParameter("idec",OracleType.Int32, 1);
          //da.AddParameter("p_UserName", OracleType.NVarChar, oparamObjBUser.Username);
          //da.AddParameter("p_Password", OracleType.NVarChar, oparamObjBUser.Password);
          //da.AddParameter("p_DATA", OracleType.Cursor, ParameterDirection.Output);
          string sql = @" select UserName from M_LOGIN
                           where USERNAME ='" + oparamObjBUser.Username + @"' 
                           and pass_word ='" + oparamObjBUser.Password + @"' 
                           and isactive=1";

          DataTable dt = new DataTable();
          dt = da.ExecuteDataTable(sql, CommandType.Text);
          if (dt.Rows.Count > 0)
          {
              return true;
          }
          else return false;
     }
      public static bool AddUser(BLibraryPro.User paramObjUser)
      {

          return false;
      }
    }
}
