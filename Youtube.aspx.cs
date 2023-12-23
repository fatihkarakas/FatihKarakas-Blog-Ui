using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Youtube : System.Web.UI.Page
{
    public List<VideoBilgi> Liste = new List<VideoBilgi>();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            YouTubeBilgi YB = new YouTubeBilgi();
            YB.Run();

            GenelG.DataSource = YB.Veriler;/*.OrderByDescending(x => x.Url).Take(4);*/
            GenelG.DataBind();
            Liste = YB.Veriler;
        }


    }


    protected void DataPager1_PreRender(object sender, EventArgs e)
    {
        YouTubeBilgi YB = new YouTubeBilgi();
        YB.Run();

        GenelG.DataSource = YB.Veriler;/*.OrderByDescending(x => x.Url).Take(4);*/
        GenelG.DataBind();
        Liste = YB.Veriler;
    }
}