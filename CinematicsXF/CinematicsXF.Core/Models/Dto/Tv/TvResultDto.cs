namespace CinematicsXF.Core.Dto.Tv
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class TvResultDto
    {
        [JsonProperty("page", NullValueHandling = NullValueHandling.Ignore)]
        public long? Page { get; set; }

        [JsonProperty("total_results", NullValueHandling = NullValueHandling.Ignore)]
        public long? TotalResults { get; set; }

        [JsonProperty("total_pages", NullValueHandling = NullValueHandling.Ignore)]
        public long? TotalPages { get; set; }

        [JsonProperty("results", NullValueHandling = NullValueHandling.Ignore)]
        public List<Result> Results { get; set; }
    }

    public partial class Result
    {
        [JsonProperty("original_name", NullValueHandling = NullValueHandling.Ignore)]
        public string OriginalName { get; set; }

        [JsonProperty("genre_ids", NullValueHandling = NullValueHandling.Ignore)]
        public List<long> GenreIds { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("popularity", NullValueHandling = NullValueHandling.Ignore)]
        public double? Popularity { get; set; }

        [JsonProperty("origin_country", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> OriginCountry { get; set; }

        [JsonProperty("vote_count", NullValueHandling = NullValueHandling.Ignore)]
        public long? VoteCount { get; set; }

        [JsonProperty("first_air_date", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? FirstAirDate { get; set; }

        [JsonProperty("backdrop_path", NullValueHandling = NullValueHandling.Ignore)]
        public string BackdropPath { get; set; }

        [JsonProperty("original_language", NullValueHandling = NullValueHandling.Ignore)]
        public OriginalLanguage? OriginalLanguage { get; set; }

        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public int? Id { get; set; }

        [JsonProperty("vote_average", NullValueHandling = NullValueHandling.Ignore)]
        public double? VoteAverage { get; set; }

        [JsonProperty("overview", NullValueHandling = NullValueHandling.Ignore)]
        public string Overview { get; set; }

        [JsonProperty("poster_path", NullValueHandling = NullValueHandling.Ignore)]
        public string PosterPath { get; set; }
    }

    public enum OriginalLanguage { En, Es, Ja, Nl };

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                OriginalLanguageConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class OriginalLanguageConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(OriginalLanguage) || t == typeof(OriginalLanguage?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "en":
                    return OriginalLanguage.En;
                case "es":
                    return OriginalLanguage.Es;
                case "ja":
                    return OriginalLanguage.Ja;
                case "nl":
                    return OriginalLanguage.Nl;
            }
            throw new Exception("Cannot unmarshal type OriginalLanguage");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (OriginalLanguage)untypedValue;
            switch (value)
            {
                case OriginalLanguage.En:
                    serializer.Serialize(writer, "en");
                    return;
                case OriginalLanguage.Es:
                    serializer.Serialize(writer, "es");
                    return;
                case OriginalLanguage.Ja:
                    serializer.Serialize(writer, "ja");
                    return;
                case OriginalLanguage.Nl:
                    serializer.Serialize(writer, "nl");
                    return;
            }
            throw new Exception("Cannot marshal type OriginalLanguage");
        }

        public static readonly OriginalLanguageConverter Singleton = new OriginalLanguageConverter();
    }
}
