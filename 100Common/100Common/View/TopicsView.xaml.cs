using System;
using System.Collections.Generic;
using Xamarin.Forms;
using OneHundredCommonThings.ViewModel;
using OneHundredCommonThings.Model;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

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

			foreach (var topic in this.topicVM.ModelCollection)
			{
				var label = new Label() { 
                    BackgroundColor = Color.Transparent,
                    VerticalOptions = LayoutOptions.CenterAndExpand,
                    HorizontalOptions = LayoutOptions.CenterAndExpand,
                    LineBreakMode = LineBreakMode.WordWrap,
                };
                label.Text = topic.Description;
                var boxView = new RelativeLayout()
                {
                    BackgroundColor=Color.Gray,
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
                scrollableContent.Children.Add(boxView);
			}

			this.Content = new ScrollView()
			{
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
