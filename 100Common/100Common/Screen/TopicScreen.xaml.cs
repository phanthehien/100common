using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using OneHundredCommonThings.ViewModel;
using Xamarin.Forms;

namespace OneHundredCommonThings.Screen
{
    public partial class TopicScreen : ContentPage
    {
        private TopicViewModel topicVM;

		public TopicScreen()
		{
			InitializeComponent();
            this.topicVM = new TopicViewModel();
			Title = "Topic";
		}

		protected async override void OnAppearing()
		{
            base.OnAppearing();
			try
			{
				await this.topicVM.PopulateDataAsync(true);
				this.BindingContext = this.topicVM.ModelCollection;
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
                await this.topicVM.PopulateDataAsync(true);
                this.BindingContext = this.topicVM.ModelCollection;
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
