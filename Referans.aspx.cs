using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Referans : System.Web.UI.Page
{
        public List<Referanslar> Rf { get; set; }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindReferansData();
        }
    }

    private void BindReferansData()
    {
        VeriTabani Vt = new VeriTabani();
        Rf = Vt.ReferanlarList();
        referansrpt.DataSource = Rf;
        referansrpt.DataBind();
    }
}