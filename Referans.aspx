<%@ Page Title="" Language="C#" MasterPageFile="~/WebUI.master" AutoEventWireup="true" CodeFile="Referans.aspx.cs" Inherits="Referans" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Repeater runat="server" ID="referansrpt">
        <ItemTemplate>
            <div class="card">
 <div class="card-title"> </div>
                <div class="card-header">
                   <h4>
                        <%# Eval("Baslik") %></h4>
                   

                </div>
                <div class="card-body">
                    <img src="<%# Eval("ResimAdres") %>" class="card-img img-responsive" />
                    <div class="card-text">
                          <%# Eval("Aciklama") %>
                    </div>
                    <div class="row">
                        <div class="col-md-6">
                            <h6>Kurum : </h6> <%# Eval("Kurum") %>
                        </div>
                         <div class="col-md-6">
                             <h6>Platform : </h6> <%# Eval("Platform") %>
                             <a href="<%# Eval("LinUrl") %>" Class="btn btn-primary">Ziyaret Et</a>
                        </div>
                    </div>
                </div>
                <div class="card-footer">
                    
                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>

</asp:Content>

