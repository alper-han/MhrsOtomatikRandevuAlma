namespace MhrsRandevu
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class Arama
    {
        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("infos")]
        public List<Info> Infos { get; set; }

        [JsonProperty("warnings")]
        public List<object> Warnings { get; set; }

        [JsonProperty("errors")]
        public List<object> Errors { get; set; }

        [JsonProperty("data")]
        public Data Data { get; set; }
    }

    public partial class Data
    {
        [JsonProperty("hastane")]
        public List<Hastane> Hastane { get; set; }

        [JsonProperty("semt")]
        public List<object> Semt { get; set; }

        [JsonProperty("alternatif")]
        public List<object> Alternatif { get; set; }

        [JsonProperty("semtAramasi")]
        public bool SemtAramasi { get; set; }

        [JsonProperty("ekVar")]
        public bool EkVar { get; set; }

        [JsonProperty("cetvelTipi")]
        public long CetvelTipi { get; set; }

        [JsonProperty("acilacakSekme")]
        public long AcilacakSekme { get; set; }
    }

    public partial class Hastane
    {
        [JsonProperty("hekim")]
        public object Hekim { get; set; }

        [JsonProperty("muayeneYeri")]
        public MuayeneYeri MuayeneYeri { get; set; }

        [JsonProperty("kurum")]
        public Kurum Kurum { get; set; }

        [JsonProperty("kurumBilgileri")]
        public KurumBilgileri KurumBilgileri { get; set; }

        [JsonProperty("klinik")]
        public Klinik Klinik { get; set; }

        [JsonProperty("cetvelTipi")]
        public Tipi CetvelTipi { get; set; }

        [JsonProperty("aksiyon")]
        public Aksiyon Aksiyon { get; set; }

        [JsonProperty("hekimOncelikSirasi")]
        public bool HekimOncelikSirasi { get; set; }

        [JsonProperty("bosKapasite")]
        public long BosKapasite { get; set; }

        [JsonProperty("bos")]
        public bool Bos { get; set; }

        [JsonProperty("ekVar")]
        public bool EkVar { get; set; }

        [JsonProperty("baslangicZamani")]
        public DateTimeOffset BaslangicZamani { get; set; }

        [JsonProperty("bitisZamani")]
        public DateTimeOffset BitisZamani { get; set; }

        [JsonProperty("favori")]
        public bool Favori { get; set; }

        [JsonProperty("bitisZamaniStr")]
        public ZamaniStr BitisZamaniStr { get; set; }

        [JsonProperty("baslangicZamaniStr")]
        public ZamaniStr BaslangicZamaniStr { get; set; }
    }

    public partial class Aksiyon
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("aksiyonAdi")]
        public string AksiyonAdi { get; set; }
    }

    public partial class ZamaniStr
    {
        [JsonProperty("date")]
        public DateTimeOffset Date { get; set; }

        [JsonProperty("tarihAy")]
        public string TarihAy { get; set; }

        [JsonProperty("tarih")]
        public string Tarih { get; set; }

        [JsonProperty("gun")]
        public string Gun { get; set; }

        [JsonProperty("saat")]
        public string Saat { get; set; }

        [JsonProperty("zaman")]
        public string Zaman { get; set; }
    }

    public partial class Tipi
    {
        [JsonProperty("valText")]
        public string ValText { get; set; }

        [JsonProperty("val")]
        public long Val { get; set; }
    }

    public partial class Klinik
    {
        [JsonProperty("mhrsKlinikId")]
        public long MhrsKlinikId { get; set; }

        [JsonProperty("mhrsKlinikAdi")]
        public string MhrsKlinikAdi { get; set; }

        [JsonProperty("kisaAdi")]
        public string KisaAdi { get; set; }

        [JsonProperty("lcetvelTipi")]
        public long LcetvelTipi { get; set; }

        [JsonProperty("yandalList")]
        public List<object> YandalList { get; set; }

        [JsonProperty("anadalList")]
        public List<object> AnadalList { get; set; }
    }

    public partial class Kurum
    {
        [JsonProperty("mhrsKurumId")]
        public long MhrsKurumId { get; set; }

        [JsonProperty("mhrsAnaKurumId")]
        public long MhrsAnaKurumId { get; set; }

        [JsonProperty("kurumAdi")]
        public string KurumAdi { get; set; }

        [JsonProperty("kurumKisaAdi")]
        public string KurumKisaAdi { get; set; }

        [JsonProperty("kurumTurId")]
        public long KurumTurId { get; set; }

        [JsonProperty("ilIlce")]
        public IlIlce IlIlce { get; set; }
    }

    public partial class IlIlce
    {
        [JsonProperty("mhrsIlId")]
        public long MhrsIlId { get; set; }

        [JsonProperty("dkIlKodu")]
        public long DkIlKodu { get; set; }

        [JsonProperty("ilAdi")]
        public string IlAdi { get; set; }

        [JsonProperty("mhrsIlceId")]
        public long MhrsIlceId { get; set; }

        [JsonProperty("dkIlceKodu")]
        public long DkIlceKodu { get; set; }

        [JsonProperty("ilceAdi")]
        public string IlceAdi { get; set; }
    }

    public partial class KurumBilgileri
    {
        [JsonProperty("mhrsKurumId")]
        public long MhrsKurumId { get; set; }

        [JsonProperty("halkDilindekiAdi")]
        public string HalkDilindekiAdi { get; set; }

        [JsonProperty("telefonNumarasi")]
        public long TelefonNumarasi { get; set; }

        [JsonProperty("eposta")]
        public string Eposta { get; set; }

        [JsonProperty("adres")]
        public string Adres { get; set; }

        [JsonProperty("enlem")]
        public double Enlem { get; set; }

        [JsonProperty("boylam")]
        public double Boylam { get; set; }

        [JsonProperty("mhrsIlId")]
        public long MhrsIlId { get; set; }

        [JsonProperty("mhrsIlceId")]
        public long MhrsIlceId { get; set; }

        [JsonProperty("ilAdi")]
        public string IlAdi { get; set; }

        [JsonProperty("ilceAdi")]
        public string IlceAdi { get; set; }

        [JsonProperty("kurumAdi")]
        public string KurumAdi { get; set; }

        [JsonProperty("mesafe")]
        public object Mesafe { get; set; }

        [JsonProperty("mesafeKm")]
        public object MesafeKm { get; set; }

        [JsonProperty("kurumTurId")]
        public long KurumTurId { get; set; }

        [JsonProperty("anaKurumAdi")]
        public object AnaKurumAdi { get; set; }

        [JsonProperty("anaKurumKisaAdi")]
        public object AnaKurumKisaAdi { get; set; }

        [JsonProperty("acilHizmetler")]
        public List<AcilHizmetler> AcilHizmetler { get; set; }
    }

    public partial class AcilHizmetler
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("mhrsKurumId")]
        public long MhrsKurumId { get; set; }

        [JsonProperty("lacilPoliklinikTipi")]
        public long LacilPoliklinikTipi { get; set; }

        [JsonProperty("acilPoliklinikTipi")]
        public Tipi AcilPoliklinikTipi { get; set; }

        [JsonProperty("aktif")]
        public bool Aktif { get; set; }

        [JsonProperty("aktifDsc")]
        public AktifDsc AktifDsc { get; set; }
    }

    public partial class AktifDsc
    {
        [JsonProperty("val")]
        public bool Val { get; set; }

        [JsonProperty("valText")]
        public string ValText { get; set; }
    }

    public partial class MuayeneYeri
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("adi")]
        public string Adi { get; set; }
    }

    public partial class Info
    {
        [JsonProperty("kodu")]
        public string Kodu { get; set; }

        [JsonProperty("mesaj")]
        public string Mesaj { get; set; }
    }


    public partial class AramaRequest
    {
        [JsonProperty("aksiyonId")]
        //[JsonConverter(typeof(ParseStringConverter))]
        public long AksiyonId { get; set; }

        [JsonProperty("cinsiyet")]
        public string Cinsiyet { get; set; }

        [JsonProperty("mhrsHekimId")]
        public long MhrsHekimId { get; set; }

        [JsonProperty("mhrsIlId")]
        public long MhrsIlId { get; set; }

        [JsonProperty("mhrsIlceId")]
        public long MhrsIlceId { get; set; }

        [JsonProperty("mhrsKlinikId")]
        public long MhrsKlinikId { get; set; }

        [JsonProperty("mhrsKurumId")]
        public long MhrsKurumId { get; set; }

        [JsonProperty("muayeneYeriId")]
        public long MuayeneYeriId { get; set; }

        [JsonProperty("tumRandevular")]
        public bool TumRandevular { get; set; }

        [JsonProperty("ekRandevu")]
        public bool EkRandevu { get; set; }

        [JsonProperty("randevuZamaniList")]
        public List<object> RandevuZamaniList { get; set; }
    }

    public partial class SlotRequest
    {
        [JsonProperty("aksiyonId")]
        public long AksiyonId { get; set; }

        [JsonProperty("mhrsHekimId")]
        public long MhrsHekimId { get; set; }

        [JsonProperty("mhrsIlId")]
        public long MhrsIlId { get; set; }

        [JsonProperty("mhrsKlinikId")]
        public long MhrsKlinikId { get; set; }

        [JsonProperty("mhrsKurumId")]
        public long MhrsKurumId { get; set; }

        [JsonProperty("muayeneYeriId")]
        public long MuayeneYeriId { get; set; }

        [JsonProperty("cinsiyet")]
        public string Cinsiyet { get; set; }

        [JsonProperty("tumRandevular")]
        public bool TumRandevular { get; set; }

        [JsonProperty("ekRandevu")]
        public bool EkRandevu { get; set; }

        [JsonProperty("randevuZamaniList")]
        public List<object> RandevuZamaniList { get; set; }
    }

    public partial class SlotRequest
    {
        public static SlotRequest FromJson(string json) => JsonConvert.DeserializeObject<SlotRequest>(json, MhrsRandevu.Converter.Settings);
    }

    public partial class AramaRequest
    {
        public static AramaRequest FromJson(string json) => JsonConvert.DeserializeObject<AramaRequest>(json, MhrsRandevu.Converter.Settings);
    }

    public partial class Arama
    {
        public static Arama FromJson(string json) => JsonConvert.DeserializeObject<Arama>(json, MhrsRandevu.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this Arama self) => JsonConvert.SerializeObject(self, MhrsRandevu.Converter.Settings);

        public static string ToJson(this AramaRequest self) => JsonConvert.SerializeObject(self, MhrsRandevu.Converter.Settings);

        public static string ToJson(this SlotRequest self) => JsonConvert.SerializeObject(self, MhrsRandevu.Converter.Settings);
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
