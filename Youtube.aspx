<%@ Page Title="" Language="C#" MasterPageFile="~/WebUI.master" AutoEventWireup="true" CodeFile="Youtube.aspx.cs" Inherits="Youtube" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
     
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%-- 
 

   <div class="embed-responsive embed-responsive-16by9">
    <iframe class="embed-responsive-item" src="<% Response.Write(Liste[1].Embed.ToString());%>" allowfullscreen></iframe>
</div>--%>
    
    
    <asp:ListView runat="server" ID="GenelG" >
        <ItemTemplate>
               <div class="card">
                <div class="card-header bg-success">
                   <h4 class="headerBaslik"> <%#Eval("Adi") %></h4>
                </div>
                <div class="card-body">
                    <h5 class="card-title"></h5>
                    <p class="card-text"><%#Eval("Aciklama") %></p>

                    <a href="<%#Eval("Url") %>">
                       <%-- <img src="<%#Eval("Resimi") %>" />--%></a>
                       <div class="embed-responsive embed-responsive-16by9">
    <iframe class="embed-responsive-item" src="<%#Eval("Embed")%>" allowfullscreen></iframe>
</div>
                </div>
            </div>
        </ItemTemplate>
    </asp:ListView>
   <asp:DataPager ID="DataPager1" runat="server" PagedControlID="GenelG" class="table table-bordered" PageSize="5" OnPreRender="DataPager1_PreRender">
       <Fields>
           <asp:NextPreviousPagerField RenderDisabledButtonsAsLabels="true" ButtonCssClass="btn btn-info" ShowFirstPageButton="true" ShowLastPageButton="false" ShowPreviousPageButton="true" PreviousPageText="Önceki" />
           <asp:NumericPagerField RenderNonBreakingSpacesBetweenControls="true" ButtonCount="10" NumericButtonCssClass="btn btn-info" CurrentPageLabelCssClass="btn btn-alternative" NextPreviousButtonCssClass="btn btn-warning"  />
           <%--<asp:NextPreviousPagerField RenderDisabledButtonsAsLabels="true" ShowFirstPageButton="false" ShowPreviousPageButton="false" ShowLastPageButton="false" NextPageText="Sonraki" />--%>
       </Fields>

    </asp:DataPager>
</asp:Content>

