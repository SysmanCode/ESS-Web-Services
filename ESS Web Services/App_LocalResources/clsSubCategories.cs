using System.Collections.Generic;

namespace ESS_Web_Services
{
    public class clsSubCategories
    {
        public List<SubCategoryList> ESSSubCategories { get; set; }

        public class SubCategoryList
        {
            public int CategoryID { get; set; }
            public string SubCategory { get; set; } = "";
        }
    }
}