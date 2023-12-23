using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Test : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    //    Page.ClientScript.RegisterStartupScript(this.GetType(),
    //"toastr_message", "toastr.error('There was an error', 'Error')", true);
        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), Guid.NewGuid().ToString(),
                    "toastr.warning('Tüm alanları doldurunuz', 'Uyarı')", true);
    }
}