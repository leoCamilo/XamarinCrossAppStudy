using Xamarin.Forms;

namespace CrossAppStudy.CustomViews
{
    class MyCustomBtn : Button
    {
        private const int BUTTON_BORDER_WIDTH = 1;
        private const int BUTTON_HEIGHT = 50;
        private const int BUTTON_HEIGHT_WP = 120;
        private const int BUTTON_HALF_HEIGHT = 44;
        private const int BUTTON_HALF_HEIGHT_WP = 72;
        private const int BUTTON_WIDTH = 100;
        private const int BUTTON_WIDTH_WP = 144;

        public MyCustomBtn ()
        {
            BackgroundColor = Color.Black;
            HorizontalOptions = LayoutOptions.Center;
            BackgroundColor = Color.Accent;
            BorderColor = Color.Black;
            TextColor = Color.White;
            BorderWidth = BUTTON_BORDER_WIDTH;
            BorderRadius = Device.OnPlatform(BUTTON_HALF_HEIGHT, BUTTON_HALF_HEIGHT, BUTTON_HALF_HEIGHT_WP);
            HeightRequest = Device.OnPlatform(BUTTON_HEIGHT, BUTTON_HEIGHT, BUTTON_HEIGHT_WP);
            MinimumHeightRequest = Device.OnPlatform(BUTTON_HEIGHT, BUTTON_HEIGHT, BUTTON_HEIGHT_WP);
            // WidthRequest = Device.OnPlatform(BUTTON_WIDTH, BUTTON_WIDTH, BUTTON_WIDTH_WP);
            // MinimumWidthRequest = Device.OnPlatform(BUTTON_WIDTH, BUTTON_WIDTH, BUTTON_WIDTH_WP);
        }
    }
}
