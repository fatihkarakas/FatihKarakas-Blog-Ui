using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Kategori : System.Web.UI.Page
{
    public int KategoriId;
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!IsPostBack)
        {
            if (RouteData.Values["id"] != null)
            {
                VeriTabani Vt = new VeriTabani();
                KategoriId =Convert.ToInt32(RouteData.Values["id"].ToString());
                KategoriMakale.DataSource = Vt.KategoriMakaleler(KategoriId);
                KategoriMakale.DataBind();
            }
            else
            {
                Response.Redirect("/Anasayfa");
            }
        }
    }
}