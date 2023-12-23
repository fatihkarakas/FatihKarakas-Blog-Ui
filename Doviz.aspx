<%@ Page Title="" Language="C#" MasterPageFile="~/WebUI.master" AutoEventWireup="true" CodeFile="Doviz.aspx.cs" Inherits="Doviz" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
      <title>Fatih KARAKAŞ Döviz Kurları</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="card">
        <div class="card-header bg-light">
           <h3 class="text-info">Döviz Kurları</h3> 
        </div>
        <div class="card-body">
            <asp:Repeater runat="server" ID="DvzRepeater">
                <HeaderTemplate>
                    <table class="table table-responsive table-condensed  table-hover table-bordered">
                        <thead class="bg-light text-danger text-center">
                            <tr>
                                <td>Para Birimi</td>
                                <td>Alış</td>
                                <td>Satış</td>
                                <td>Günlük Değişim</td>
                            </tr>
                        </thead>
                    <tbody class="text-center">
                </HeaderTemplate>
                <ItemTemplate>
                  <tr>
                      <td class="text-left"><h6><%#Eval("full_name") %></h6></td>
                      <td> <%# String.Format("{0:0.000}",Eval("buying")) %></td>
                      <td><%# String.Format("{0:0.000}",Eval("selling")) %></td>
                      <td><%# String.Format("%{0:0.0}",Eval("change_rate")) %></td>
                  </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </tbody></table>
                </FooterTemplate>
            </asp:Repeater>
        </div>
        <div class="card-footer">Bilgiler doviz.com sayfasından alınmıştır</div>
    </div>
</asp:Content>

