using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using OneHundredCommonThings.ViewModel;
using Xamarin.Forms;

namespace OneHundredCommonThings.Screen
{
    public partial class EnglishScreen : ContentPage
    {
        private EnglishViewModel englishServiceVM;

		public EnglishScreen()
		{
			InitializeComponent();
			this.englishServiceVM = new EnglishViewModel();
		}

		protected async override void OnAppearing()
		{
            base.OnAppearing();
			try
			{
				await this.englishServiceVM.PopulateDataAsync(true);
				this.BindingContext = this.englishServiceVM.ModelCollection;
			}
			catch (InvalidOperationException ex)
			{
				await DisplayAlert("Error", "Check your network connection.", "OK");
				return;
			}
			catch (Exception ex)
			{
				await DisplayAlert("Error", ex.Message, "OK");
				return;
			}
			finally
			{
			}
		}

		private async Task LoadDataAsync()
		{
			try
			{
                await this.englishServiceVM.PopulateDataAsync(true);
                this.BindingContext = this.englishServiceVM.ModelCollection;
			}
			catch (InvalidOperationException)
			{
				await DisplayAlert("Error", "Check your network connection.", "OK");
				return;
			}
			catch (Exception ex)
			{
				await DisplayAlert("Error", ex.Message, "OK");
				return;
			}
			finally
			{
				
			}
		}

		private async void RssView_Refreshing(object sender, EventArgs e)
		{
			await LoadDataAsync();
		}

		private async void RefreshButton_Clicked(object sender, EventArgs e)
		{
			await LoadDataAsync();
		}

		private async void RssView_ItemTapped(object sender, ItemTappedEventArgs e)
		{
			var selected = e.Item as Item;

			if (selected != null)
				await Navigation.PushAsync(new WebContentPage(selected.Link));
		}
    }
}
