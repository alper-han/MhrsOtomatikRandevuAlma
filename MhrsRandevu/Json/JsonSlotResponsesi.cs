namespace Slot
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class SlotResponse
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
        public List<Datum> Data { get; set; }
    }

    public partial class Datum
    {
        [JsonProperty("hekimSlotList")]
        public List<HekimSlotList> HekimSlotList { get; set; }

        [JsonProperty("gun")]
        public DateTimeOffset Gun { get; set; }

        [JsonProperty("bos")]
        public bool Bos { get; set; }

        [JsonProperty("kapasite")]
        public long Kapasite { get; set; }

        [JsonProperty("kullanim")]
        public long Kullanim { get; set; }

        [JsonProperty("kalanKullanim")]
        public long KalanKullanim { get; set; }

        [JsonProperty("gunStr")]
        public NStr GunStr { get; set; }
    }

    public partial class NStr
    {
        [JsonProperty("date")]
        public DateTimeOffset Date { get; set; }


        [JsonProperty("saat")]
        public string Saat { get; set; }

        [JsonProperty("zaman")]
        public string Zaman { get; set; }
    }

    public partial class HekimSlotList
    {
        [JsonProperty("muayeneYeriSlotList")]
        public List<MuayeneYeriSlotList> MuayeneYeriSlotList { get; set; }

        [JsonProperty("hekim")]
        public object Hekim { get; set; }

        [JsonProperty("kurum")]
        public Kurum Kurum { get; set; }

        [JsonProperty("klinik")]
        public Klinik Klinik { get; set; }

        [JsonProperty("aksiyon")]
        public Aksiyon Aksiyon { get; set; }

        [JsonProperty("bos")]
        public bool Bos { get; set; }

        [JsonProperty("bosEk")]
        public bool BosEk { get; set; }

        [JsonProperty("hekimFavori")]
        public bool HekimFavori { get; set; }

        [JsonProperty("toplamKapasite")]
        public long ToplamKapasite { get; set; }

        [JsonProperty("bosKapasite")]
        public long BosKapasite { get; set; }

        [JsonProperty("toplamEkKapasite")]
        public long ToplamEkKapasite { get; set; }

        [JsonProperty("bosEkKapasite")]
        public long BosEkKapasite { get; set; }
    }

    public partial class Aksiyon
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("aksiyonAdi")]
        public string AksiyonAdi { get; set; }
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

    public partial class MuayeneYeriSlotList
    {
        [JsonProperty("saatSlotList")]
        public List<SaatSlotList> SaatSlotList { get; set; }

        [JsonProperty("saatSlotListEk")]
        public List<object> SaatSlotListEk { get; set; }

        [JsonProperty("muayeneYeri")]
        public MuayeneYeri MuayeneYeri { get; set; }

        [JsonProperty("toplamKapasite")]
        public long ToplamKapasite { get; set; }

        [JsonProperty("bosKapasite")]
        public long BosKapasite { get; set; }

        [JsonProperty("toplamEkKapasite")]
        public long ToplamEkKapasite { get; set; }

        [JsonProperty("bosEkKapasite")]
        public long BosEkKapasite { get; set; }

        [JsonProperty("bos")]
        public bool Bos { get; set; }

        [JsonProperty("bosEk")]
        public bool BosEk { get; set; }
    }

    public partial class MuayeneYeri
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("adi")]
        public string Adi { get; set; }
    }

    public partial class SaatSlotList
    {
        [JsonProperty("slotList")]
        public List<SlotList> SlotList { get; set; }

        [JsonProperty("saat")]
        public DateTimeOffset Saat { get; set; }

        [JsonProperty("bos")]
        public bool Bos { get; set; }

        [JsonProperty("ek")]
        public bool Ek { get; set; }

        [JsonProperty("toplamKapasite")]
        public long ToplamKapasite { get; set; }

        [JsonProperty("bosKapasite")]
        public long BosKapasite { get; set; }

    }

    public partial class SlotList
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("fkCetvelId")]
        public long FkCetvelId { get; set; }

        [JsonProperty("baslangicZamani")]
        public DateTimeOffset BaslangicZamani { get; set; }

        [JsonProperty("bitisZamani")]
        public DateTimeOffset BitisZamani { get; set; }

        [JsonProperty("cetvelIsKurallari")]
        public object CetvelIsKurallari { get; set; }

        [JsonProperty("slot")]
        public Slot Slot { get; set; }

        [JsonProperty("bos")]
        public bool Bos { get; set; }

        [JsonProperty("isKurali")]
        public bool IsKurali { get; set; }

        [JsonProperty("kapasite")]
        public long Kapasite { get; set; }

        [JsonProperty("bosKapasite")]
        public long BosKapasite { get; set; }

        [JsonProperty("ek")]
        public bool Ek { get; set; }

        [JsonProperty("uygunRandevuGecmisSlot")]
        public bool UygunRandevuGecmisSlot { get; set; }

        [JsonProperty("rezerveTuruData")]
        public object RezerveTuruData { get; set; }

        [JsonProperty("bitisZamanStr")]
        public NStr BitisZamanStr { get; set; }

        [JsonProperty("baslangicZamanStr")]
        public NStr BaslangicZamanStr { get; set; }

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


    public partial class SlotResponse
    {
        public static SlotResponse FromJson(string json) => JsonConvert.DeserializeObject<SlotResponse>(json, global::Slot.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this SlotResponse self) => JsonConvert.SerializeObject(self, global::Slot.Converter.Settings);
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
