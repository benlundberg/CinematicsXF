using SQLite;
using System.ComponentModel;

namespace CinematicsXF.Core
{
    public class MediaItem : INotifyPropertyChanged
    {
        [PrimaryKey]
        public int Id { get; set; }
        public bool IsFavourite { get; set; }
        public string Title { get; set; }
        public string Overview { get; set; }
        public string PosterPath { get; set; }
        public string BackdropPath { get; set; }
        public string Genres { get; set; }
        public string ReleaseDate { get; set; }
        public double VoteAverage { get; set; }
        public double Popularity { get; set; }
        public string Poster45 => ServiceConfig.GetPoster + "w45/" + PosterPath;
        public string Poster92 => ServiceConfig.GetPoster + "w92/" + PosterPath;
        public string Poster154 => ServiceConfig.GetPoster + "w154/" + PosterPath;
        public string Poster185 => ServiceConfig.GetPoster + "w185/" + PosterPath;
        public string Poster342 => ServiceConfig.GetPoster + "w342/" + PosterPath;
        public string Poster300 => ServiceConfig.GetPoster + "w300/" + PosterPath;
        public string Poster632 => ServiceConfig.GetPoster + "h632/" + PosterPath;
        public string Poster1280 => ServiceConfig.GetPoster + "w1280/" + PosterPath;
        public string PosterOriginal => ServiceConfig.GetPoster + "original/" + PosterPath;
        public string Backdrop => ServiceConfig.GetPoster + BackdropPath;

        public int InternalRating
        {
            get
            {
                if (VoteAverage <= 2)
                {
                    return 1;
                }
                else if (VoteAverage <= 4)
                {
                    return 2;
                }
                else if (VoteAverage <= 6)
                {
                    return 3;
                }
                else if (VoteAverage <= 8)
                {
                    return 4;
                }
                else
                {
                    return 5;
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
