using System;
using OneHundredCommonThings.Model;

namespace OneHundredCommonThings.Service
{
    public class EnglishDataService : BaseDataService<CommonEnglishSentence>
    {
        public EnglishDataService() 
            : base("http://www.mocky.io/v2/59bd2e0b3c00006501529f87", "CommonEnglishSentence")
        {
        }
    }
}
