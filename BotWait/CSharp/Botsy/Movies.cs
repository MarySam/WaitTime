using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Botsy
{
    public class Movies
    {
        //A method called "GetMovieInfo" that will get info on a movie based on the name of a movie.
        public static async Task<MovieInfo> GetMovieInfoAsync(string movieName)
        {
            if (string.IsNullOrWhiteSpace(movieName))
                return null;

            //The website below has movie data which are all in json format.
            //In order to search by title, we added "t=" to the end of the url so that when movieName gets passed in, 
            //..it will know to search by title in the movie database.
            string url = $"http://www.omdbapi.com/?t=" + movieName;

            string json;
            //Downloads all of the movie data and puts it in our variable called json.
            using (WebClient client = new WebClient())
            {
                json = await client.DownloadStringTaskAsync(url).ConfigureAwait(false);
            }
            //Converts the json file to a .NET object called "MovieInfo".
            return JsonConvert.DeserializeObject<MovieInfo>(json);
        }
    }
}