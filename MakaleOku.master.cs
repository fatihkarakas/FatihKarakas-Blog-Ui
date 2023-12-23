using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MakaleOku : System.Web.UI.MasterPage
{
    public string sayfa;
    protected void Page_Load(object sender, EventArgs e)
    {
        VeriTabani VT = new VeriTabani();
        KategoriList.DataSource = VT.KategoriSayi();
        KategoriList.DataBind();
    }
    public string SayfaKontolClass(string sayfak)
    {
        string sonuc = " ";
        sayfa = Page.ToString().Replace("ASP.", "");
        sayfa = sayfa.Replace("_", ".");
        sayfa = sayfa.ToLower();
        string[] sayfayeni = sayfa.Split('.');
        switch (sayfayeni[0])
        {
            case "Default":
                sayfayeni[0] = "anasayfa";
                break;

        }
        if (sayfak.ToLower() == sayfayeni[0])
        {
            sonuc = "active";
        }
        sayfa = sayfayeni[0];
        return sonuc;
    }
    public string ToRelativeFormat(DateTime source)
    {
        string result = string.Empty;

        var ts = new TimeSpan(DateTime.Now.Ticks - source.Ticks);
        double delta = ts.TotalSeconds;

        if (delta > 0)
        {
            if (delta < 60) // 60 (seconds)
            {
                result = ts.Seconds == 1 ? "bir saniye önce" : ts.Seconds + " saniye önce";
            }
            else if (delta < 120) //2 (minutes) * 60 (seconds)
            {
                result = "1 dakika önce";
            }
            else if (delta < 2700) // 45 (minutes) * 60 (seconds)
            {
                result = ts.Minutes + " dakika önce";
            }
            else if (delta < 5400) // 90 (minutes) * 60 (seconds)
            {
                result = "bir saat önce";
            }
            else if (delta < 86400) // 24 (hours) * 60 (minutes) * 60 (seconds)
            {
                int hours = ts.Hours;
                if (hours == 1)
                    hours = 2;
                result = hours + " saat önce";
            }
            else if (delta < 172800) // 48 (hours) * 60 (minutes) * 60 (seconds)
            {
                result = "dün";
            }
            else if (delta < 2592000) // 30 (days) * 24 (hours) * 60 (minutes) * 60 (seconds)
            {
                result = ts.Days + " gün önce";
            }
            else if (delta < 31104000) // 12 (months) * 30 (days) * 24 (hours) * 60 (minutes) * 60 (seconds)
            {
                int months = Convert.ToInt32(Math.Floor((double)ts.Days / 30));
                result = months <= 1 ? "bir ay önce" : months + " ay önce";
            }
            else
            {
                int years = Convert.ToInt32(Math.Floor((double)ts.Days / 365));
                if (years <= 1)
                    result = "bir yıl önce";
                else
                    result = source.ToString();

                //result = years <= 1 ? "bir yıl önce" : years + " yıl önce";
            }
        }
        return result;
    }
}
