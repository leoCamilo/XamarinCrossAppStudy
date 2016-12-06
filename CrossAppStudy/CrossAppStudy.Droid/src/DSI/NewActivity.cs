using Android.Speech.Tts;
using Xamarin.Forms;
using System.Collections.Generic;
using Android.App;
using Android.Widget;
using Android.OS;

using CrossAppStudy.Droid;

[assembly: Xamarin.Forms.Dependency(typeof(NewActivity))]
namespace CrossAppStudy.Droid
{
    class NewActivity : ids.NewActivityInterface
    {
        public NewActivity() { }

        public void startNewActivity()
        {
            Toast.MakeText(Forms.Context, "Test", Android.Widget.ToastLength.Short).Show();
            Forms.Context.StartActivity(typeof(Accelerometer));
        }
    }
}