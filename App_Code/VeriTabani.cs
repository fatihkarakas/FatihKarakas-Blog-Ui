using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for VeriTabani
/// </summary>
public class VeriTabani
{
    public string st = ConfigurationManager.ConnectionStrings["DB1"].ConnectionString;
    public SqlConnection baglan = new SqlConnection();
    public SqlDataAdapter DT = new SqlDataAdapter();
    public DataSet DS = new DataSet();
    public bool HataVarmi;
    public string IslemHataMesaj,SayfaId,KategoriIdt,Title;

    public VeriTabani()
    {

    }

    public DataSet ReferanlarList()
    {
        DS = new DataSet();
        try
        {
            baglan.ConnectionString = st;
            if (baglan.State == ConnectionState.Closed) { baglan.Open(); }
            using (baglan)
            {
                SqlCommand Sorgu = new SqlCommand()
                {
                    Connection = baglan,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "ReferansGetir"
                };
                
                SqlDataAdapter DA = new SqlDataAdapter()
                {
                    SelectCommand = Sorgu
                };
                DA.Fill(DS);
            }
        }
        catch (SqlException ex)
        {
            HataVarmi = true;
            IslemHataMesaj = "Referans çekilemedi ! " + ex.Message.ToString();
        }
        return DS;
    }
    public void Istatistik()
    {

    }
    public void YorumEkle(int PostId,string isim,string mesaj,string eposta, int ParentId,string Ipadres)
    {
        try
        {
            baglan.ConnectionString = st;
            if (baglan.State == ConnectionState.Closed) { baglan.Open(); }
            using (baglan)
            {
                SqlCommand Sorgu = new SqlCommand()
                {
                    Connection = baglan,
                    CommandType = CommandType.Text,
                    CommandText = "INSERT INTO Comment (FullName,EmailAddress,Content,PostId,ParentID,Ipadres) Values(@isim,@eposta,@mesaj,@PostId,@ParentId,@Ipadres) "
                };
                Sorgu.Parameters.AddWithValue("@isim", isim);
                Sorgu.Parameters.AddWithValue("@eposta", eposta);
                Sorgu.Parameters.AddWithValue("@mesaj", mesaj);
                Sorgu.Parameters.AddWithValue("@PostId", PostId);
                Sorgu.Parameters.AddWithValue("@ParentId", ParentId);
                Sorgu.Parameters.AddWithValue("@Ipadres", Ipadres);
                Sorgu.ExecuteNonQuery();
            };
        }
        catch (SqlException ex)
        {
            HataVarmi = true;
            IslemHataMesaj = "Yorum Eklenemedi " + ex.Message.ToString();
        }
    }
    public void MesajEkle(string isim, string mesaj, string eposta, string IpAdres)
    {
        try
        {
            baglan.ConnectionString = st;
            if (baglan.State == ConnectionState.Closed) { baglan.Open(); }
            using (baglan)
            {
                SqlCommand Sorgu = new SqlCommand()
                {
                    Connection = baglan,
                    CommandType = CommandType.Text,
                    CommandText = "INSERT INTO Mesajlar (TamAd,Eposta,Mesaj,IPAdres) Values(@isim,@eposta,@mesaj,@Ipadres) "
                };
                Sorgu.Parameters.AddWithValue("@isim", isim);
                Sorgu.Parameters.AddWithValue("@eposta", eposta);
                Sorgu.Parameters.AddWithValue("@mesaj", mesaj);
                Sorgu.Parameters.AddWithValue("@Ipadres", IpAdres);
                
                Sorgu.ExecuteNonQuery();
            };
        }
        catch (SqlException ex)
        {
            HataVarmi = true;
            IslemHataMesaj = "Mesaj Gönderilemedi " + ex.Message.ToString();
        }
    }
    public DataSet MakaleOku(int id)
    {
        DS = new DataSet();
        try
        {
            baglan.ConnectionString = st;
            if (baglan.State == ConnectionState.Closed) { baglan.Open(); }
            using (baglan)
            {
                SqlCommand Sorgu = new SqlCommand()
                {
                    Connection = baglan,
                    CommandType= CommandType.StoredProcedure,
                    CommandText = "MakaleOkuGuncelle"
                };
                Sorgu.Parameters.AddWithValue("@id", id);
                SqlDataAdapter DA = new SqlDataAdapter()
                {
                    SelectCommand = Sorgu
                };
                DA.Fill(DS);
            }
        }
        catch (SqlException ex)
        {
            HataVarmi = true;
            IslemHataMesaj = "Makale çekilemedi ! " + ex.Message.ToString();
        }

        return DS;
    }

