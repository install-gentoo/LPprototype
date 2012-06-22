using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace BLibraryPro
{
    public class MemberType
    {
        public string MemberTypeCode { get; set; }
        public string TypeDesc { get; set; }
        public string ActiveFlag { get; set; }
        public string Reason { get; set; }

        public MemberType() { }
        public MemberType(string new_code)
        {
            DLibraryPro.MemberType.Populate(this, new_code);
        }
       
        public string SaveMemberType()
        {
            return DLibraryPro.MemberType.SaveMemberType(this);   
        }

        public string UpdateMemberType()
        {
            return DLibraryPro.MemberType.UpdateMemberType(this);
        }

        public string DeleteMemberType()
        {
            return DLibraryPro.MemberType.DeleteMemberType(this);
        }

        public static DataTable GetMemberTypes(string paramFilterValues)
        {
            return DLibraryPro.MemberType.GetMemberTypes(paramFilterValues);
        }
    }
}
