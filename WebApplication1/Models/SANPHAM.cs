using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using WebApplication1.Models;


namespace WebApplication1.Models
{
    public class SanPham
    {
        public int Masp { get; set; }
        public string Tensp { get; set; }
        public decimal Gia { get; set; }
        public double? TbSoSao { get; set; }
        public string TbSao { get; set; }
        public string Anh { get; set; }
        public string TenNSX { get; set; }
        public List<SanPham> GetDsSanPham(string Timkiem)
        {
            string sql;
            DataTable dt = new DataTable();
            if (Timkiem == null)
            {
                sql = @"AllSanPham";
                dt = Dataprovider.ExecuteQuery(sql);
            }
            else
            {
                sql = @"TimKiemSanPham @TenSanPham";
                dt = Dataprovider.ExecuteQuery(sql, new object[] { Timkiem });
            }


            List<SanPham> DsSanPham = new List<SanPham>();

            SanPham MotSanPham;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                MotSanPham = new SanPham();
                if (dt.Rows[i]["TbSao"].ToString() == null)
                {
                    MotSanPham.TbSao = "0";
                }
                else
                {

                    MotSanPham.TbSao = dt.Rows[i]["TbSao"].ToString();


                }
                MotSanPham.Masp = Convert.ToInt32(dt.Rows[i]["MaSP"].ToString());
                MotSanPham.Tensp = dt.Rows[i]["TenSP"].ToString();
                MotSanPham.Anh = dt.Rows[i]["AnhChinh"].ToString();
                MotSanPham.TenNSX = dt.Rows[i]["TenNSX"].ToString();
                MotSanPham.Gia = Convert.ToDecimal(dt.Rows[i]["DonGia"].ToString());
                DsSanPham.Add(MotSanPham);
            }

            return DsSanPham;
        }

    }
}