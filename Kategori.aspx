<%@ Page Language="C#" MasterPageFile="~/WebUI.master" AutoEventWireup="true" CodeFile="Kategori.aspx.cs" Inherits="Kategori" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Repeater runat="server" ID="KategoriMakale">
        <ItemTemplate>
            <div class="boxed  push-down-45">

        <div class="meta">
          <%#Eval("PicturePath").ToString() != "" ? "<img class=\"wp-post-image\" src=\""+ Eval("PicturePath") +"\"/>":"" %>
            <%--<img class="wp-post-image" src='<%#Eval("PicturePath") %>' alt='<%# Eval("Title") %>' width="748" height="324">--%>
          
            <div class="meta__container">
                <div class="row">
                    <div class="col-xs-12  col-sm-8">
                        <div class="meta__info">
                            <span class="meta__author">
                                <img src="/images/fatihkarakas.jpeg" alt="Meta avatar" width="30" height="30">
                                <a href="#">Fatih KARAKAŞ</a> </span>
                            <span class="meta__date"><span class="glyphicon glyphicon-calendar"></span>&nbsp;
                                <%# new YardimciSiniflar().ToRelativeFormat(Convert.ToDateTime(Eval("CreateDate"))) %>
                               <%-- <%# Eval("CreateDate") %>--%></span>
                        </div>
                    </div>
                    <div class="col-xs-12  col-sm-4">
                        <div class="meta__comments">
                            <span> <%#Eval("ViewCount") %> Kez Okundu</span>&nbsp;
                            <a href='/Makale/<%# Eval("Title") %>/<%# Eval("Id") %>#disqus_thread' >
                            </a>
                        </div>
                    </div>
                </div>
            </div>
        </div>


        <div class="row">
            <div class="col-xs-10  col-xs-offset-1">

                <div class="post-content--front-page">
                    <h3 class="front-page-title"><a href='/Makale/<%#new YardimciSiniflar().KodOlustur(Eval("Title").ToString())%>/<%#Eval("Id") %>'>
<%# Eval("Title") %>
                                                 </a>
                        
                    </h3>
                   
   <p><%# Eval("ShortContent") %></p>
                </div>

             <a href='/Makale/<%#new YardimciSiniflar().KodOlustur(Eval("Title").ToString())%>/<%#Eval("Id") %>'>
                    <div class="read-more">
                       Devamını Oku
                        <div class="read-more__arrow">
                            <span class="glyphicon  glyphicon-chevron-right"></span>
                        </div>
                     
                    </div>
                </a>
            </div>
        </div>
    </div>
        </ItemTemplate>
    </asp:Repeater>
    </asp:Content>