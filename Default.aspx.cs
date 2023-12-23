using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    public VeriTabani Vt = new VeriTabani();
    protected void Page_Load(object sender, EventArgs e)
    {
        
        YardimciSiniflar ys = new YardimciSiniflar();
       
        Makaleler.DataSource = Vt.MakaleOku();
        Makaleler.DataBind();

    }

    public string KaG(int id)
    {
        string KtAdi = "";
        Vt.KategoriAdi(id);
        KtAdi = Vt.KategoriIdt;
        return KtAdi;
    }
}