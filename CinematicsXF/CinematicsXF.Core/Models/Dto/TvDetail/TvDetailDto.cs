namespace CinematicsXF.Core.Dto.TvDetail
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class TvDetailDto
    {
        [JsonProperty("backdrop_path", NullValueHandling = NullValueHandling.Ignore)]
        public string BackdropPath { get; set; }

        [JsonProperty("created_by", NullValueHandling = NullValueHandling.Ignore)]
        public List<CreatedBy> CreatedBy { get; set; }

        [JsonProperty("episode_run_time", NullValueHandling = NullValueHandling.Ignore)]
        public List<long> EpisodeRunTime { get; set; }

        [JsonProperty("first_air_date", NullValueHandling = NullValueHandling.Ignore)]
        public string FirstAirDate { get; set; }

        [JsonProperty("genres", NullValueHandling = NullValueHandling.Ignore)]
        public List<Genre> Genres { get; set; }

        [JsonProperty("homepage", NullValueHandling = NullValueHandling.Ignore)]
        public string Homepage { get; set; }

        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public int? Id { get; set; }

        [JsonProperty("in_production", NullValueHandling = NullValueHandling.Ignore)]
        public bool? InProduction { get; set; }

        [JsonProperty("languages", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> Languages { get; set; }

        [JsonProperty("last_air_date", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? LastAirDate { get; set; }

        [JsonProperty("last_episode_to_air", NullValueHandling = NullValueHandling.Ignore)]
        public LastEpisodeToAir LastEpisodeToAir { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("next_episode_to_air")]
        public object NextEpisodeToAir { get; set; }

        [JsonProperty("networks", NullValueHandling = NullValueHandling.Ignore)]
        public List<Network> Networks { get; set; }

        [JsonProperty("number_of_episodes", NullValueHandling = NullValueHandling.Ignore)]
        public long? NumberOfEpisodes { get; set; }

        [JsonProperty("number_of_seasons", NullValueHandling = NullValueHandling.Ignore)]
        public int? NumberOfSeasons { get; set; }

        [JsonProperty("origin_country", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> OriginCountry { get; set; }

        [JsonProperty("original_language", NullValueHandling = NullValueHandling.Ignore)]
        public string OriginalLanguage { get; set; }

        [JsonProperty("original_name", NullValueHandling = NullValueHandling.Ignore)]
        public string OriginalName { get; set; }

        [JsonProperty("overview", NullValueHandling = NullValueHandling.Ignore)]
        public string Overview { get; set; }

        [JsonProperty("popularity", NullValueHandling = NullValueHandling.Ignore)]
        public double? Popularity { get; set; }

        [JsonProperty("poster_path", NullValueHandling = NullValueHandling.Ignore)]
        public string PosterPath { get; set; }

        [JsonProperty("production_companies", NullValueHandling = NullValueHandling.Ignore)]
        public List<Network> ProductionCompanies { get; set; }

        [JsonProperty("seasons", NullValueHandling = NullValueHandling.Ignore)]
        public List<Season> Seasons { get; set; }

        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        public string Status { get; set; }

        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; }

        [JsonProperty("vote_average", NullValueHandling = NullValueHandling.Ignore)]
        public double? VoteAverage { get; set; }

        [JsonProperty("vote_count", NullValueHandling = NullValueHandling.Ignore)]
        public long? VoteCount { get; set; }
    }

    public partial class CreatedBy
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public long? Id { get; set; }

        [JsonProperty("credit_id", NullValueHandling = NullValueHandling.Ignore)]
        public string CreditId { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("gender", NullValueHandling = NullValueHandling.Ignore)]
        public long? Gender { get; set; }

        [JsonProperty("profile_path", NullValueHandling = NullValueHandling.Ignore)]
        public string ProfilePath { get; set; }
    }

    public partial class Genre
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public long? Id { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }
    }

    public partial class LastEpisodeToAir
    {
        [JsonProperty("air_date", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? AirDate { get; set; }

        [JsonProperty("episode_number", NullValueHandling = NullValueHandling.Ignore)]
        public long? EpisodeNumber { get; set; }

        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public long? Id { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("overview", NullValueHandling = NullValueHandling.Ignore)]
        public string Overview { get; set; }

        [JsonProperty("production_code", NullValueHandling = NullValueHandling.Ignore)]
        public string ProductionCode { get; set; }

        [JsonProperty("season_number", NullValueHandling = NullValueHandling.Ignore)]
        public long? SeasonNumber { get; set; }

        [JsonProperty("show_id", NullValueHandling = NullValueHandling.Ignore)]
        public long? ShowId { get; set; }

        [JsonProperty("still_path")]
        public object StillPath { get; set; }

        [JsonProperty("vote_average", NullValueHandling = NullValueHandling.Ignore)]
        public long? VoteAverage { get; set; }

        [JsonProperty("vote_count", NullValueHandling = NullValueHandling.Ignore)]
        public long? VoteCount { get; set; }
    }

    public partial class Network
    {
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public long? Id { get; set; }

        [JsonProperty("logo_path")]
        public string LogoPath { get; set; }

        [JsonProperty("origin_country", NullValueHandling = NullValueHandling.Ignore)]
        public string OriginCountry { get; set; }
    }

    public partial class Season
    {
        [JsonProperty("air_date", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? AirDate { get; set; }

        [JsonProperty("episode_count", NullValueHandling = NullValueHandling.Ignore)]
        public long? EpisodeCount { get; set; }

        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public long? Id { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("overview", NullValueHandling = NullValueHandling.Ignore)]
        public string Overview { get; set; }

        [JsonProperty("poster_path")]
        public object PosterPath { get; set; }

        [JsonProperty("season_number", NullValueHandling = NullValueHandling.Ignore)]
        public long? SeasonNumber { get; set; }
    }
}
