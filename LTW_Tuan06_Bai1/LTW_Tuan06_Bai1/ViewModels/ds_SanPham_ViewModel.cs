using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LTW_Tuan06_Bai1.Models;

namespace LTW_Tuan06_Bai1.ViewModels
{
    public class ds_SanPham_ViewModel
    {
        public List<SanPham> SanPhams { get; set; }
        public List<Loai> Loais { get; set; }
    }
}