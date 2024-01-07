using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Referans : System.Web.UI.Page
{
    public List<Referanslar> Rf = new List<Referanslar>();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            VeriTabani Vt = new VeriTabani();
            referansrpt.DataSource = Vt.ReferanlarList();
            referansrpt.DataBind();
        }

    }
}