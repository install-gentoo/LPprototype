using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OracleClient;


namespace DLibraryPro
{
    public class Publication
    {
        public static string SavePublication(BLibraryPro.Publication ObjPublication)
        {
            DataAccess da = new DataAccess();
            /////////////////////////////////////////////////
            //////////////////////////////
            string new_id = BLibraryPro.MISC.GetNewID("PUBLICATION");
            //if(string @"SELECT CATEGORY_CODE FROM M_BOOK_CATEGORY where CATEGORY_DESC=ObjCategory.CategoryDesc and REMARKS= ObjCategory.remarks;"=new_id)
            string sql = string.Format(@"INSERT
                        INTO M_PUBLICATION
                          (PUBLICATION_CODE ,PUBLICATION_DESC,COUNTRY_CODE,ESTABLISHED_DATE)
                          VALUES('" + new_id + @"','" + ObjPublication.PublicationDesc + @"','" + ObjPublication.CountryCode + @"',to_date('"+Convert.ToDateTime(ObjPublication.EstDate).ToShortDateString()+"','MM/dd/yyyy'))"
             );

            //                s

            //da.ExecuteAdapter(sql, CommandType.Text);
            da.ExecuteNonQuery(sql, CommandType.Text);
            return "Data added Successfully";
            //return "done";

        }



        public static DataTable GetPublication(string paramFilterValues)
        {
            DataAccess da = new DataAccess();
            string sql = @"SELECT M_PUBLICATION.PUBLICATION_CODE,
                              M_PUBLICATION.PUBLICATION_DESC,
                              M_PUBLICATION.COUNTRY_CODE,
                              M_PUBLICATION.ESTABLISHED_DATE
                            FROM M_PUBLICATION";
            if (paramFilterValues.Length > 0) { sql += " where publication_desc like '" + paramFilterValues + "%'"; }

            DataTable dt = da.ExecuteDataSet(sql, CommandType.Text).Tables[0];
            return dt;
        }
        public static void Populate(BLibraryPro.Publication publication, string new_code)
        {
            DataAccess da = new DataAccess();
            string sql = @"SELECT M_PUBLICATION.PUBLICATION_CODE,
                              M_PUBLICATION.PUBLICATION_DESC,
                              M_PUBLICATION.COUNTRY_CODE,
                              M_PUBLICATION.ESTABLISHED_DATE
                            FROM M_PUBLICATION
                            where publication_code = '" + new_code + "'";
            OracleDataReader odr = da.ExecuteReader(sql, CommandType.Text);
            if (odr.Read())
            {
                //publication.PublicationCode = new_code;
                publication.PublicationDesc = odr["PUBLICATION_DESC"].ToString();
                publication.CountryCode = odr["COUNTRY_CODE"].ToString();
                publication.EstDate = Convert.ToDateTime(odr["ESTABLISHED_DATE"].ToString());
            }
    }

        public static string UpdatePublication(BLibraryPro.Publication publication)
        {
            DataAccess da = new DataAccess();
            string sql = string.Format(@"UPDATE M_PUBLICATION
                                        SET  PUBLICATION_DESC = '" +publication.PublicationDesc+ @"',
                                       COUNTRY_CODE = '" + publication.CountryCode + @"',ESTABLISHED_DATE = to_date('" + Convert.ToDateTime(publication.EstDate).ToShortDateString() + "','MM/dd/yyyy')" + @"
                                         WHERE PUBLICATION_CODE = '" + publication.PublicationCode + @"'");
            da.ExecuteNonQuery(sql, CommandType.Text);
            return "Data Updated Successfully";
        }

       
           public static string DeletePublication(BLibraryPro.Publication Publication)
        {
            DataAccess da = new DataAccess();
            string sql = string.Format(@"DELETE FROM M_PUBLICATION WHERE PUBLICATION_CODE ='" + Publication.PublicationCode +@"'");
            da.ExecuteNonQuery(sql,CommandType.Text);
            return "Data Deleted Successfully";
        }
    }
}
