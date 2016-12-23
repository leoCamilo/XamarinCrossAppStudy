using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;
using CrossAppStudy.CustomViews;
using CrossAppStudy.model;

using System.Collections.ObjectModel;

namespace CrossAppStudy.pages {
    public class Page1 : ContentPage {
        public Page1() {
            
            var btnListView = new CustomBtn { Text = "ListView" };
            var btnRotation = new CustomBtn { Text = "Rotation" };
            var btnUListView = new CustomBtn { Text = "Updated ListView" };
            var native_btn = new CustomBtn() { Text = "new activity" };
            var btnEntry = new CustomBtn { Text = "Entry" };
            

            native_btn.Clicked += (sender, e) => Navigation.PushModalAsync(new RenderedPage());

            btnListView.Clicked += async (s, e) => {
                var page = new ContentPage();
                page.Content = populateList();
                await Navigation.PushAsync(page);
            };

            btnUListView.Clicked += async (s, e) => {
                var page = new ContentPage();
                page.Content = populateUList();
                await Navigation.PushAsync(page);
            };

            btnRotation.Clicked += async (s, e) => {
                var page = new ContentPage();
                page.Content = populateRotation();
                await Navigation.PushAsync(page);
            };

            btnEntry.Clicked += async (s, e) => {
                var page = new ContentPage();
                page.Content = populateEntry();
                await Navigation.PushAsync(page);
            };

            Content = new StackLayout {
                Padding = new Thickness(0, 0, 0, 20),
                Children = {
                    new CustomStackLayout { Children = { btnListView, btnEntry } },
                    new CustomStackLayout { Children = { btnRotation, native_btn } },
                    new CustomStackLayout { Children = { btnUListView } }
                }
            };
        }

        private ListView populateList()
        {
            var list = new ListView();

            list.IsPullToRefreshEnabled = true;
            list.Refreshing += async (sender, e) => await DisplayAlert("Loading", "Atualizando", "OK");

            var array = new string[50];

            for (int i = 0; i < 50; i++)
                array[i] = "item " + i;

            list.ItemsSource = array;
            list.ItemTapped += (sender, e) => {
                DisplayAlert("item", (string)((ListView)sender).SelectedItem, "OK");
                ((ListView)sender).SelectedItem = null;
            };

            return list;
        }

        private StackLayout populateUList ()
        {
            // string url = "http://forcaeinteligencia.com/wp-content/uploads/2013/09/batata-ou-batata-doce.png";
            // string url = "http://res.cloudinary.com/churches/image/upload/v1479304288/flktecyzx6rbmi3ttmi8.jpg";
            string url = "timelineImg.png";

            var list = new ListView(ListViewCachingStrategy.RecycleElement) { HasUnevenRows = true };
            list.ItemTemplate = new DataTemplate(typeof(CustomCell));

            var addBtn = new CustomBtn { Text = "add" };

            list.IsPullToRefreshEnabled = true;
            list.Refreshing += async (sender, e) => await DisplayAlert("Loading", "Atualizando", "OK");

            ObservableCollection<TimelineItem> strList = new ObservableCollection<TimelineItem>();
            list.ItemsSource = strList;

            for (int i = 0; i < 10; i++)
                strList.Add(new TimelineItem("text " + i, url));

            list.ItemTapped += (sender, e) => {
                DisplayAlert("item", (string)((ListView)sender).SelectedItem, "OK");
                ((ListView)sender).SelectedItem = null;
            };

            list.ItemAppearing += (sender, e) => {  // called to every element shown
                var listSize = strList.Count();
                var current = e.Item;
                var last = strList.ElementAt(listSize - 1);

                if (current == last) {
                    for (int i = 0; i < 10; i++)
                        strList.Add(new TimelineItem("New Pool " + i, url));
                }
            };

            addBtn.Clicked += (sender, e) => strList.Add(new TimelineItem("Novo", url));

            return new StackLayout {
                Children = { addBtn, list }
            };
        }

        private StackLayout populateEntry ()
        {
            var text1 = new Entry { Keyboard = Keyboard.Telephone, Placeholder = "Phone type" };
            var text2 = new Entry { Keyboard = Keyboard.Text, Placeholder = "Text type" };

            return new StackLayout {
                Children = { text1, text2 }
            };
        }

        private StackLayout populateRotation()
        {
            var slider1 = new Slider { };
            var slider2 = new Slider { };
            var slider3 = new Slider { };
            var label = new Label {
                Text = "TEST",
                FontSize = 20,
                VerticalTextAlignment = TextAlignment.Center,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            slider1.ValueChanged += (sender, e) => label.Rotation  = ((Slider) sender).Value * 100;
            slider2.ValueChanged += (sender, e) => label.RotationX = ((Slider) sender).Value * 100;
            slider3.ValueChanged += (sender, e) => label.RotationY = ((Slider) sender).Value * 100;

            return new StackLayout
            {
                Children = { slider1, slider2, slider3, label }
            };
        }
    }
}
