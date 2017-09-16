﻿using OneHundredCommonThings.Model;
using OneHundredCommonThings.Service;

namespace OneHundredCommonThings.ViewModel
{
    public class EnglishViewModel : BaseServiceVM<CommonEnglishSentence>
	{
        public EnglishViewModel() : base(new EnglishDataService()) {
            
        }
	}
}
