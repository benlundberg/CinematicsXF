using System.ComponentModel;

namespace CinematicsXF.Core
{
    public class PersonItem : INotifyPropertyChanged
    {
        public PersonItem()
        {

        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Character { get; set; }
        public string Biography { get; set; }
        public string PlaceOfBirth { get; set; }
        public string Birthday { get; set; }
        public string KnownForDepartment { get; set; }
        public string AlsoKnownAs { get; set; }
        public string Job { get; set; }
        public string ProfilePath { get; set; }

        public string Poster45 => ServiceConfig.GetPoster + "w45/" + ProfilePath;
        public string Poster92 => ServiceConfig.GetPoster + "w92/" + ProfilePath;
        public string Poster154 => ServiceConfig.GetPoster + "w154/" + ProfilePath;
        public string Poster185 => ServiceConfig.GetPoster + "w185/" + ProfilePath;
        public string Poster342 => ServiceConfig.GetPoster + "w342/" + ProfilePath;
        public string Poster300 => ServiceConfig.GetPoster + "w300/" + ProfilePath;
        public string Poster632 => ServiceConfig.GetPoster + "h632/" + ProfilePath;
        public string Poster1280 => ServiceConfig.GetPoster + "w1280/" + ProfilePath;
        public string PosterOriginal => ServiceConfig.GetPoster + "original/" + ProfilePath;

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
