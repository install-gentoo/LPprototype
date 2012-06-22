using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace BLibraryPro
{
    public class Member
    {
        public string MemberCode { get; set; }
        public string TypeCode { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string CityCode { get; set; }
        public string RegisteredBy { get; set; }
        public DateTime RegisteredDate { get; set; }
        public string ActiveFlag { get; set; }
        public string InactiveReason { get; set; }
        public DateTime InactivedDate { get; set; }
        public string InactivatedBy { get; set; }
        
        public Member() { }
        public Member(string new_code)
        {
            DLibraryPro.Member.Populate(this, new_code);
        }

        public string SaveMember()
        {
            return DLibraryPro.Member.SaveMember(this);   
        }

        public string UpdateMember()
        {
            return DLibraryPro.Member.UpdateMember(this);
        }

        public string DeleteMembers()
        {
            return DLibraryPro.Member.DeleteMembers(this);
        }

        public static DataTable GetMembers(string paramFilterValues)
        {
            return DLibraryPro.Member.GetMembers(paramFilterValues);
        }

        public static DataTable GetMemberCardCodes(string paramFilterValues) { 
            return DLibraryPro.Member.GetMemberCardCodes(paramFilterValues);
        }

        
    }
}
