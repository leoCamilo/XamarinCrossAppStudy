using System;
using System.Net;
using System.IO;

using Xamarin.Forms;
using System.Threading.Tasks;

using CrossAppStudy.ids;
using CrossAppStudy.model;
using CrossAppStudy.CustomViews;

namespace CrossAppStudy.pages {
    public class Page2 : ContentPage {
        static Label result;

        public Page2() {

            var speak = new MyCustomBtn { Text = "Speak Native" };
            var call_btn = new MyCustomBtn() { Text = "call Uri" };
            var request_btn = new MyCustomBtn() { Text = "http Request" };
            var download_btn = new MyCustomBtn() { Text = "Download Img" };
            var newActivityBtn = new MyCustomBtn { Text = "Accelerometer" };
            var notificationBtn = new MyCustomBtn { Text = "Notification" };

            speak.Clicked += async (sender, e) => {
                string myinput = await InputBox(this.Navigation);
                DependencyService.Get<TestDependencyService>().Speak(myinput);
            };

            request_btn.Clicked += async (sender, e) => {
                await testMicrosoftPackageRequest();
                // showWaiting();
                // Page2.result.Text = await AccessTheWebAsync();
            };

            call_btn.Clicked += (sender, e) => Device.OpenUri(new Uri("tel://27996125988"));
            
            download_btn.Clicked += async (sender, e) => await downloadByUrl();
            newActivityBtn.Clicked += (sender, e) => DependencyService.Get<NewActivityInterface>().startNewActivity();
            notificationBtn.Clicked += (sender, e) => DependencyService.Get<NotificationService>().ShowNotificationScreen();

            result = new Label { Text = "null", VerticalOptions = LayoutOptions.FillAndExpand };

            Content = new StackLayout {
                Children = {
                    new StackLayout {
                        Children = {
                            new CustomStackLayout { Children = { request_btn, download_btn, speak} },
                            new CustomStackLayout { Children = { newActivityBtn, notificationBtn, call_btn } }
                        }
                    },

                    result
                }
            };
        }

        /*
        private void doRequest()
        {  
            var rxcui = "198440";
            var request = HttpWebRequest.Create(string.Format(@"http://rxnav.nlm.nih.gov/REST/RxTerms/rxcui/{0}/allinfo", rxcui));
            request.ContentType = "application/json";
            request.Method = "GET";

            using (HttpWebResponse response = ((HttpWebResponse) request).GetResponse() as HttpWebResponse)
            {
                if (response.StatusCode != HttpStatusCode.OK)
                    Console.Out.WriteLine("Error fetching data. Server returned status code: {0}", response.StatusCode);
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    var content = reader.ReadToEnd();
                    if (string.IsNullOrWhiteSpace(content))
                    {
                        Console.Out.WriteLine("Response contained empty body...");
                    }
                    else
                    {
                        Console.Out.WriteLine("Response Body: \r\n {0}", content);
                    }

                    Assert.NotNull(content);
                }
            }
        }

        private async Task<JsonValue> FetchWeatherAsync(string url)
        {
            // Create an HTTP web request using the URL:
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(new Uri(url));
            request.ContentType = "application/json";
            request.Method = "GET";

            // Send the request to the server and wait for the response:
            using (WebResponse response = await request.GetResponseAsync())
            {
                // Get a stream representation of the HTTP web response:
                using (Stream stream = response.GetResponseStream())
                {
                    // Use this stream to build a JSON document object:
                    JsonValue jsonDoc = await Task.Run(() => JsonObject.Load(stream));
                    Console.Out.WriteLine("Response: {0}", jsonDoc.ToString());

                    // Return the JSON document:
                    return jsonDoc;
                }
            }
        }

        async Task<string> AccessTheWebAsync()
        { 
            // You need to add a reference to System.Net.Http to declare client.
            HttpClient client = new HttpClient();
            Task<string> getStringTask = client.GetStringAsync(new Uri("http://www.churches.com.br:1337/feed/search/all/byUserId/1/0"));
            return await getStringTask;
        }
*/

