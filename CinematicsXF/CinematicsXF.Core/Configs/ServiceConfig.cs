namespace CinematicsXF.Core
{
    public class ServiceConfig
    {
        private static readonly string ApiKey = "50a24e67902b9a999d442a7f641a0a5c";

        private static readonly string BaseUrl = "https://api.themoviedb.org/3";

        public static string GetPoster = "https://image.tmdb.org/t/p/";

        public static string GetPopularTv = BaseUrl + "/tv/popular?api_key=" + ApiKey + "&page={0}";
       
        public static string GetOnAirTv = BaseUrl + "/tv/on_the_air?api_key=" + ApiKey + "&page={0}";
        
        public static string GetTopRatedTv = BaseUrl + "/tv/top_rated?api_key=" + ApiKey + "&page={0}";

        public static string GetTvDetail = BaseUrl + "/tv/{0}?api_key=" + ApiKey;

        public static string GetDiscoverMovies = BaseUrl + "/discover/movie?api_key=" + ApiKey + "&page={0}";

        public static string GetMovieDetail = BaseUrl + "/movie/{0}?api_key=" + ApiKey;

        public static string GetMovieCredits = BaseUrl + "/movie/{0}/credits?api_key=" + ApiKey;

        public static string GetCombinedCredits = BaseUrl + "/person/{0}/combined_credits?api_key=" + ApiKey;

        public static string GetPersonDetails = BaseUrl + "/person/{0}?api_key=" + ApiKey;

        public static string Search = BaseUrl + "/search/multi?query={0}&api_key=" + ApiKey;

        public static string GetTopRatedMovies = BaseUrl + "/movie/top_rated?api_key=" + ApiKey + "&page={0}";

        public static string GetUpcomingMovies = BaseUrl + "/movie/upcoming?api_key=" + ApiKey + "&page={0}";

        public static string GetNowPlayingMovies = BaseUrl + "/movie/now_playing?api_key=" + ApiKey + "&page={0}";

        public static string GetSimilarMovies = BaseUrl + "/movie/{0}/similar?api_key=" + ApiKey + "&language=en-US&page=1";
    }
}
