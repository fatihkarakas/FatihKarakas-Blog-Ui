﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Dovizler için özet açıklama
/// </summary>
public class Dovizler
{
    public string code { get; set; }
    public string name { get; set; }
    public string full_name { get; set; }
    public decimal selling { get; set; }
    public decimal buying { get; set; }
    public decimal currency { get; set; }
    public decimal change_rate { get; set; }
    public int update_date { get; set; }

}