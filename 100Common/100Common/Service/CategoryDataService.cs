using System;
using OneHundredCommonThings.Model;

namespace OneHundredCommonThings.Service
{
    public class CategoryDataService : BaseDataService<Category>
    {
        public CategoryDataService() 
            : base("http://www.mocky.io/v2/59bd313a3c00009201529f8d", "Category")
        {
        }
    }
}
