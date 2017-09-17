using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using OneHundredCommonThings.ViewModel;
using OneHundredCommonThings.Model;
using Xamarin.Forms;

namespace OneHundredCommonThings.Screen
{
    public partial class TopicScreen : ContentPage
    {
        private TopicViewModel topicVM;

		public TopicScreen(string url = null)
		{
			InitializeComponent();
            ServiceUrl = url;
			Title = "Topic";
		}

		public string ServiceUrl
		{
			get { return base.GetValue(ServiceUrlProperty).ToString(); }
			set { base.SetValue(ServiceUrlProperty, value); }
		}

		public static readonly BindableProperty ServiceUrlProperty = BindableProperty.Create(
														 propertyName: "ServiceUrl",
														 returnType: typeof(string),
														 declaringType: typeof(TopicScreen),
														 defaultValue: null,
														 defaultBindingMode: BindingMode.TwoWay,
														 propertyChanged: serviceUrlPropertyChanged);

        public async Task LoadControl() {
			try
			{
                this.topicVM = new TopicViewModel(ServiceUrl);
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
		protected override void OnAppearing()
		{
            base.OnAppearing();
            LoadControl();
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
			var topic = e.Item as Topic;

            if (topic != null)
            {
                if (topic.Link != null) 
                {
                    await Navigation.PushAsync(new WebContentPage(topic.Link));
                }
                else
                {
                    string url = string.Format("https://onehundredcommon.herokuapp.com/api/content/{0}", topic.Children);
					await Navigation.PushAsync(new ContentScreen(url));
                }
            }
		}

		private static async void serviceUrlPropertyChanged(BindableObject bindable, object oldValue, object newValue)
		{
            var control = (TopicScreen)bindable;
			control.ServiceUrl = newValue.ToString();
			await control.LoadControl();
		}
    }
}
