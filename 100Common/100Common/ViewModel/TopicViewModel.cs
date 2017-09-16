using OneHundredCommonThings.Model;
using OneHundredCommonThings.Service;

namespace OneHundredCommonThings.ViewModel
{
    public class TopicViewModel : BaseServiceVM<Topic>
	{
        public TopicViewModel(string url = null, string propertyName = null)
            : base(new TopicDataService(url, propertyName)) {
            
        }
	}
}
