using System;
using System.Collections.Generic;
using Xamarin.Forms;
using OneHundredCommonThings.ViewModel;
using OneHundredCommonThings.Model;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using OneHundredCommonThings.Screen;
using OneHundredCommonThing.Constants;

namespace OneHundredCommonThings.View
{
    public partial class TopicsView : ContentView
    {
        private TopicViewModel topicVM;

		public string TopicUrl
		{
			get { return base.GetValue(TopicUrlProperty).ToString(); }
			set { base.SetValue(TopicUrlProperty, value); }
		} 

		public static readonly BindableProperty TopicUrlProperty = BindableProperty.Create(
														 propertyName: "TopicUrl",
														 returnType: typeof(string),
														 declaringType: typeof(TopicsView),
														 defaultValue: "",
														 defaultBindingMode: BindingMode.TwoWay,
														 propertyChanged: topicUrlPropertyChanged);
        
		public TopicsView()
        {
            InitializeComponent();
        }


		public async Task LoadControl()
		{
            this.topicVM = new TopicViewModel(TopicUrl, "Topic");
			await this.topicVM.PopulateDataAsync(true);

			var scrollableContent = new StackLayout()
			{
				Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.StartAndExpand
			};

            if (this.topicVM.ModelCollection != null)
            {
                foreach (var topic in this.topicVM.ModelCollection)
                {
                    var label = new Label()
                    {
                        TextColor = Colors.TextColor,
                        BackgroundColor = Color.Transparent,
                        VerticalOptions = LayoutOptions.Center,
                        HorizontalOptions = LayoutOptions.Center,
                        LineBreakMode = LineBreakMode.WordWrap,
                        HorizontalTextAlignment= TextAlignment.Center
                    };
                    label.Text = topic.Description;
                    var boxView = new RelativeLayout()
                    {
                        BackgroundColor = Colors.BoxColor,
                        WidthRequest = 120,
                        HeightRequest = 120,
                        VerticalOptions = LayoutOptions.CenterAndExpand,
                        HorizontalOptions = LayoutOptions.CenterAndExpand,
                    };

                    boxView.Children.Add(
                        label,
                        xConstraint: Constraint.RelativeToParent((parent) =>
                        {
                            return ((parent.Width - label.Width) / 2);
                        }),
                        yConstraint: Constraint.RelativeToParent((parent) =>
                        {
                            return ((parent.Height - label.Height) / 2);
                        })
                    );
                    var boxViewTap = new TapGestureRecognizer();
                    string children = topic.Children;
					boxViewTap.Command = new Command(() => {
						var navigation = Application.Current.MainPage.Navigation;
                        string url = string.Format("https://onehundredcommon.herokuapp.com/api/content/{0}", children);
						navigation.PushAsync(new ContentScreen(url));
					});
                    boxView.GestureRecognizers.Add(boxViewTap);
                    scrollableContent.Children.Add(boxView);
                }
            }

			this.Content = new ScrollView()
			{
                Padding = new Thickness(5, 5, 5, 5),
                BackgroundColor= Colors.PaddingColor,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Orientation = ScrollOrientation.Horizontal,
				Content = scrollableContent,
			};
        }

		private static async void topicUrlPropertyChanged(BindableObject bindable, object oldValue, object newValue)
		{
			var control = (TopicsView)bindable;
            control.TopicUrl = newValue.ToString();
			await control.LoadControl();
		}
    }
}
