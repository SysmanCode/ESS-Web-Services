using System.Collections.Generic;

namespace ESS_Web_Services
{
    public class clsCategories
    {
        public List<CategoryList> ESSCategories { get; set; }

        public class CategoryList
        {
            public int ID { get; set; }
            public string Category { get; set; } = "";
        }
    }
}