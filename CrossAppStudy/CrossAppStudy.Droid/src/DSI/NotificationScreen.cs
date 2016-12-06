using CrossAppStudy.Droid;
using CrossAppStudy.Droid.Pages;
using Xamarin.Forms;

[assembly: Dependency(typeof(NotificationScreen))]
namespace CrossAppStudy.Droid {
    class NotificationScreen : ids.NotificationService
    {
        public void ShowNotificationScreen() {
            Forms.Context.StartActivity(typeof(NotificationActivity));
        }
    }
}