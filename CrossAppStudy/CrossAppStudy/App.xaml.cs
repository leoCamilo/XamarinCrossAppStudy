using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using CrossAppStudy.pages;

namespace CrossAppStudy {
    public partial class App : Application {
        public App() {
            InitializeComponent();

            // MainPage = new CrossAppStudy.MainPage();
            MainPage = new NavigationPage(new Menu());
        }

        protected override void OnStart(){}
        protected override void OnSleep(){}
        protected override void OnResume(){}
    }
}
