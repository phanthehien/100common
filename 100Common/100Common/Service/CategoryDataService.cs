using System;
using OneHundredCommonThings.Model;

namespace OneHundredCommonThings.Service
{
    public class CategoryDataService : BaseDataService<Category>
    {
        public CategoryDataService() 
            : base("http://www.mocky.io/v2/59bdfa243c0000b606529ff8", "Category")
        {
        }
    }
}
