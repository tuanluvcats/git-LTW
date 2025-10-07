using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace LTW_Tuan06_Bai1.Models
{
    public class DuLieu
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["QLSP"].ConnectionString);

        public List<SanPham> dsSP = new List<SanPham>();
        public List<Loai> dsLoai = new List<Loai>();
        public List<SanPham> gioHang = new List<SanPham>();
        public List<KhachHang> dsKhachHang = new List<KhachHang>();

        public DuLieu()
        {
            ThietLap_DSSP();
            ThietLap_DSLoai();
            ThietLap_DSKhachHang();
        }

        public void ThietLap_DSSP()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM SanPham", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);

            foreach (DataRow row in dt.Rows)
            {
                var sp = new SanPham();
                sp.MaSanPham = row["MaSanPham"].ToString();
                sp.TenSP = row["TenSP"].ToString();
                sp.MaL = row["MaL"].ToString();
                sp.MaSX = row["MaSX"].ToString();
                sp.Gia = float.Parse(row["Gia"].ToString());
                sp.GhiChu = row["GhiChu"].ToString();
                sp.Hinh = row["Hinh"].ToString();

                dsSP.Add(sp);
            }
        }
        public void ThietLap_DSLoai()
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * From Loai", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);

            foreach (DataRow row in dt.Rows)
            {
                var l = new Loai();
                l.MaLoai = row["MaLoai"].ToString();
                l.TenLoai = row["TenLoai"].ToString();
               
                dsLoai.Add(l);
            }
        }

        public List<SanPham> LaySPTheoLoai(string maL)
        {
            return dsSP.Where(sp => sp.MaL == maL).ToList();
        }

        public SanPham LaySPTheoMa(string maSP)
        {
            return dsSP.FirstOrDefault(sp => sp.MaSanPham == maSP);
        }

        public void ThietLap_DSKhachHang()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM KhachHang", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);

            foreach (DataRow row in dt.Rows)
            {
                var kh = new KhachHang();
                kh.MaKhachHang = row["MaKhachHang"].ToString();
                kh.TenKhachHang = row["TenKhachHang"].ToString();
                kh.SoDienThoai = row["SoDienThoai"].ToString();
                kh.MatKhau = row["MatKhau"].ToString();

                dsKhachHang.Add(kh);
            }
        }

        public KhachHang KiemTraDangNhap(string tenKH, string matKhau)
        {
            return dsKhachHang.FirstOrDefault(k =>
                k.TenKhachHang == tenKH && k.MatKhau == matKhau);
        }

        public bool ThemKhachHang(KhachHang kh)
        {
            try
            {
                string sql = "INSERT INTO KhachHang (MaKhachHang, TenKhachHang, SoDienThoai, MatKhau) " +
                             "VALUES (@MaKhachHang, @TenKhachHang, @SoDienThoai, @MatKhau)";
                SqlCommand cmd = new SqlCommand(sql, conn);

                string maKH = "KH" + (dsKhachHang.Count + 1).ToString("D3");

                cmd.Parameters.AddWithValue("@MaKhachHang", maKH);
                cmd.Parameters.AddWithValue("@TenKhachHang", kh.TenKhachHang);
                cmd.Parameters.AddWithValue("@SoDienThoai", kh.SoDienThoai);
                cmd.Parameters.AddWithValue("@MatKhau", kh.MatKhau);

                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                conn.Close();

                if (rows > 0)
                {
                    dsKhachHang.Add(kh); 
                    return true;
                }
                return false;
            }
            catch
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
                return false;
            }
        }

    }
}