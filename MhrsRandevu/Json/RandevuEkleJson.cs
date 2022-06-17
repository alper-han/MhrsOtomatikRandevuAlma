namespace RandevuEkle
{

    using System.Globalization;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class RandevuEkleRequest
    {
        [JsonProperty("fkSlotId")]
        public long FkSlotId { get; set; }

        [JsonProperty("fkCetvelId")]
        public long FkCetvelId { get; set; }

        [JsonProperty("yenidogan")]
        public bool Yenidogan { get; set; }

        [JsonProperty("baslangicZamani")]
        public string BaslangicZamani { get; set; }

        [JsonProperty("bitisZamani")]
        public string BitisZamani { get; set; }

        [JsonProperty("randevuNotu")]
        public string RandevuNotu { get; set; }
    }

    public partial class RandevuEkleRequest
    {
        public static RandevuEkleRequest FromJson(string json) => JsonConvert.DeserializeObject<RandevuEkleRequest>(json, RandevuEkle.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this RandevuEkleRequest self) => JsonConvert.SerializeObject(self, RandevuEkle.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