    public DataSet MakaleOku1(int id)
    {
        DS = new DataSet();
        try
        {
            baglan.ConnectionString = st;
            if (baglan.State == ConnectionState.Closed) { baglan.Open(); }
            using (baglan)
            {
                SqlCommand Sorgu = new SqlCommand()
                {
                    Connection = baglan,
                    CommandText = "SELECT * From Post where Id = @id"
                };
                Sorgu.Parameters.AddWithValue("@id", id);
                SqlDataReader Oku = Sorgu.ExecuteReader();
                Oku.Read();
                Title = Oku["Title"].ToString();
            }
            baglan.Close();
        }
        catch (SqlException ex)
        {
            HataVarmi = true;
            IslemHataMesaj = "Makale çekilemedi ! " + ex.Message.ToString();
        }

        return DS;
    }

    public string KategoriAdi(int KategoriId)
    {
        string Makalem = "";
        try
        {
            baglan.ConnectionString = st;
            if (baglan.State == ConnectionState.Closed) { baglan.Open(); }
            using (baglan)
            {
                SqlCommand Sorgu = new SqlCommand()
                {
                    Connection = baglan,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "MakaleAdiGetir"
                };
                Sorgu.Parameters.AddWithValue("@KategoriId", KategoriId);
                SqlDataReader oku = Sorgu.ExecuteReader();
                oku.Read();
                Makalem = oku["name"].ToString();
                SayfaId = oku["Id"].ToString();
                KategoriIdt = oku["CID"].ToString();
            }
        }
        catch (SqlException ex)
        {

            HataVarmi = true;
            IslemHataMesaj = "Makale çekilemedi ! " + ex.Message.ToString();
        }
        return Makalem;
    }

    public DataSet MakaleOku()
    {
        DS = new DataSet();
        try
        {
            baglan.ConnectionString = st;
            if (baglan.State == ConnectionState.Closed) { baglan.Open(); }
            using (baglan)
            {
                SqlCommand Sorgu = new SqlCommand()
                {
                    Connection = baglan,
                    CommandText = "select Post.Id as Id, Title,Description,ShortContent,FullContent,ViewCount,CategoryId as CategoryId,Category.Name as KategoriAdi, Post.PicturePath as PicturePath , CreateDate  from Post Inner JOIN Category on Category.Id = Post.CategoryId   where Post.IsActive=1  Order by Post.Id DESC"
                };
                
                SqlDataAdapter DA = new SqlDataAdapter()
                {
                    SelectCommand = Sorgu
                };
                DA.Fill(DS);
            }
        }
        catch (SqlException ex)
        {
            HataVarmi = true;
            IslemHataMesaj = "Makale çekilemedi ! " + ex.Message.ToString();
        }

        return DS;
    }

    public DataSet KategoriSayi()
    {
        DS = new DataSet();
        try
        {
            baglan.ConnectionString = st;
            if (baglan.State == ConnectionState.Closed) { baglan.Open(); }
            using (baglan)
            {
                SqlCommand Sorgu = new SqlCommand()
                {
                    Connection = baglan,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "KategoriSayi"
                };

                SqlDataAdapter DA = new SqlDataAdapter()
                {
                    SelectCommand = Sorgu
                };
                DA.Fill(DS);
            }
        }
        catch (SqlException ex)
        {
            HataVarmi = true;
            IslemHataMesaj = "Makale Sayısı çekilemedi ! " + ex.Message.ToString();
        }
        return DS;
    }
    public DataSet KategoriMakaleler(int MakaleId)
    {
        DS = new DataSet();
        try
        {
            baglan.ConnectionString = st;
            if (baglan.State == ConnectionState.Closed) { baglan.Open(); }
            using (baglan)
            {
                SqlCommand Sorgu = new SqlCommand()
                {
                    Connection = baglan,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "KategoriMakaleler"
                };
                Sorgu.Parameters.AddWithValue("@KategoriId", MakaleId);
                SqlDataAdapter DA = new SqlDataAdapter()
                {
                    SelectCommand = Sorgu
                };
                DA.Fill(DS);
            }
        }
        catch (SqlException ex)
        {
            HataVarmi = true;
            IslemHataMesaj = "Makale Sayısı çekilemedi ! " + ex.Message.ToString();
        }
        return DS;
    }

