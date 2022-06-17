namespace RandevuBilgileri
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class RandevuBilgileriResponse
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
        [JsonProperty("randevuBaslangicZamani")]
        public DateTimeOffset RandevuBaslangicZamani { get; set; }

        [JsonProperty("randevuBitisZamani")]
        public DateTimeOffset RandevuBitisZamani { get; set; }

        [JsonProperty("randevuTuru")]
        public string RandevuTuru { get; set; }

        [JsonProperty("randevuTuruId")]
        public long RandevuTuruId { get; set; }

        [JsonProperty("kurum")]
        public DataKurum Kurum { get; set; }

        [JsonProperty("klinik")]
        public Klinik Klinik { get; set; }

        [JsonProperty("hekim")]
        public Hekim Hekim { get; set; }

        [JsonProperty("randevuSahibi")]
        public string RandevuSahibi { get; set; }

        [JsonProperty("randevuHastaBilgileri")]
        public RandevuHastaBilgileri RandevuHastaBilgileri { get; set; }

        [JsonProperty("muayeneYeri")]
        public MuayeneYeri MuayeneYeri { get; set; }

        [JsonProperty("cetvelTipi")]
        public CetvelTipi CetvelTipi { get; set; }

        [JsonProperty("slot")]
        public Slot Slot { get; set; }

        [JsonProperty("ek")]
        public bool Ek { get; set; }

        [JsonProperty("ozelKurum")]
        public bool OzelKurum { get; set; }

        [JsonProperty("randevuBaslangicZamaniStr")]
        public RandevuBZamaniStr RandevuBaslangicZamaniStr { get; set; }

        [JsonProperty("randevuBitisZamaniStr")]
        public RandevuBZamaniStr RandevuBitisZamaniStr { get; set; }
    }

    public partial class CetvelTipi
    {
        [JsonProperty("valText")]
        public string ValText { get; set; }

        [JsonProperty("val")]
        public long Val { get; set; }
    }

    public partial class Hekim
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("mhrsHekimId")]
        public long MhrsHekimId { get; set; }

        [JsonProperty("ad")]
        public string Ad { get; set; }

        [JsonProperty("soyad")]
        public string Soyad { get; set; }

        [JsonProperty("cinsiyet")]
        public Cinsiyet Cinsiyet { get; set; }
    }

    public partial class Cinsiyet
    {
        [JsonProperty("val")]
        public string Val { get; set; }

        [JsonProperty("valText")]
        public string ValText { get; set; }
    }

    public partial class Klinik
    {
        [JsonProperty("mhrsKlinikId")]
        public long MhrsKlinikId { get; set; }

        [JsonProperty("mhrsKlinikAdi")]
        public string MhrsKlinikAdi { get; set; }

        [JsonProperty("kisaAdi")]
        public string KisaAdi { get; set; }

        [JsonProperty("dkKlinikKodu")]
        public long DkKlinikKodu { get; set; }

        [JsonProperty("parentMhrsKlinikId")]
        public long ParentMhrsKlinikId { get; set; }

        [JsonProperty("lkarne")]
        public long Lkarne { get; set; }

        [JsonProperty("lcetvelTipi")]
        public long LcetvelTipi { get; set; }

        [JsonProperty("gorunurluk")]
        public bool Gorunurluk { get; set; }

        [JsonProperty("sertifika")]
        public bool Sertifika { get; set; }

        [JsonProperty("bitisZamani")]
        public object BitisZamani { get; set; }

        [JsonProperty("yandalList")]
        public List<object> YandalList { get; set; }

        [JsonProperty("anadalList")]
        public List<AnadalList> AnadalList { get; set; }

        [JsonProperty("ozellikDataList")]
        public List<CetvelTipi> OzellikDataList { get; set; }

        [JsonProperty("mesajKodu")]
        public object MesajKodu { get; set; }

        [JsonProperty("siraNo")]
        public long SiraNo { get; set; }

        [JsonProperty("aktif")]
        public bool Aktif { get; set; }
    }

    public partial class AnadalList
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("yandalMhrsKlinikId")]
        public long YandalMhrsKlinikId { get; set; }

        [JsonProperty("anadalMhrsKlinikId")]
        public long AnadalMhrsKlinikId { get; set; }

        [JsonProperty("anadalSirasi")]
        public long AnadalSirasi { get; set; }

        [JsonProperty("aktif")]
        public bool Aktif { get; set; }

        [JsonProperty("yandalKlinikAdi")]
        public string YandalKlinikAdi { get; set; }

        [JsonProperty("anadalKlinikAdi")]
        public string AnadalKlinikAdi { get; set; }
    }

    public partial class DataKurum
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
        public CetvelTipi AcilPoliklinikTipi { get; set; }

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

        [JsonProperty("fkKurumKlinikId")]
        public long FkKurumKlinikId { get; set; }

        [JsonProperty("kurumKlinik")]
        public KurumKlinik KurumKlinik { get; set; }

        [JsonProperty("adi")]
        public string Adi { get; set; }

        [JsonProperty("aktifDsc")]
        public AktifDsc AktifDsc { get; set; }

        [JsonProperty("tescilOdaKayitNo")]
        public long TescilOdaKayitNo { get; set; }

        [JsonProperty("tescil")]
        public object Tescil { get; set; }
    }

    public partial class KurumKlinik
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("mhrsKlinikId")]
        public long MhrsKlinikId { get; set; }

        [JsonProperty("klinik")]
        public Klinik Klinik { get; set; }

        [JsonProperty("kurum")]
        public KurumKlinikKurum Kurum { get; set; }

        [JsonProperty("mhrsKurumId")]
        public long MhrsKurumId { get; set; }
    }

    public partial class KurumKlinikKurum
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("mhrsKurumId")]
        public long MhrsKurumId { get; set; }

        [JsonProperty("mhrsAnaKurumId")]
        public long MhrsAnaKurumId { get; set; }

        [JsonProperty("dkKurumKodu")]
        public long DkKurumKodu { get; set; }

        [JsonProperty("mhrsIlceId")]
        public long MhrsIlceId { get; set; }

        [JsonProperty("kurumAdi")]
        public string KurumAdi { get; set; }

        [JsonProperty("kurumKisaAdi")]
        public string KurumKisaAdi { get; set; }

        [JsonProperty("kurumTurId")]
        public long KurumTurId { get; set; }

        [JsonProperty("kurumTipId")]
        public long KurumTipId { get; set; }

        [JsonProperty("lashTipi")]
        public string LashTipi { get; set; }

        [JsonProperty("lkurumDurumu")]
        public long LkurumDurumu { get; set; }

        [JsonProperty("baslangicTarihi")]
        public DateTimeOffset BaslangicTarihi { get; set; }

        [JsonProperty("bitisTarihi")]
        public object BitisTarihi { get; set; }
    }

    public partial class RandevuBZamaniStr
    {
        [JsonProperty("date")]
        public DateTimeOffset Date { get; set; }

        [JsonProperty("gun")]
        public string Gun { get; set; }

        [JsonProperty("saat")]
        public string Saat { get; set; }

        [JsonProperty("tarih")]
        public string Tarih { get; set; }

        [JsonProperty("zaman")]
        public string Zaman { get; set; }

        [JsonProperty("tarihAy")]
        public string TarihAy { get; set; }
    }

    public partial class RandevuHastaBilgileri
    {
        [JsonProperty("tcKimlikNo")]
        public long TcKimlikNo { get; set; }

        [JsonProperty("adi")]
        public string Adi { get; set; }

        [JsonProperty("soyadi")]
        public string Soyadi { get; set; }

        [JsonProperty("cinsiyet")]
        public Cinsiyet Cinsiyet { get; set; }

        [JsonProperty("dogumTarihi")]
        public DateTimeOffset DogumTarihi { get; set; }

        [JsonProperty("hastaTipi")]
        public CetvelTipi HastaTipi { get; set; }

        [JsonProperty("dogumYeri")]
        public string DogumYeri { get; set; }
    }

    public partial class Slot
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("fkCetvelId")]
        public long FkCetvelId { get; set; }

        [JsonProperty("mhrsKurumId")]
        public long MhrsKurumId { get; set; }

        [JsonProperty("mhrsKlinikId")]
        public long MhrsKlinikId { get; set; }

        [JsonProperty("mhrsHekimId")]
        public long MhrsHekimId { get; set; }

        [JsonProperty("muayeneYeriId")]
        public long MuayeneYeriId { get; set; }

        [JsonProperty("fkAksiyonId")]
        public long FkAksiyonId { get; set; }

        [JsonProperty("slotHastaSayisi")]
        public long SlotHastaSayisi { get; set; }

        [JsonProperty("randevuSuresi")]
        public long RandevuSuresi { get; set; }

        [JsonProperty("kullanim")]
        public long Kullanim { get; set; }

        [JsonProperty("kalanKullanim")]
        public long KalanKullanim { get; set; }

        [JsonProperty("baslangicZamani")]
        public DateTimeOffset BaslangicZamani { get; set; }

        [JsonProperty("bitisZamani")]
        public DateTimeOffset BitisZamani { get; set; }

        [JsonProperty("kayitZamani")]
        public object KayitZamani { get; set; }
    }

    public partial class Info
    {
        [JsonProperty("kodu")]
        public string Kodu { get; set; }

        [JsonProperty("mesaj")]
        public string Mesaj { get; set; }
    }

    public partial class RandevuBilgileriResponse
    {
        public static RandevuBilgileriResponse FromJson(string json) => JsonConvert.DeserializeObject<RandevuBilgileriResponse>(json, RandevuBilgileri.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this RandevuBilgileriResponse self) => JsonConvert.SerializeObject(self, RandevuBilgileri.Converter.Settings);
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
