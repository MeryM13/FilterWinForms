using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace FilterWinForms.UTILS
{
    class ProductDataWork
    {
        static string ConnStr = ConnectionString.ConnStr;

        public static DataSet GetProductByPage(string type, int page)
        {
            using (SqlConnection conn = new SqlConnection(ConnStr))
            {
                conn.Open();
                string query = type=="Нет"? 
                    "select * from demo.products" : 
                    "select * from demo.products where [Тип_продукции] = @Type";
                query += " order by [Артикул] offset @Page rows fetch next 20 rows only";
                SqlDataAdapter ada = new SqlDataAdapter(query, conn);
                if (type != "Нет")
                    ada.SelectCommand.Parameters.AddWithValue("Type", type);
                ada.SelectCommand.Parameters.AddWithValue("Page", (page - 1) * 20);
                DataSet ds = new DataSet();
                ada.Fill(ds);
                return ds;
            }
        }

        public static string[] GetTypes()
        {
            using (SqlConnection conn = new SqlConnection(ConnStr))
            {
                conn.Open();
                string query = "select [Тип_продукции] from demo.products group by [Тип_продукции]";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader rd = cmd.ExecuteReader();
                int i = 1;
                string[] arr = new string[6];
                arr[0] = "Нет";
                while (rd.Read())
                {
                    arr[i] = rd["Тип_продукции"].ToString();
                    i++;
                }
                return arr;
            }
        }

        public static int GetMaxPages(string type)
        {
            using (SqlConnection conn = new SqlConnection(ConnStr))
            {
                conn.Open();
                string query = type == "Нет" ?
                    "select * from demo.products" :
                    "select * from demo.products where [Тип_продукции] = @Type";
                SqlCommand cmd = new SqlCommand(query, conn);
                if (type != "Нет")
                    cmd.Parameters.AddWithValue("Type", type);
                SqlDataReader rd = cmd.ExecuteReader();
                int i = 0;
                while (rd.Read())
                {
                    i++;
                }
                i = i % 20 == 0 ? i / 20 : i / 20 + 1;
                return i;
            }
        }
    }
}
