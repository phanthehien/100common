using System;
using OneHundredCommonThings.Model;

namespace OneHundredCommonThings.Service
{
    public class EnglishDataService : BaseDataService<CommonEnglishSentence>
    {
        public EnglishDataService() 
            : base("https://onehundredcommon.herokuapp.com/api/english", "CommonEnglishSentence")
        {
        }
    }
}
