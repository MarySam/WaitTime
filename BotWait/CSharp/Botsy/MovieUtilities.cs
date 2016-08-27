using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Botsy
{
    //Movie Methods
    public class MovieUtilities
    {
        public static async Task<string> GetMovieYear(string strMovie)
        {
            string strRet = string.Empty;
            MovieInfo movieInfo = await Movies.GetMovieInfoAsync(strMovie);
            // return our reply to the user
            if (null == movieInfo)
            {
                strRet = string.Format("Sorry, I couldn't find the movie: {0}", strMovie);
            }
            else
            {
                strRet = string.Format("I think the movie {0} was released in {1}", strMovie, movieInfo.Year);
            }

            return strRet;
        }

        public static async Task<string> GetMovieDirector(string strMovie)
        {
            string strRet = string.Empty;
            MovieInfo movieInfo = await Movies.GetMovieInfoAsync(strMovie);
            // return our reply to the user
            if (null == movieInfo)
            {
                strRet = string.Format("Sorry, I couldn't find the movie: {0}", strMovie);
            }
            else
            {
                strRet = string.Format("I think the movie {0} was directed by {1}", strMovie, movieInfo.Director);
            }

            return strRet;
        }

    }
}