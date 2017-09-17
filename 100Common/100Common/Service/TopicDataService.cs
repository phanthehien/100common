using System;
using OneHundredCommonThings.Model;

namespace OneHundredCommonThings.Service
{
    public class TopicDataService : BaseDataService<Topic>
    {
        public TopicDataService(string url = null, string propertyName = null) 
            : base(
                url ?? "https://onehundredcommon.herokuapp.com/api/topic", 
                propertyName ?? "Topic"
            )
        {
        }
    }
}
