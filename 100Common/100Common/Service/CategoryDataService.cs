using System;
using OneHundredCommonThings.Model;

namespace OneHundredCommonThings.Service
{
    public class CategoryDataService : BaseDataService<Category>
    {
        public CategoryDataService() 
            : base("http://localhost:5000/api/category", "Category")
        {
        }
    }
}
