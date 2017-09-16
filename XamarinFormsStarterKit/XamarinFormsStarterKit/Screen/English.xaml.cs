using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using OneHundredCommonThings.ViewModel;
using Xamarin.Forms;

namespace OneHundredCommonThings.Screen
{
    public partial class English : ContentPage
    {
        private EnglishViewModel englishServiceVM;

		public English()
		{
			InitializeComponent();
			this.englishServiceVM = new EnglishViewModel();
		}

		protected async override void OnAppearing()
		{
			base.OnAppearing();
			this.BusyIndicator.IsVisible = true;
			this.BusyIndicator.IsRunning = true;
			try
			{
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
				this.BusyIndicator.IsVisible = false;
				this.BusyIndicator.IsRunning = false;
			}
		}

		private async Task LoadDataAsync()
		{
			this.BusyIndicator.IsVisible = true;
			this.BusyIndicator.IsRunning = true;
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
				this.BusyIndicator.IsVisible = false;
				this.BusyIndicator.IsRunning = false;
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
