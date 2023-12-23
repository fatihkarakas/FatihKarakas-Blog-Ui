<%@ Page Title="" Language="C#" MasterPageFile="~/MakaleOku.master" AutoEventWireup="true" CodeFile="Makale.aspx.cs" Inherits="Makale" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
      
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Repeater runat="server" ID="MakaleRpt">
        <ItemTemplate>
            <div class="meta">
                <%#Eval("PicturePath").ToString() != "" ? "<img class=\"wp-post-image\" src=\""+ Eval("PicturePath") +"\"  height=\"250\"/>":"" %>

                <div class="<%#Eval("PicturePath").ToString() == ""?"meta__container--without-image":"meta__container"%>">
                    <div class="row">
                        <div class="<%#Eval("PicturePath").ToString() == ""?"col-xs-12  col-sm-10  col-sm-offset-1  col-md-8  col-md-offset-2":"col-xs-12  col-sm-8"%>">
                            <div class="meta__info">
                                <span class="meta__author">
                                    <img src="/images/fatihkarakas.jpeg" alt="Meta avatar" width="30" height="30">
                                    <a href="#">Fatih KARAKAŞ</a> <--> <a href="/Kategori/<%Response.Write(sayfaId);%>"><% Response.Write(MakaleAdi); %></a> </span>
                                &nbsp;&nbsp;&nbsp;&nbsp;<span class="meta__date"><span class="glyphicon glyphicon-calendar"></span>&nbsp; <%# new YardimciSiniflar().ToRelativeFormat(Convert.ToDateTime(Eval("CreateDate"))) %> </span>
                            </div>
                        </div>
                        <div class="col-xs-12  col-sm-4">
                            <div class="meta__comments">
                                <span class="glyphicon glyphicon-book"></span>&nbsp;
                               <%# Eval("ViewCount") %> kez okundu
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="row">
                <div class="col-xs-10  col-xs-offset-1  col-md-8  col-md-offset-2  push-down-60">

                    <div class="post-content">
                        <h1><%# Eval("Title") %> </h1>
                        <p><%# Eval("ShortContent") %></p>
                        <p><%# Eval("FullContent") %></p>
                    </div>

                    <div class="row">
                        <div class="col-xs-12  col-sm-6">

                            <div class="post-comments">
                                <a class="btn  btn-primary" href="#disqus_thread">Tüm Yorumlar</a>
                            </div>

                        </div>
                        <div class="col-xs-12  col-sm-6">

                            <div class="social-icons">
                                <a href="#" class="social-icons__container"><span class="zocial-facebook"></span></a>
                                <a href="#" class="social-icons__container"><span class="zocial-twitter"></span></a>
                                <a href="#" class="social-icons__container"><span class="zocial-email"></span></a>
                            </div>

                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-12  col-sm-6">

                            <div class="post-author">
                                <h6>YAZAR</h6>
                                <hr>
                                <img src="/images/fatihkarakas.jpeg" width="50" height="50" alt="Fatih KARAKAŞ">
                                <h5>
                                    <a href="#">Fatih KARAKAŞ</a>
                                </h5>
                                <span class="post-author__text">Yazılım Geliştirici, Motosiklet Tutkunu, Amatör Bisikletçi...</span>
                            </div>

                        </div>
                        <div class="col-xs-12  col-sm-6">

                            <div class="tags">
                                <h6>Konu Etiketleri</h6>
                                <hr>
                                <%--  <a href="#" class="tags__link">Tech</a>
                                <a href="#" class="tags__link">Web Design</a>
                                <a href="#" class="tags__link">HTML/CSS</a>
                                <a href="#" class="tags__link">Tutorials</a>
                                <a href="#" class="tags__link">Workflow</a>--%>
                            </div>

                        </div>

                    </div>
                   

                    <%--<div class="related-stories">
                        <h6>İlgili Başlıklar</h6>
                      
                        <h4>
                            <a href="#">İlgili Başlıklar</a>
                        </h4>
                        <h5>Why Apple's tech is so much better than everyone else's.</h5>
                        <hr />
                        <h4>
                            <a href="#">10 Things I Know About Being Happy</a>
                        </h4>
                        <h5>Why Google's tech is so much better than everyone else's.</h5>
                        <hr />
                        <h4>
                            <a href="#">Taking Time to Reflect on Your Life Journey</a>
                        </h4>
                        <h5>Why Microsoft's tech is so much better than everyone else's.</h5>
                    </div>--%>
                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>
    <div class="row" id="commentRow">
        <div class="col-xs-12  col-xs-offset-1  col-md-8  col-md-offset-2  push-down-60">
            <div class="col-md-12">
                <div runat="server" id="htDiv" class="alert alert-danger" visible="false">
                    <asp:label runat="server" ID="htMesaj"></asp:label>
                </div>
                <h5 class="pull-left">Yorum yaz</h5>

            </div>
            <div class="col-md-10">
                <div class="col-xs-12 push-down-10">
                    <asp:TextBox runat="server" CssClass="form-control" placeholder="Ad soyad*" ID="Tamisim" Required></asp:TextBox>
                     <asp:RequiredFieldValidator runat="server"  ID="RequiredFieldValidator1" ControlToValidate="Tamisim" ErrorMessage="İsiminiz boş" Display="Dynamic" CssClass="alert alert-danger"></asp:RequiredFieldValidator>
                   
                </div>
                <div class="col-xs-12 push-down-10">
                    <asp:TextBox runat="server" CssClass="form-control" ID="Email" placeholder="Email*" Required></asp:TextBox>
                     <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="Email" CssClass="alert alert-danger" Display="Dynamic" ErrorMessage="Eposta adresi formatı hatalı" SetFocusOnError="True" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                </div>
                <div class="col-xs-12 push-down-10">
                   <asp:TextBox runat="server" CssClass="form-control" ID="Mesaj" placeholder="Mesajınız*" TextMode="MultiLine" Rows="4" Required></asp:TextBox>
                     <asp:RequiredFieldValidator runat="server"  ID="RequiredFieldValidator2" ControlToValidate="Mesaj" ErrorMessage="Mesaj boş" Display="Dynamic" CssClass="alert alert-danger"></asp:RequiredFieldValidator>
                </div>
                <div class="col-xs-12 push-down-10">
                    <asp:Image runat="server" ID="imgKod" /><span>Doğrulama Kodu</span>
                    <asp:TextBox runat="server" ID="Dogrulama" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server"  ID="DgKont" ControlToValidate="Dogrulama" ErrorMessage="Doğrulama Kodu boş" Display="Dynamic" CssClass="alert alert-danger"></asp:RequiredFieldValidator>
                </div>
                <div class="col-xs-12 push-down-10">
                    <asp:Button runat="server" Text="Yorumu Gönder" CssClass="btn btn-primary pull-left" OnClick="YorumGonder_Click" ID="YorumGonder" />
                    
                    <span class="contact__obligatory pull-right">Email adresiniz yayınlanmayacaktır.</span>
                </div>
               
                
               
               
                
            </div>
        </div>
    </div>
    <asp:Repeater runat="server" ID="MakaleYorumu">
        <HeaderTemplate>
            <div class="row" id="disqus_thread">
                <div class="col-xs-12  col-xs-offset-1  col-md-8  col-md-offset-2  push-down-60">
                    <div class="col-md-12">
                        <div class="card">
                            <div class="card-header">
                                Makale Yorumları
                            </div>
        </HeaderTemplate>
        <ItemTemplate>
            <div class="card-body">
                <h5 class="card-title"><%# Eval("FullName") %></h5>
                <p class="card-text"><%# Eval("Content") %></p>
                <%--<a href="#" class="btn btn-primary">Go somewhere</a>--%>
            </div>


        </ItemTemplate>
        <FooterTemplate>
            </div>
    </div>
            </div>
            </div>
        </FooterTemplate>

    </asp:Repeater>

      
</asp:Content>

