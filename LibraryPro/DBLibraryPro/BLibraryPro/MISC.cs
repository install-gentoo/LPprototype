using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DLibraryPro;
using System.Data;
using System.Data.OracleClient;

namespace BLibraryPro
{
   public class MISC
    {
       /// <summary>
       /// Check if Database server is live
       /// </summary>
       /// <returns>True: if Server connection avil. False: Else</returns>
       public static bool IsServerLive()
       {
           //only here for checking database connection
           DLibraryPro.DataAccess dAccess = new DLibraryPro.DataAccess();
           try
           {
               dAccess.CheckConnection();
               return true;
           }
           catch { return false; }           
       }

       public static string GetNewID(string ruleName)
       {
           //
           DataAccess da = new DataAccess();
           OracleDataReader odr;
           decimal org_new_id= 0;
           string new_val = "";
           odr = da.ExecuteReader("select * from auto_num where rule_name = '"+ruleName+"'", CommandType.Text);
           if (odr.Read())
           {
               string prefix = odr["PRE_FIX"].ToString();
               string old_val = odr["CUR_VALUE"].ToString();
               string pad_char = odr["PAD_CHAR"].ToString();
               int len = Convert.ToInt32(odr["LENGTH"]);
               string pad_val="";
               

               for (int i = 0; i < len - prefix.Length-old_val.Length; i++)
               {
                   pad_val += pad_char;
               }
               org_new_id = Convert.ToDecimal(odr["CUR_VALUE"]);
               new_val = prefix + pad_val + org_new_id.ToString();
               //update to new
               odr.Close();
               da.ExecuteNonQuery("update auto_num set cur_value = cur_value+1 where rule_name = '" + ruleName + "' ", CommandType.Text);
           }
           return new_val;
       }
       // public static bool CheckID(string ID)
       // {
       //     if(GetNewID.text=


       //}
    }

     
}

