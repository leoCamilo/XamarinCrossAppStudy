using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

using CrossAppStudy.Droid.Renderers;
using CrossAppStudy.CustomViews;

[assembly: ExportRenderer (typeof(MyEntry), typeof(RenderTest))]
namespace CrossAppStudy.Droid.Renderers
{
    class RenderTest : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                Control.SetBackgroundColor(global::Android.Graphics.Color.LightGreen);
            }
        }
    }
}