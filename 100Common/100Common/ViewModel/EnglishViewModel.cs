using OneHundredCommonThings.Model;
using OneHundredCommonThings.Service;

namespace OneHundredCommonThings.ViewModel
{
    public class EnglishViewModel : BaseServiceVM<Content>
	{
        public EnglishViewModel(string serviceUrl = null) : base(new EnglishDataService(serviceUrl)) {
            
        }
	}
}
