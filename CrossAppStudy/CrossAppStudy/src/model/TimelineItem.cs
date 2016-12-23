using System.IO;
using Xamarin.Forms;

namespace CrossAppStudy.model
{
    class TimelineItem
    {
        public string Txt { get; set; }
        public ImageSource Img { get; set; }

        public TimelineItem(string txt, string url) {
            var bytes = Rest.download(url);

            this.Txt = txt;
            this.Img = ImageSource.FromFile(url);
            // this.Img = ImageSource.FromStream(() => new MemoryStream(bytes.Result));
        }
    }
}
