using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace WebApplication1.Models
{
    public static class Dataprovider
    {
        
        static string cnstr = @"Data Source=RYK3R\RYK3R;Initial Catalog=QLShopGiay;Integrated Security=True";
        // mạnh  Data Source=LAPTOP-IMOK4Q50\SQLEXPRESS;Initial Catalog=QLTHUVIEN;Integrated Security=True
        static SqlConnection cn;
        public static DataTable ExecuteQuery(string query, object[] parameter = null) // phương thức này trả về 1 bảng
        {
            DataTable dt = new DataTable();
            cn = new SqlConnection(cnstr);
            if (cn.State == ConnectionState.Closed)
            {
                cn.Open();
            }
            SqlCommand cmd = new SqlCommand(query, cn);
            if (parameter != null)
            {
                string[] listPara = query.Split(' ');
                int i = 0;
                foreach (string item in listPara)
                {
                    if (item.Contains('@'))
                    {
                        cmd.Parameters.AddWithValue(item, parameter[i]);
                        i++;
                    }
                }
            }
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            cn.Close();
            return dt;
        }
        public static int ExecuteNonQuery(string query, object[] parameter = null) //dùng trong các câu lệnh không trả về kq, chỉ dùng cho câu lệnh thực thi: thêm sửa xóa
                                                                             // kết quả trả về là số hàng bị thay đổi
        {
            int kq = 0;
            cn = new SqlConnection(cnstr);
            if (cn.State == ConnectionState.Closed)
            {
                cn.Open();
            }

            SqlCommand command = new SqlCommand(query, cn);

            if (parameter != null)
            {
                string[] listPara = query.Split(' ');
                int i = 0;
                foreach (string item in listPara)
                {
                    if (item.Contains('@'))
                    {
                        command.Parameters.AddWithValue(item, parameter[i]);
                        i++;
                    }
                }
            }
            kq = command.ExecuteNonQuery();
            cn.Close();
            return kq;
        }
        public static object ExecuteScalar(string query, object[] parameter = null)// nó trả về 1 giá trị cụ thể
        {
            object kq = 0;
            cn = new SqlConnection(cnstr);
            if (cn.State == ConnectionState.Closed)
            {
                cn.Open();
            }
            SqlCommand command = new SqlCommand(query, cn);

            if (parameter != null)
            {
                string[] listPara = query.Split(' ');
                int i = 0;
                foreach (string item in listPara)
                {
                    if (item.Contains('@'))
                    {
                        command.Parameters.AddWithValue(item, parameter[i]);
                        i++;
                    }
                }
            }
            kq = command.ExecuteScalar();
            cn.Close();
            return kq;
        }

        /* cách dung các phương thức này : dùng được với cả câu lệnh select bình thường , lẫn các thủ tục
         * TH1 : thủ tục ko có tham số  
                string sql = @"tên thủ tục hoặc có thể để câu lệnh select vào nó vẫn chạy bình thường";
                    Dataprovider.ExecuteQuery(sql) 

        TH2 : thủ tục có tham số
         string sql = @"tên thủ tục + tham số";
        lưu ý là tên thủ tục cách 1 khoảng trắng với tham số đầu tiên , giữa thủ tục với dấu,  cách 1 khoảng trắng
        vd chuẩn string sql = @"insertSinhVien_thamso1_,_thamso2_,_thamso3_,_thamsocuoi";
        dấu"_" có nghĩa đó là khoảng trắng, ở định nghĩa proc thì ta khai báo kiểu dữ liệu cho tham số, còn khi đưa vào chuỗi string chỉ 
        đưa tên ra thôi chứ ko đưa kiểu ra nữa
        Dataprovider.ExecuteQuery(sql, new object [] {"",...}) danh sách các tham số tương ứng với trên chuỗi sql
         */
    }
}
