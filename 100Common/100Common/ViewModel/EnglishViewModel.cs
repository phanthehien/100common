using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using Xamarin.Forms;
using OneHundredCommonThings.Model;
using OneHundredCommonThings.Service;

namespace OneHundredCommonThings.ViewModel
{
    public class EnglishViewModel : BaseServiceVM<CommonEnglishSentence>
	{
        public EnglishViewModel() : base(new EnglishDataService()) {
            
        }
	}
}
