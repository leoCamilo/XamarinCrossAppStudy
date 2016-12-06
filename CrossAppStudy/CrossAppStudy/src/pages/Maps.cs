using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace CrossAppStudy.pages {
    public class Maps : ContentPage {
        public Maps() {
            var pos = new Position(41.3855125, 2.1250903);
            var maps = new Map(MapSpan.FromCenterAndRadius(pos, Distance.FromKilometers(0.3))) {
                VerticalOptions = LayoutOptions.FillAndExpand
            };

            var pin = new Pin {
                Type = PinType.Place,
                Position = pos,
                Label = "custom pin",
                Address = "custom detail info"
            };

            maps.Pins.Add(pin);

            Content = new StackLayout {
                Children = {
                    maps
                }
            };
        }
    }
}
