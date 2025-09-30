using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace LTW_Tuan05_Bai2.Models
{
    public class DuLieu
    {
        static string strcon = "Data Source=LAPTOP-GKURGSJI; database = QL_DTDD1; User ID=sa; Password=123; TrustServerCertificate=True";

        SqlConnection con = new SqlConnection(strcon);

        public List<Loai> dsLoai = new List<Loai>();
        public List<SanPham> dsSP = new List<SanPham>();
        public Loai ChonLoai { get;  set; }

        public DuLieu()
        {
            ThietLap_DsLoai();
            ThietLap_DsSP();
        }

        public void ThietLap_DsLoai()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from Loai", con);
            DataTable dt = new DataTable();
            da.Fill(dt);

            foreach(DataRow r in dt.Rows)
            {
                Loai l = new Loai();
                l.MaLoai = int.Parse(r["MaLoai"].ToString());
                l.TenLoai = r["TenLoai"].ToString();

                dsLoai.Add(l);
            }
        }

        public void ThietLap_DsSP()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from SanPham", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow r in dt.Rows)
            {
                SanPham sp = new SanPham();
                sp.MaSP = int.Parse(r["MaSP"].ToString());
                sp.TenSP = r["TenSP"].ToString();
                sp.DuongDan = r["DuongDan"].ToString();
                sp.Gia = int.Parse(r["Gia"].ToString());
                sp.MoTa = r["MoTa"].ToString();
                sp.MaLoai = int.Parse(r["MaLoai"].ToString());

                dsSP.Add(sp);
            }
        }

        public List<SanPham> LayDSSPTheoLoai(int id)
        {
            List<SanPham> ds = new List<SanPham>();
            foreach (var sp in dsSP)
            {
                if (sp.MaLoai == id)
                    ds.Add(sp);
            }
            return ds;
        }

        public void HienThiDuLieu(int id)
        {
            SqlDataAdapter da = new SqlDataAdapter($"SELECT * FROM Loai WHERE MaLoai = {id}", con);
            DataTable dt = new DataTable();
            da.Fill(dt);

            foreach (DataRow r in dt.Rows)
            {
                Loai l = new Loai();
                l.MaLoai = int.Parse(r["MaLoai"].ToString());
                l.TenLoai = r["TenLoai"].ToString();

                ChonLoai = l;   
            }
        }
    }
}