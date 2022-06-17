using OpenQA.Selenium.Chrome;

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Titanium.Web.Proxy;
using System.Net;
using System.Net.Http;
using Titanium.Web.Proxy.EventArguments;
using Titanium.Web.Proxy.Models;
using RandevuBilgileri;
using RandevuEkle;
using Slot;

namespace MhrsRandevu
{
    public partial class Anaform : Form
    {
        public Anaform()
        {
            InitializeComponent();
        }

        ProxyServer proxyServer = new ProxyServer();
        ChromeDriver driver;

        private void Anaform_Load(object sender, EventArgs e)
        {
            proxyServer.CertificateManager.CertificateEngine = Titanium.Web.Proxy.Network.CertificateEngine.DefaultWindows;
            proxyServer.CertificateManager.EnsureRootCertificate();
            proxyServer.CertificateManager.TrustRootCertificate(true);

            proxyServer.BeforeRequest += OnRequest;
            proxyServer.BeforeResponse += OnResponse;
            proxyServer.ServerCertificateValidationCallback += OnCertificateValidation;
            proxyServer.ClientCertificateSelectionCallback += OnCertificateSelection;

            var explicitEndPoint = new ExplicitProxyEndPoint(IPAddress.Any, 8000, true){};

            proxyServer.AddEndPoint(explicitEndPoint);
            proxyServer.Start();

            var transparentEndPoint = new TransparentProxyEndPoint(IPAddress.Any, 8001, true)
            {
                GenericCertificateName = "google.com"
            };

            proxyServer.AddEndPoint(transparentEndPoint);

            ChromeOptions chromeOptions = new ChromeOptions{ };
            chromeOptions.AddArguments("--proxy-server=127.0.0.1:8000");
            chromeOptions.AddArguments("ignore-certificate-errors");

            var chromeDriverService = ChromeDriverService.CreateDefaultService();
            chromeDriverService.HideCommandPromptWindow = true;

            driver = new ChromeDriver(chromeDriverService , chromeOptions);

            driver.Navigate().GoToUrl("https://mhrs.gov.tr/vatandas/#/");


        }

        string bodyStringValue = string.Empty;
        bool calisabilir = false;

        List<string> headerNames = new List<string>();
        List<string> headerValues = new List<string>();

        public async Task OnRequest(object sender, SessionEventArgs e)
        {
            var requestHeaders = e.HttpClient.Request.Headers;


            var method = e.HttpClient.Request.Method.ToUpper();
            if ((method == "POST" || method == "PUT" || method == "PATCH"))
            {
                byte[] bodyBytes = await e.GetRequestBody();
                e.SetRequestBody(bodyBytes);
                string bodyString = await e.GetRequestBodyAsString();
                e.SetRequestBodyString(bodyString);
                e.UserData = e.HttpClient.Request;

                if (e.HttpClient.Request.Url.Contains("prd.mhrs.gov.tr/api/kurum-rss/randevu/slot-sorgulama/arama"))
                {
                    foreach (var item in requestHeaders.GetAllHeaders())
                    {
                        if (item.Name.ToLower() == "authorization" && e.HttpClient.Request.Url.ToLower().Contains("mhrs.gov.tr"))
                        {
                            bodyStringValue = bodyString;
                            calisabilir = true;
                            break;
                        }

                    }

                    foreach (var item in requestHeaders.GetAllHeaders())
                    {
                        headerNames.Add(item.Name);
                        headerValues.Add(item.Value);
                    }
                    driver.Quit();
                    await Task.Delay(1000);
                    Calis();
                }
            }


        }

        public async Task OnResponse(object sender, SessionEventArgs e)
        {
            var responseHeaders = e.HttpClient.Response.Headers;
            if (e.HttpClient.Request.Method == "GET" || e.HttpClient.Request.Method == "POST")
            {
                if (e.HttpClient.Response.StatusCode == 200)
                {
                    if (e.HttpClient.Response.ContentType != null && e.HttpClient.Response.ContentType.Trim().ToLower().Contains("text/html"))
                    {
                        byte[] bodyBytes = await e.GetResponseBody();
                        e.SetResponseBody(bodyBytes);

                        string body = await e.GetResponseBodyAsString();
                        e.SetResponseBodyString(body);
                    }
                }
            }

            if (e.UserData != null)
            {
                var request = (Titanium.Web.Proxy.Http.Request)e.UserData;
            }
        }

