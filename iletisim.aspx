<%@ Page Title="" Language="C#" MasterPageFile="~/WebUI.master" AutoEventWireup="true" CodeFile="iletisim.aspx.cs" Inherits="iletisim" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="boxed  push-down-45">
        <div class="row">
            <div class="col-xs-10  col-xs-offset-1">
                <div class="contact">
                    <h2>İletişim</h2>
                    <p class="contact__text">Bildiklerimi, bilmediklerimi, merak ettiklerinizi veya merak edeceğimi düşündüğünüz konuları aşağıya yazarak bana aktarabilirsiniz.</p>

                    <div class="row">
                        <div runat="server" id="htDiv" class="alert alert-danger" visible="false">
                    <asp:label runat="server" ID="htMesaj"></asp:label>
                </div>
                        <div class="col-xs-6">
                            <label for="Tamisim">Adınız :</label>
                               <asp:TextBox runat="server" CssClass="form-control" placeholder="Ad soyad*" ID="Tamisim" Required></asp:TextBox>
                     <asp:RequiredFieldValidator runat="server"  ID="RequiredFieldValidator1" ControlToValidate="Tamisim" ErrorMessage="İsiminiz boş" Display="Dynamic" CssClass="alert alert-danger"></asp:RequiredFieldValidator>

                        </div>
                        <div class="col-xs-6">
                            <label for="Eposta">Eposta Adresiniz :</label>
                             <asp:TextBox runat="server" CssClass="form-control" ID="email" placeholder="Email*" Required></asp:TextBox>
                     <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="Email" CssClass="alert alert-danger" Display="Dynamic" ErrorMessage="Eposta adresi formatı hatalı" SetFocusOnError="True" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>

                        </div>
                        <div class="col-xs-12 bg5">
                            <label for="Mesaj">Mesajınız :</label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="Mesaj" placeholder="Mesajınız*" TextMode="MultiLine" Rows="5" Required></asp:TextBox>
                            <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator2" ControlToValidate="Mesaj" ErrorMessage="Mesaj boş" Display="Dynamic" CssClass="alert alert-danger"></asp:RequiredFieldValidator>

                        </div>
                        <div class="col-xs-12 bg10">
                            <asp:Image runat="server" ID="imgKod" /><span>Doğrulama Kodu</span>
                            <asp:TextBox runat="server" ID="Dogrulama" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator runat="server" ID="DgKont" ControlToValidate="Dogrulama" ErrorMessage="Doğrulama Kodu boş" Display="Dynamic" CssClass="alert alert-danger"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-xs-12 bg10">
                            <asp:Button runat="server" ID="Gonder" OnClick="Gonder_Click" CssClass="btn btn-primary" Text="Mesajı Gönder" />
                        </div>


                    </div>

                </div>
            </div>
        </div>
    </div>
</asp:Content>

