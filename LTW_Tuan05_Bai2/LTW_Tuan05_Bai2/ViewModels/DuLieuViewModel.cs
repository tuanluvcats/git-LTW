using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LTW_Tuan05_Bai2.Models;


namespace LTW_Tuan05_Bai2.ViewModels
{
    public class DuLieuViewModel
    {
        public Loai ChonLoai { get; set; }
        public IEnumerable<Loai> DSLoai { get; set; }     
        public IEnumerable<SanPham> DSSanPham { get; set; }
    }
}