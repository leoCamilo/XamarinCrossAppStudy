using System;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;

using Com.Squareup.Picasso;

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

            ImageView imageView = FindViewById<ImageView>(Resource.Id.imageView);

            // Use the Picasso jar library to load and display this image:
            Picasso.With(this).Load("http://i.imgur.com/DvpvklR.jpg").Into(imageView);
        }
    }
}