        public Task OnCertificateValidation(object sender, CertificateValidationEventArgs e)
        {
            if (e.SslPolicyErrors == System.Net.Security.SslPolicyErrors.None)
                e.IsValid = true;

            return Task.CompletedTask;
        }

        public Task OnCertificateSelection(object sender, CertificateSelectionEventArgs e)
        {
            return Task.CompletedTask;
        }

        async void Calis()
        {
            bool alindi = false;
        tekrar:
            if (calisabilir)
            {
                HttpClientHandler handler = new HttpClientHandler()
                {
                    AutomaticDecompression = DecompressionMethods.All,
                    //Proxy = new System.Net.WebProxy("127.0.0.1", 8888),
                    //UseProxy = true
                };
                HttpClient client = new HttpClient(handler);


                for (int i = 0; i < headerNames.Count; i++)
                {
                    try
                    {
                        client.DefaultRequestHeaders.Add(headerNames[i], headerValues[i]);
                    }
                    catch { }
                }



                var content = new StringContent(bodyStringValue, Encoding.UTF8, "application/json");
                var result = await client.PostAsync("https://prd.mhrs.gov.tr/api/kurum-rss/randevu/slot-sorgulama/arama", content);
                if (result.IsSuccessStatusCode)
                {
                    string responseString = await result.Content.ReadAsStringAsync();
                    var arama = Arama.FromJson(responseString);

                    for (int i = 0; i < arama.Data.Hastane.Count; i++)
                    {
                        if (!arama.Data.Hastane[i].Bos)
                            continue;
                        else
                        {
                            var aramaRequest = AramaRequest.FromJson(bodyStringValue);

                            SlotRequest slot = new SlotRequest()
                            {
                                AksiyonId = 200,
                                MhrsHekimId = aramaRequest.MhrsHekimId,
                                MhrsIlId = aramaRequest.MhrsIlId,
                                MhrsKlinikId = aramaRequest.MhrsKlinikId,
                                MhrsKurumId = arama.Data.Hastane[i].Kurum.MhrsKurumId,
                                MuayeneYeriId = arama.Data.Hastane[i].MuayeneYeri.Id,
                                TumRandevular = aramaRequest.TumRandevular,
                                EkRandevu = aramaRequest.EkRandevu,
                                RandevuZamaniList = aramaRequest.RandevuZamaniList,
                            };

                            content = new StringContent(slot.ToJson(), Encoding.UTF8, "application/json");
                            result = await client.PostAsync("https://prd.mhrs.gov.tr/api/kurum-rss/randevu/slot-sorgulama/slot", content);
                            if (result.IsSuccessStatusCode)
                            {
                                string veriOku = await result.Content.ReadAsStringAsync();
                                try
                                {
                                    var slotResponse1 = SlotResponse.FromJson(veriOku);
                                }
                                catch (Exception ee)
                                {

                                    MessageBox.Show(ee.Message);
                                }
                                var slotResponse = SlotResponse.FromJson(veriOku);

                                for (int j = 0; j < slotResponse.Data.Count; j++)
                                {
                                    if (!slotResponse.Data[j].Bos)
                                        continue;
                                    else
                                    {
                                        for (int h = 0; h < slotResponse.Data[j].HekimSlotList.Count; h++)
                                        {
                                            if (!slotResponse.Data[j].HekimSlotList[h].Bos)
                                                continue;
                                            else
                                            {
                                                for (int m = 0; m < slotResponse.Data[j].HekimSlotList[h].MuayeneYeriSlotList.Count; m++)
                                                {
                                                    if (!slotResponse.Data[j].HekimSlotList[h].MuayeneYeriSlotList[m].Bos)
                                                        continue;
                                                    else
                                                    {
                                                        for (int s = 0; s < slotResponse.Data[j].HekimSlotList[h].MuayeneYeriSlotList[m].SaatSlotList.Count; s++)
                                                        {
                                                            if (!slotResponse.Data[j].HekimSlotList[h].MuayeneYeriSlotList[m].SaatSlotList[s].Bos)
                                                                continue;
                                                            else
                                                            {
                                                                for (int slotlist = 0; slotlist < slotResponse.Data[j].HekimSlotList[h].MuayeneYeriSlotList[m].SaatSlotList[s].SlotList.Count; slotlist++)
                                                                {
                                                                    if (!slotResponse.Data[j].HekimSlotList[h].MuayeneYeriSlotList[m].SaatSlotList[s].SlotList[slotlist].Bos)
                                                                        continue;
                                                                    else
                                                                    {
                                                                        long slotId = slotResponse.Data[j].HekimSlotList[h].MuayeneYeriSlotList[m].SaatSlotList[s].SlotList[slotlist].Id;

                                                                        result = await client.GetAsync($"https://prd.mhrs.gov.tr/api/kurum/randevu/slot-sorgulama/randevu-bilgileri?fkSlotId={slotId}");
                                                                        if (result.IsSuccessStatusCode)
                                                                        {
                                                                            string BilgiyiOku = await result.Content.ReadAsStringAsync();
                                                                            var randevuBilgileriResponse = RandevuBilgileriResponse.FromJson(BilgiyiOku);

                                                                            string baslangicZaman = randevuBilgileriResponse.Data.Slot.BaslangicZamani.ToString().Replace("+00:00", "").Trim();
                                                                            string bitisZaman = randevuBilgileriResponse.Data.Slot.BitisZamani.ToString().Replace("+00:00", "").Trim();

                                                                            DateTime zaman1 = Convert.ToDateTime(baslangicZaman);
                                                                            DateTime zaman2 = Convert.ToDateTime(bitisZaman);

                                                                            baslangicZaman = String.Format("{0:yyyy-MM-dd HH:mm:ss}", zaman1);
                                                                            bitisZaman = String.Format("{0:yyyy-MM-dd HH:mm:ss}", zaman2);

                                                                            RandevuEkleRequest randevuEkle = new RandevuEkleRequest()
                                                                            {
                                                                                FkSlotId = slotId,
                                                                                FkCetvelId = randevuBilgileriResponse.Data.Slot.FkCetvelId,
                                                                                Yenidogan = false,
                                                                                BaslangicZamani = baslangicZaman,
                                                                                BitisZamani = bitisZaman,
                                                                                RandevuNotu = ""
                                                                            };
                                                                            content = new StringContent(randevuEkle.ToJson(), Encoding.UTF8, "application/json");
                                                                            result = await client.PostAsync("https://prd.mhrs.gov.tr/api/kurum/randevu/randevu-ekle", content);

                                                                            if (result.IsSuccessStatusCode)
                                                                            {
                                                                                alindi = true;
                                                                                MessageBox.Show("Randevu Alındı!");
                                                                                await Task.Delay(-1); // sonsuza kadar bekle
                                                                            }

                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }

                }
                else
                {
                    string cevap = await result.Content.ReadAsStringAsync();
                    if (cevap.IndexOf("Belirli bir süre içerisinde hayatın") != -1)
                    {
                        ZamanMbox.Show("Sistem tarafından fazla sorgu nedeniyle bir süre engellendin!", "UYARI", 3600000);
                        await Task.Delay(600000);
                    }
                }
            }
            if (!alindi)
            {
                if ((DateTime.Now.Hour == 16 && DateTime.Now.Minute == 00) || (DateTime.Now.Hour == 16 && DateTime.Now.Minute == 1) || (DateTime.Now.Hour == 0 && DateTime.Now.Minute == 00) || (DateTime.Now.Hour == 0 && DateTime.Now.Minute == 1))
                    await Task.Delay(5 * 1000);
                else
                    await Task.Delay(beklemeSuresi * 1000);
                goto tekrar;
            }
        }

        int beklemeSuresi = 120;

        private void numericSorguAraligi_ValueChanged(object sender, EventArgs e)
        {
            beklemeSuresi = (int)numericSorguAraligi.Value;
        }
    }
}
