using OneHundredCommonThings.Model;
using OneHundredCommonThings.Service;

namespace OneHundredCommonThings.ViewModel
{
    public class CategoryViewModel : BaseServiceVM<Category>
	{
        public CategoryViewModel() : base(new CategoryDataService()) {
            
        }
	}
}
