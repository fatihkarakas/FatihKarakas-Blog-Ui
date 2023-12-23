using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Makale : System.Web.UI.Page
{
    public string MakaleAdi;
    public string sayfaId;
    protected void Page_Load(object sender, EventArgs e)
    {
        string Sayfa;
        if (!IsPostBack)
        {
            if (RouteData.Values["id"] != null)
            {
              Sayfa=  RouteData.Values["adi"].ToString() + " " + RouteData.Values["id"].ToString();
                ResimOlustur();
               
            }
            else
            {
                Response.Redirect("/Anasayfa");
            }
        }
        VeriTabani Vt = new VeriTabani();
        Vt.MakaleOku1(Convert.ToInt32(RouteData.Values["id"].ToString()));
        Page.Title = "Fatih KARAKAŞ - " + Vt.Title;
        string[] Title1 = Vt.Title.Split(' ');
        string Keyword = "Fatih, KARAKAŞ, FATİH KARAKAŞ, Yazılım, Motosiklet";
        for (int i = 0; i < Title.Length; i++)
        {
            Keyword += Title[i].ToString() + ",";
        }
        Page.MetaKeywords = Keyword;
        MakaleRpt.DataSource = Vt.MakaleOku(Convert.ToInt32(RouteData.Values["id"].ToString()));
        MakaleRpt.DataBind();
        MakaleAdi = Vt.KategoriAdi(Convert.ToInt32(RouteData.Values["id"].ToString()));
        sayfaId = Vt.SayfaId;
        if (MakaleRpt.Items.Count > 0)
        {
            MakaleYorumu.DataSource = Vt.MakaleYorum(Convert.ToInt32(RouteData.Values["id"].ToString()));
            MakaleYorumu.DataBind();
        }
        else
        {
            Response.Redirect("/Anasayfa");
        }
    }
    public void ResimOlustur()
    {
        string kod = "";
        kod = new YardimciSiniflar().RastgeleVeriUret();
        //Üretilen kodu Session nesnesine aktarır.
        Session.Add("kod", kod);
        //Rastgele üretilen metini alıp resme dönüştürelim.
        //boş bir resim dosyası oluştur.
        Bitmap bmp = new Bitmap(200, 25);
        //Graphics sınıfı ile resmin kontrolunu alır.
        Graphics g = Graphics.FromImage(bmp);
        //DrawString 20‘ye 0 kordinatına kodu‘u yazdırır.
        g.DrawString(kod, new Font("Comic Sanns MS", 15), new SolidBrush(Color.Black), 20, 0);
        //Resmi binary olarak alıp sayfaya yazdırmak ıcın MemoryStream kullandık.
        MemoryStream ms = new MemoryStream();
        bmp.Save(ms, ImageFormat.Png);
        var base64Data = Convert.ToBase64String(ms.ToArray());
        imgKod.ImageUrl = "data:image/png;base64," + base64Data;
        g.Dispose();
        bmp.Dispose();
        ms.Close();
        ms.Dispose();
    }



    public string IpAdres()
    {
        string stringIpAddress;
        stringIpAddress = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
        if (stringIpAddress == null) //may be the HTTP_X_FORWARDED_FOR is null
        {
            stringIpAddress = Request.ServerVariables["REMOTE_ADDR"];//we can use REMOTE_ADDR
        }
        return stringIpAddress;
    }

    protected void YorumGonder_Click(object sender, EventArgs e)
    {
        htDiv.Visible = false;
        htMesaj.Text = "";
        VeriTabani VT = new VeriTabani();
        if(Session["kod"].ToString() == Dogrulama.Text)
        {
            VT.YorumEkle(Convert.ToInt32(RouteData.Values["id"].ToString()), Tamisim.Text, Mesaj.Text, Email.Text, 0,IpAdres());
            if (VT.HataVarmi)
            {
                htDiv.Visible = true;
                htMesaj.Text = "Hata Var" + VT.IslemHataMesaj;
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), Guid.NewGuid().ToString(),
                      "toastr.error('Hata oluştu " +VT.IslemHataMesaj+"', 'Uyarı',{ closeButton: true })", true);
                return;
            }
            else
            {
                htDiv.Visible = true;
                htMesaj.Text = "Mesajınız gönderildi. İnceleme sonrası yayınlanacaktır.";
                htDiv.Attributes.Add("Class", "alert alert-info");
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), Guid.NewGuid().ToString(),
                       "toastr.success('Mesajınız gönderildi. İnceleme sonrası yayınlanacaktır.', 'Uyarı',{ closeButton: true })", true);
                ResimOlustur();
                Tamisim.Text = "";
                Mesaj.Text = "";
                Email.Text = "";
                Dogrulama.Text = "";
            }
        }
        else
        {
            htDiv.Visible = true;
            htMesaj.Text = "Doğrulama Kodu Hatalı";
            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), Guid.NewGuid().ToString(),
                       "toastr.error('Doğrulama Kodu Hatalı', 'Uyarı',{ closeButton: true })", true);
        }
       
    }
}