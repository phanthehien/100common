using System;
using OneHundredCommonThings.Model;

namespace OneHundredCommonThings.Service
{
    public class CategoryDataService : BaseDataService<Category>
    {
        public CategoryDataService() 
            : base("https://onehundredcommon.herokuapp.com/api/category", "Category")
        {
        }
    }
}
