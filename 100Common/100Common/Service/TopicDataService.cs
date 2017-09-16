using System;
using OneHundredCommonThings.Model;

namespace OneHundredCommonThings.Service
{
    public class TopicDataService : BaseDataService<Topic>
    {
        public TopicDataService(string url = null, string propertyName = null) 
            : base(
                url ?? "http://www.mocky.io/v2/59bd36dd3c0000c701529f91", 
                propertyName ?? "Topic"
            )
        {
        }
    }
}
