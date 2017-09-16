using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using OneHundredCommonThings.Model;
using SQLite;
using Xamarin.Forms;

namespace OneHundredCommonThings.ViewModel
{
    public abstract class BaseServiceVM<T>: INotifyPropertyChanged where T: BaseModel, new()
    {
		private bool isBusy;
		public bool IsBusy
		{
			get
			{
				return isBusy;
			}
			set
			{
				isBusy = value;
				OnPropertyChanged();
			}
		}

        private DataService<T> dataService;

        public BaseServiceVM()
		{
            dataService = new DataService<T>();
		}

        public ObservableCollection<T> ModelCollection { get; set; }
		public event PropertyChangedEventHandler PropertyChanged;
		public void OnPropertyChanged([CallerMemberName]string name = "") =>
					PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

		public async Task PopulateDataAsync(bool refresh)
		{
			if (IsBusy)
			{
				return;
			}

			if (refresh == true && App.IsConnected)
			{
				try
				{
					IsBusy = true;
                    var onlineData = await dataService.PopulateDataOnlineAsync();
                    this.ModelCollection = new ObservableCollection<T>(onlineData);
				}
                catch(Exception)
				{
				}
				finally
				{
					IsBusy = false;
				}

                return;
			}

            await dataService.PopulateDataOfflineAsync();
		}
    }
}
