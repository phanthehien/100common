using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using OneHundredCommonThings.Model;
using OneHundredCommonThings.ViewModel;
using Xamarin.Forms;

namespace OneHundredCommonThings.Screen
{
    public partial class CategoryScreen : ContentPage
    {
        private CategoryViewModel categoryVM;

		public CategoryScreen()
		{
			InitializeComponent();
			this.categoryVM = new CategoryViewModel();
		}

		protected async override void OnAppearing()
		{
			base.OnAppearing();
			//NavigationPage.SetHasNavigationBar(this, false);
			try
			{
				await this.categoryVM.PopulateDataAsync(true);
				this.BindingContext = this.categoryVM.ModelCollection;
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
				await this.categoryVM.PopulateDataAsync(true);
				this.BindingContext = this.categoryVM.ModelCollection;
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
			var selected = e.Item as Category;

            if (selected != null)
            {
                await Navigation.PushAsync(new EnglishScreen());
            }
		}
    }
}
