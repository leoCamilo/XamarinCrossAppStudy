using System;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;

namespace CrossAppStudy.Droid.Pages
{
    [Activity(Label = "From Notification", Theme = "@android:style/Theme.Material")]
    public class FromNotificationActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            string message = Intent.Extras.GetString("message", "");
            SetContentView(Resource.Layout.layoutFromNotification);
            TextView textView = FindViewById<TextView>(Resource.Id.textView1);
            textView.Text = String.Format("Passed to SecondActivity:\n {0}", message);
        }
    }
}