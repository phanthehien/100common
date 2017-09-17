using System;
using OneHundredCommonThings.Model;

namespace OneHundredCommonThings.Service
{
    public class EnglishDataService : BaseDataService<Content>
    {
        public EnglishDataService(string serviceUrl) 
            : base(serviceUrl ?? "https://onehundredcommon.herokuapp.com/api/english", "Content")
        {
        }
    }
}
