using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Doviz : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
      
        DvzRepeater.DataSource = DovizKur();
        DvzRepeater.DataBind();
        Page.Title = "Fatih KARAKAŞ Blog Sayfası / Günlük Döviz İşlemleri";
        Page.MetaKeywords = "Döviz, Günlük Döviz Verileri, Fatih, Fatih KARAKAŞ, Yazılım, Motosiklet, Geziler";
    }

    public List<Dovizler> DovizKur()
    {
        //using (StreamReader r = new StreamReader("https://www.doviz.com/api/v1/currencies/all/latest"))
        //{
        //    string json = r.ReadToEnd();
        //    List<Dovizler> Dvz = JsonConvert.DeserializeObject<List<Dovizler>>(json);
        //}

        List<Dovizler> CurList = null;
        using (WebClient client = new WebClient())
        {
            var json = client.DownloadString("http://www.doviz.com/api/v1/currencies/all/latest");
            CurList = JsonConvert.DeserializeObject<List<Dovizler>>(json);
        }

        return CurList;

    }
}