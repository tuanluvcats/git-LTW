using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Tuan05_TH1.Models
{
    public class DuLieu
    {
        static string strcon = "Data Source=LAPTOP-GKURGSJI; database = QL_NhanSu; User ID=sa; Password=123; TrustServerCertificate=True";

        SqlConnection con = new SqlConnection(strcon);

        public List<Employee> dsNV = new List<Employee>();
        public List<Deparment> dsPB = new List<Deparment>();
        public Deparment PB = new Deparment();

        public DuLieu()
        {
            ThietLap_DSNV();
            ThietLap_DSPB();
        }

        public void ThietLap_DSNV(){
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM tbl_Employee", con);
            DataTable dt = new DataTable();
            da.Fill(dt);

            foreach(DataRow dr in dt.Rows)
            {
                var em = new Employee();
                em.MaNV = int.Parse(dr["Id"].ToString());
                em.Ten = dr["Name"].ToString();
                em.GioiTinh = dr["Gender"].ToString();
                em.Tinh = dr["City"].ToString();
                em.MaPg = (int)dr["Deptld"];

                dsNV.Add(em);
            }
         }

        public void ThietLap_DSPB()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM tbl_Deparment", con);
            DataTable dt = new DataTable();
            da.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                var dpm = new Deparment();
                dpm.MaPB = int.Parse(dr["Deptld"].ToString());
                dpm.Ten = dr["NAME"].ToString();

                dsPB.Add(dpm);
            }
        }

        public void HienThiDuLieu(int id)
        {
            SqlDataAdapter da = new SqlDataAdapter(string.Format("SELECT * FROM tbl_Deparment WHERE Deptld = {0}",id), con);
            DataTable dt = new DataTable();
            da.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                var dpm = new Deparment();
                dpm.MaPB = int.Parse(dr["Deptld"].ToString());
                dpm.Ten = dr["NAME"].ToString();

                PB = dpm;
            }
        }

        public List<Employee> LayDSNVTheoPB(int id)
        {
            List<Employee> ds = new List<Employee>();
            foreach (var nv in dsNV)
            {
                if (nv.MaPg == id)
                    ds.Add(nv);
            }
            return ds;
        }

        public void HienThiNhanVien(int id)
        {
            SqlDataAdapter da = new SqlDataAdapter(string.Format("SELECT * FROM tbl_Employee WHERE Deptld = {0}", id), con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                LayDSNVTheoPB(id);
            }
        }


    }
 }