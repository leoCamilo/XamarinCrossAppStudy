using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace CrossAppStudy.pages
{
    public class RenderedPage : ContentPage
    {
        public String Heading;

        public RenderedPage() {
            Title = "Second Page";
            Heading = "This is the second page (Native activity)";
            // rendering of this page is done natively on each platform
        }
    }
}