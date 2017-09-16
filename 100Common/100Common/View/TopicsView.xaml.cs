using System;
using System.Collections.Generic;
using Xamarin.Forms;
using OneHundredCommonThings.Model;
using System.Collections.ObjectModel;

namespace OneHundredCommonThings.View
{
    public partial class TopicsView : ContentView
    {
        public TopicsView()
        {
            InitializeComponent();
            var topics = new [] { 
                new Topic() { TopicName = "Hien test"}
            };
            this.BindingContext = new ObservableCollection<Topic>(topics);
        }
    }
}
