using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class iletisim : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ResimOlustur();
            Page.Title = "Fatih KARAKAŞ İletişim Kurma Formu";
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

    protected void Gonder_Click(object sender, EventArgs e)
    {
        htDiv.Visible = false;
        htMesaj.Text = "";
        VeriTabani VT = new VeriTabani();
        if (Session["kod"].ToString() == Dogrulama.Text)
        {
            VT.MesajEkle(Tamisim.Text, Mesaj.Text, email.Text, IpAdres());
            if (VT.HataVarmi)
            {
                htDiv.Visible = true;
                htMesaj.Text = "Hata Var" + VT.IslemHataMesaj;
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), Guid.NewGuid().ToString(),
                      "toastr.error('Hata oluştu " + VT.IslemHataMesaj + "', 'Uyarı',{ closeButton: true })", true);
                return;
            }
            else
            {
                htDiv.Visible = true;
                htMesaj.Text = "Mesajınız gönderildi.";
                htDiv.Attributes.Add("Class", "alert alert-info");
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), Guid.NewGuid().ToString(),
                       "toastr.success('Mesajınız gönderildi. İnceleme sonrası yayınlanacaktır.', 'Uyarı',{ closeButton: true })", true);
                Tamisim.Text = "";
                ResimOlustur();
                email.Text = "";
                Mesaj.Text = "";
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
}