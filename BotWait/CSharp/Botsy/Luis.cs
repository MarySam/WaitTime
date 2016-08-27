using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Botsy
{
    public class LuisMovieClient
    {
        //A method "ParseUserInput" that will take the user input and parse it using Luis.
        public static async Task<LuisInfo> ParseUserInput(string strInput)
        {
            string strRet = string.Empty;
            string strEscaped = Uri.EscapeDataString(strInput);

            using (var client = new HttpClient())
            {
                //URI is copied from our Luis Application.
                //Make sure to include "&q" at the end so that what the user types in (strEscaped) will be accepted as a query.
                string uri = "https://api.projectoxford.ai/luis/v1/application?id=27eb0729-4391-4880-a04f-dae911162fe1&subscription-key=a0794768387a459da34bab6f49878c1e&q=" + strEscaped;
                HttpResponseMessage msg = await client.GetAsync(uri);

                if (msg.IsSuccessStatusCode)
                {
                    string jsonResponse = await msg.Content.ReadAsStringAsync();
                    LuisInfo _Data = JsonConvert.DeserializeObject<LuisInfo>(jsonResponse);
                    return _Data;
                }
            }
            return null;
        }
    }
}