        private async Task testMicrosoftPackageRequest()
        {
            // string url = "http://www.churches.com.br:1337/feed/search/all/byUserId/1/0";

            double lat = -20.2980488;
            double lng = -40.2937579;
            string url = "http://api.openweathermap.org/data/2.5/weather?lat=" + lat + "&lon=" + lng + "&appid=" + Rest.KEY;
            Task<string> http_result = Rest.request(url);
            Page2.result.Text = "loading...";
            Page2.result.Text = await http_result;
        }

        private async Task downloadByUrl()
        {
            string url = "http://forcaeinteligencia.com/wp-content/uploads/2013/09/batata-ou-batata-doce.png";
            // string url = "http://res.cloudinary.com/churches/image/upload/v1479304288/flktecyzx6rbmi3ttmi8.jpg";

            var bytes = await Rest.download(url);

            Image img = new Image();
            img.Source = ImageSource.FromStream(() => new MemoryStream(bytes));
            // Page2.img.Source = ImageSource.FromStream(() => new MemoryStream(bytes));

            await Navigation.PushAsync(new ContentPage() {
                Content = new StackLayout {
                    Children = { img }
                }
            });
        }

        private async void showWaiting() {
            Task http_req = doRequestAsync();
            Page2.result.Text += "loading with proposital delay (2 seconds)...";
            await http_req;
        }

        public async Task doRequestAsync() {
            await Task.Delay(2000);
            HttpWebRequest request = (HttpWebRequest) WebRequest.Create("http://www.churches.com.br:1337/feed/search/all/byUserId/1/0");
            // request.ContentType = "application/x-www-form-urlencoded";
            request.Method = "GET";
            request.BeginGetRequestStream(new AsyncCallback(GetRequestStreamCallback), request);
            Page2.result.Text = "|inside";
        }

        private static void GetRequestStreamCallback(IAsyncResult asynchronousResult) {
            HttpWebRequest request = (HttpWebRequest) asynchronousResult.AsyncState;
            Stream postStream = request.EndGetRequestStream(asynchronousResult);
            request.BeginGetResponse(new AsyncCallback(GetResponseCallback), request);
        }

        private static void GetResponseCallback(IAsyncResult asynchronousResult) {
            HttpWebRequest request = (HttpWebRequest) asynchronousResult.AsyncState;
            HttpWebResponse response = (HttpWebResponse) request.EndGetResponse(asynchronousResult);
            Stream streamResponse = response.GetResponseStream();
            StreamReader streamRead = new StreamReader(streamResponse);
            string responseString = streamRead.ReadToEnd();
            Page2.result.Text = responseString;
        }

        public static Task<string> InputBox(INavigation navigation)
        {
            // wait in this proc, until user did his input 
            var tcs = new TaskCompletionSource<string>();

            var lblTitle = new Label { Text = "Title", HorizontalOptions = LayoutOptions.Center, FontAttributes = FontAttributes.Bold };
            var lblMessage = new Label { Text = "Enter new text:" };
            var txtInput = new MyEntry { Text = "" };

            var btnOk = new Button
            {
                Text = "Ok",
                WidthRequest = 100,
                BackgroundColor = Color.FromRgb(0.8, 0.8, 0.8),
            };

            btnOk.Clicked += async (s, e) =>
            {
                // close page
                var result = txtInput.Text;
                await navigation.PopModalAsync();
                // pass result
                tcs.SetResult(result);
            };

            var btnCancel = new Button
            {
                Text = "Cancel",
                WidthRequest = 100,
                BackgroundColor = Color.FromRgb(0.8, 0.8, 0.8)
            };

            btnCancel.Clicked += async (s, e) =>
            {
                // close page
                await navigation.PopModalAsync();
                // pass empty result
                tcs.SetResult(null);
            };

            var slButtons = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Children = { btnOk, btnCancel },
            };

            var layout = new StackLayout
            {
                Padding = new Thickness(0, 40, 0, 0),
                VerticalOptions = LayoutOptions.StartAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                Orientation = StackOrientation.Vertical,
                Children = { lblTitle, lblMessage, txtInput, slButtons },
            };

            // create and show page
            var page = new ContentPage();
            page.Content = layout;
            navigation.PushModalAsync(page);
            // open keyboard
            txtInput.Focus();

            // code is waiting her, until result is passed with tcs.SetResult() in btn-Clicked
            // then proc returns the result
            return tcs.Task;
        }
    }
}
