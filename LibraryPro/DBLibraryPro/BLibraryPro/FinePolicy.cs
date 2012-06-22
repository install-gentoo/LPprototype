using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace BLibraryPro
{
    public class FinePolicy
    {
        public int FinePolicyCode { get; set; }
        public string FinePolicyDesc { get; set; }
        public int FromDays { get; set; }
        public int ToDays { get; set; }
        public float FinePerDay { get; set; }
        public string ActiveFlag { get; set; }
        public string Reason { get; set; }

        public FinePolicy() { }
        public FinePolicy(string new_code)
        {
            DLibraryPro.FinePolicy.Populate(this, new_code);
        }
       
        public string SaveFinePolicy()
        {
            return DLibraryPro.FinePolicy.SaveFinePolicy(this);   
        }

        public string UpdateFinePolicy()
        {
            return DLibraryPro.FinePolicy.UpdateFinePolicy(this);
        }

        public string DeleteFinePolicy()
        {
            return DLibraryPro.FinePolicy.DeleteFinePolicy(this);
        }

        public static DataTable GetFinePolicies(string paramFilterValues)
        {
            return DLibraryPro.FinePolicy.GetFinePolicies(paramFilterValues);
        }
    }
}
