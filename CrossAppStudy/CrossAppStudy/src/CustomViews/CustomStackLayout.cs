using Xamarin.Forms;

namespace CrossAppStudy.CustomViews
{
    class CustomStackLayout : StackLayout
    {
        public CustomStackLayout ()
        {
            VerticalOptions = LayoutOptions.Start;
            HorizontalOptions = LayoutOptions.CenterAndExpand;
            Orientation = StackOrientation.Horizontal;
        }
    }
}
