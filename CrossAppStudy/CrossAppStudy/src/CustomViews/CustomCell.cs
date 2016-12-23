using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CrossAppStudy.CustomViews
{
    class CustomCell : ViewCell
    {
        /*
        public static readonly BindableProperty TextProperty = BindableProperty.Create("Text", typeof(string), typeof(CustomCell), "");
        public static readonly BindableProperty ImgProperty = BindableProperty.Create("Img", typeof(string), typeof(CustomCell), "");

        public string Name
        {
            get { return (string) GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public string Img
        {
            get { return (string)GetValue(ImgProperty); }
            set { SetValue(ImgProperty, value); }
        }
        */

        public CustomCell ()
        {
            Label txtLabel = new Label();
            Image imgLabel = new Image();

            txtLabel.SetBinding(Label.TextProperty, "Txt");
            imgLabel.SetBinding(Image.SourceProperty, "Img");

            View = new StackLayout {
                Children = {
                    imgLabel, txtLabel
                }
            };
        }
    }
}
