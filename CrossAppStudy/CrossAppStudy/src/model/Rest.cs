using System.Threading.Tasks;
using System.Net.Http;

namespace CrossAppStudy.model
{
    public class Rest
    {
        static public string KEY = "e00e273f047c87c64cf9f676d8d04e69";
        static private HttpClient client = new HttpClient();

        public async static Task<byte[]> download(string url)
        {
            return await client.GetByteArrayAsync(url);
        }

        public async static Task<string> request(string url)
        {
            return await client.GetStringAsync(url);
        }
    }
}
