using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for YardimciSiniflar
/// </summary>
public class YardimciSiniflar
{
    public YardimciSiniflar()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    
    public  string KodOlustur(string Text)
    {
        try

        {
            string strReturn = Text.Trim();
            strReturn = strReturn.Replace("ğ", "g");
            strReturn = strReturn.Replace("Ğ", "G");
            strReturn = strReturn.Replace("ü", "u");
            strReturn = strReturn.Replace("Ü", "U");
            strReturn = strReturn.Replace("ş", "s");
            strReturn = strReturn.Replace("Ş", "S");
            strReturn = strReturn.Replace("ı", "i");
            strReturn = strReturn.Replace("İ", "I");
            strReturn = strReturn.Replace("ö", "o");
            strReturn = strReturn.Replace("Ö", "O");
            strReturn = strReturn.Replace("ç", "c");
            strReturn = strReturn.Replace("Ç", "C");
            strReturn = strReturn.Replace("-", "+");
            strReturn = strReturn.Replace(" ", "+");
            strReturn = strReturn.Trim();
            strReturn = new System.Text.RegularExpressions.Regex("[^a-zA-Z0-9+]").Replace(strReturn, "");
            strReturn = strReturn.Trim();
            strReturn = strReturn.Replace("+", "-");
            return strReturn;
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }
   public bool ResimVarmi(string veri)
    {
        if(veri == null || veri == "")
        {
            return false;
        }
        else { return true;}
        
    }

    public string ToRelativeFormat(DateTime source)
    {
        string result = string.Empty;

        var ts = new TimeSpan(DateTime.Now.Ticks - source.Ticks);
        double delta = ts.TotalSeconds;

        if (delta > 0)
        {
            if (delta < 60) // 60 (seconds)
            {
                result = ts.Seconds == 1 ? "bir saniye önce" : ts.Seconds + " saniye önce";
            }
            else if (delta < 120) //2 (minutes) * 60 (seconds)
            {
                result = "1 dakika önce";
            }
            else if (delta < 2700) // 45 (minutes) * 60 (seconds)
            {
                result = ts.Minutes + " dakika önce";
            }
            else if (delta < 5400) // 90 (minutes) * 60 (seconds)
            {
                result = "bir saat önce";
            }
            else if (delta < 86400) // 24 (hours) * 60 (minutes) * 60 (seconds)
            {
                int hours = ts.Hours;
                if (hours == 1)
                    hours = 2;
                result = hours + " saat önce";
            }
            else if (delta < 172800) // 48 (hours) * 60 (minutes) * 60 (seconds)
            {
                result = "dün";
            }
            else if (delta < 2592000) // 30 (days) * 24 (hours) * 60 (minutes) * 60 (seconds)
            {
                result = ts.Days + " gün önce";
            }
            else if (delta < 31104000) // 12 (months) * 30 (days) * 24 (hours) * 60 (minutes) * 60 (seconds)
            {
                int months = Convert.ToInt32(Math.Floor((double)ts.Days / 30));
                result = months <= 1 ? "bir ay önce" : months + " ay önce";
            }
            else
            {
                int years = Convert.ToInt32(Math.Floor((double)ts.Days / 365));
                if (years <= 1)
                    result = "bir yıl önce";
                else
                    result = source.ToString();

                //result = years <= 1 ? "bir yıl önce" : years + " yıl önce";
            }
        }
        return result;
    }

    
    public string RastgeleVeriUret()
    {
        string deger = "";
        //Türkçe karakterleri kullanmaktan vazgeçtim.
        string dizi = "ABCDEFGHIJKLMNOPRSTUVYZ0123456789";
        Random r = new Random();
        //Toplam 6 karakterden oluşan rastgele bir metin oluşturalım.
        for (int i = 0; i <= 6; i++)
        {
            deger = deger + dizi[r.Next(0, 33)];
        }
        return deger;
    }

}