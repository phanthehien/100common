using System;
using OneHundredCommonThings.Model;

namespace OneHundredCommonThings.Service
{
    public class TopicDataService : BaseDataService<Topic>
    {
        public TopicDataService(string url = null, string propertyName = null) 
            : base(
                url ?? "http://www.mocky.io/v2/59bdf5ed3c0000b606529ff2", 
                propertyName ?? "Topic"
            )
        {
        }
    }
}
