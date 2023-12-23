<%@ Application Language="C#" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e)
    {
        RegisterRoutes(System.Web.Routing.RouteTable.Routes);

    }
    public void RegisterRoutes(System.Web.Routing.RouteCollection routes)
    {
        routes.MapPageRoute("AnaSayfa", "AnaSayfa", "~/Default.aspx");
        routes.MapPageRoute("Iletisim", "Iletisim", "~/iletisim.aspx");
        routes.MapPageRoute("Makale1", "Makale", "~/Makale.aspx");
        routes.MapPageRoute("Makale", "Makale/{adi}/{id}", "~/Makale.aspx");
        routes.MapPageRoute("Kategori", "Kategori/{id}", "~/Kategori.aspx");
        routes.MapPageRoute("Youtube", "Youtube", "~/Youtube.aspx");
        routes.MapPageRoute("YoutubeId", "Youtube/{id}", "~/Youtube.aspx");
        routes.MapPageRoute("Hakkimda", "Hakkimda", "~/hakkimda.aspx");
        routes.MapPageRoute("Referans", "Referans", "~/Referans.aspx");
        routes.MapPageRoute("Doviz", "Doviz", "~/Doviz.aspx");
    }

    void Application_End(object sender, EventArgs e)
    {
        //  Code that runs on application shutdown

    }

    void Application_Error(object sender, EventArgs e)
    {
        // Code that runs when an unhandled error occurs

    }

    void Session_Start(object sender, EventArgs e)
    {
        // Code that runs when a new session is started

    }

    void Session_End(object sender, EventArgs e)
    {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.

    }

</script>
