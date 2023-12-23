using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Referanslar için özet açıklama
/// </summary>
public class Referanslar
{
    public int id { get; set; }
    public string Baslik { get; set; }
    public string Aciklama { get; set; }
    public int ProjeAktifmi { get; set; }
    public string CalismaSuresi { get; set; }
    public string Platform { get; set; }
    public string Kurum { get; set; }
    public string LinkUrl { get; set; }
    public Referanslar()
    {
        //
        //TODO: Buraya oluşturucu mantığı ekleyin
        //
    }
}