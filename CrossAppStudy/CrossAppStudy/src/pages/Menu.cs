using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace CrossAppStudy.pages
{
    public class Menu : TabbedPage
    {
        public Menu()
        {
            Title = "Menu";

            Children.Add(new Page1() { Title = "visual" });
            Children.Add(new Page2() { Title = "tools" });
            Children.Add(new Maps() { Title = "map" });
        }
    }
}
