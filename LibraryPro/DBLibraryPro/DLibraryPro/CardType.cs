using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DLibraryPro;
using System.Data;
using System.Data.OracleClient;

namespace DLibraryPro
{
   public class CardType
    {
       public static string SaveCardType(BLibraryPro.CardType ObjCardType)
        {
            DataAccess da = new DataAccess();
            string new_id = BLibraryPro.MISC.GetNewID("CARDTYPE");

            string sql = string.Format(@"INSERT
                        INTO M_MEMBER_CARD_TYPES
                          (CARD_TYPE ,TYPE_DESC,NO_OF_BOOKS_ALLOWED)
                          VALUES('" + new_id + @"',' " + ObjCardType.TypeDesc + @"','" + ObjCardType.BooksAllowed + @"' ) "
             );

            da.ExecuteNonQuery(sql, CommandType.Text);
            return "Data added Successfully";
        }
       public static string UpdateCardType(BLibraryPro.CardType cardType)
        {
            DataAccess da = new DataAccess();
            string sql = string.Format(@"UPDATE M_MEMBER_CARD_TYPES
                                        SET  TYPE_DESC = '" + cardType.TypeDesc + @"',
                                         NO_OF_BOOKS_ALLOWED= '" + cardType.BooksAllowed + @"'
                                         WHERE CARD_TYPE = '" + cardType.CardTypeCode + "'");
            da.ExecuteNonQuery(sql, CommandType.Text);
            return "Data Updated Successfully";
        }

       public static string DeleteCardType(BLibraryPro.CardType cardType)
        {
            DataAccess da = new DataAccess();
            string sql = string.Format(@"DELETE FROM M_MEMBER_CARD_TYPES WHERE CARD_TYPE = '" + cardType.CardTypeCode + "'");
            da.ExecuteNonQuery(sql, CommandType.Text);
            return "Data Deleted Successfully";
        }

       public static DataTable GetCardTypes(string paramFilterValues)
        {
            DataAccess da = new DataAccess();
            string sql = @"SELECT M_MEMBER_CARD_TYPES.CARD_TYPE,
                              M_MEMBER_CARD_TYPES.TYPE_DESC,
                              M_MEMBER_CARD_TYPES.NO_OF_BOOKS_ALLOWED
                            FROM M_MEMBER_CARD_TYPES
                            where TYPE_DESC like '%" + paramFilterValues + "%'";
            return da.ExecuteDataTable(sql, CommandType.Text);
        }

       public static void Populate(BLibraryPro.CardType cardType, string new_code)
        {
            DataAccess da = new DataAccess();
            string sql = @"SELECT M_MEMBER_CARD_TYPES.CARD_TYPE,
                              M_MEMBER_CARD_TYPES.TYPE_DESC,
                              M_MEMBER_CARD_TYPES.NO_OF_BOOKS_ALLOWED
                            FROM M_MEMBER_CARD_TYPES
                            where CARD_TYPE = '" + new_code + "'";
            OracleDataReader odr = da.ExecuteReader(sql, CommandType.Text);
            if (odr.Read())
            {
                cardType.CardTypeCode = new_code;
                cardType.TypeDesc = odr["TYPE_DESC"].ToString();
                cardType.BooksAllowed = Convert.ToInt32(odr["NO_OF_BOOKS_ALLOWED"]);
            }
        }
    }
}
