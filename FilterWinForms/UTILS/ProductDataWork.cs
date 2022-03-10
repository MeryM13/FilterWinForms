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

        public static DataSet GetAll()
        {
            using (SqlConnection conn = new SqlConnection(ConnStr))
            {
                conn.Open();
                string query = "select * from demo.products";
                SqlDataAdapter ada = new SqlDataAdapter(query, conn);
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

        public static DataSet GetByType(string Type)
        {
            using (SqlConnection conn = new SqlConnection(ConnStr))
            {
                conn.Open();
                string query = "select * from demo.products where [Тип_продукции] = @Type";
                SqlDataAdapter ada = new SqlDataAdapter(query, conn);
                ada.SelectCommand.Parameters.AddWithValue("Type", Type);
                DataSet ds = new DataSet();
                ada.Fill(ds);
                return ds;
            }
        }
    }
}