    public DataSet SonGonderilenMakele()
    {
        DS = new DataSet();
        try
        {
            baglan.ConnectionString = st;
            if (baglan.State == ConnectionState.Closed) { baglan.Open(); }
            using (baglan)
            {
                SqlCommand Sorgu = new SqlCommand()
                {
                    Connection = baglan,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "SonGonderilenMakale"
                };

                SqlDataAdapter DA = new SqlDataAdapter()
                {
                    SelectCommand = Sorgu
                };
                DA.Fill(DS);
            }
        }
        catch (SqlException ex)
        {
            HataVarmi = true;
            IslemHataMesaj = "Son Gönderilen Makale çekilemedi ! " + ex.Message.ToString();
        }
        return DS;
    }
    public DataSet SonGonderilenMakele3()
    {
        DS = new DataSet();
        try
        {
            baglan.ConnectionString = st;
            if (baglan.State == ConnectionState.Closed) { baglan.Open(); }
            using (baglan)
            {
                SqlCommand Sorgu = new SqlCommand()
                {
                    Connection = baglan,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "SonGonderilenMakale3"
                };

                SqlDataAdapter DA = new SqlDataAdapter()
                {
                    SelectCommand = Sorgu
                };
                DA.Fill(DS);
            }
        }
        catch (SqlException ex)
        {
            HataVarmi = true;
            IslemHataMesaj = "Son Gönderilen Makale çekilemedi ! " + ex.Message.ToString();
        }
        return DS;
    }

    public DataSet PopulerMakale()
    {
        DS = new DataSet();
        try
        {
            baglan.ConnectionString = st;
            if (baglan.State == ConnectionState.Closed) { baglan.Open(); }
            using (baglan)
            {
                SqlCommand Sorgu = new SqlCommand()
                {
                    Connection = baglan,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "PopulerMakale"
                };

                SqlDataAdapter DA = new SqlDataAdapter()
                {
                    SelectCommand = Sorgu
                };
                DA.Fill(DS);
            }
        }
        catch (SqlException ex)
        {
            HataVarmi = true;
            IslemHataMesaj = "Populer Makale çekilemedi ! " + ex.Message.ToString();
        }
        return DS;
    }

    public DataSet SonYorumlar()
    {
        DS = new DataSet();
        try
        {
            baglan.ConnectionString = st;
            if (baglan.State == ConnectionState.Closed) { baglan.Open(); }
            using (baglan)
            {
                SqlCommand Sorgu = new SqlCommand()
                {
                    Connection = baglan,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "SonYorumlar"
                };

                SqlDataAdapter DA = new SqlDataAdapter()
                {
                    SelectCommand = Sorgu
                };
                DA.Fill(DS);
            }
        }
        catch (SqlException ex)
        {
            HataVarmi = true;
            IslemHataMesaj = "Yorumlar çekilemedi ! " + ex.Message.ToString();
        }
        return DS;
    }
    public DataSet MakaleYorum(int MakaleId)
    {
        DS = new DataSet();
        try
        {
            baglan.ConnectionString = st;
            if (baglan.State == ConnectionState.Closed) { baglan.Open(); }
            using (baglan)
            {
                SqlCommand Sorgu = new SqlCommand()
                {
                    Connection = baglan,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "MakaleYorum"
                };
                Sorgu.Parameters.AddWithValue("MakaleId", MakaleId);
                SqlDataAdapter DA = new SqlDataAdapter()
                {
                    SelectCommand = Sorgu
                };
                DA.Fill(DS);
            }
        }
        catch (SqlException ex)
        {
            HataVarmi = true;
            IslemHataMesaj = "Makale Yorumları çekilemedi ! " + ex.Message.ToString();
        }
        return DS;
    }
}