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

        public static DataSet GetProductByPage(string type, int page, string order, bool up, string defStr)
        {
            using (SqlConnection conn = new SqlConnection(ConnStr))
            {
                conn.Open();
                string query = type=="Нет"? 
                    "select * from demo.products" : 
                    "select * from demo.products where [Тип_продукции] = @Type";
                query += " ORDER BY " +
                    "CASE WHEN @SortDirection = 'A' THEN " +
                    "CASE WHEN @SortBy = 'Артикул' THEN Артикул " +
                    "WHEN @SortBy = 'Наименование_продукции' THEN [Наименование_продукции] " +
                    "WHEN @SortBy = 'Номер_цеха_для_производства' THEN [Номер_цеха_для_производства] " +
                    "WHEN @SortBy = 'Минимальная_стоимость_для_агента' THEN [Минимальная_стоимость_для_агента] " +
                    "END " +
                    "END ASC, " +
                    "CASE WHEN @SortDirection = 'D' THEN " +
                    "CASE WHEN @SortBy = 'Артикул' THEN Артикул " +
                    "WHEN @SortBy = 'Наименование_продукции' THEN [Наименование_продукции] " +
                    "WHEN @SortBy = 'Номер_цеха_для_производства' THEN [Номер_цеха_для_производства] " +
                    "WHEN @SortBy = 'Минимальная_стоимость_для_агента' THEN [Минимальная_стоимость_для_агента] " +
                    "END " +
                    "END DESC";
                query += " offset @Page rows fetch next 20 rows only";
                SqlDataAdapter ada = new SqlDataAdapter(query, conn);
                if (type != defStr)
                    ada.SelectCommand.Parameters.AddWithValue("Type", type);
                if (up)
                    ada.SelectCommand.Parameters.AddWithValue("SortDirection", "A");
                else
                    ada.SelectCommand.Parameters.AddWithValue("SortDirection", "D");
                if (order == defStr)
                    ada.SelectCommand.Parameters.AddWithValue("SortBy", "Артикул");
                else
                    ada.SelectCommand.Parameters.AddWithValue("SortBy", order);
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

        public static string[] GetColumnsForSort()
        {
            using (SqlConnection conn = new SqlConnection(ConnStr))
            {
                conn.Open();
                string query = "  select * from information_schema.columns where table_name like 'products'";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader rd = cmd.ExecuteReader();
                int i = 1;
                string[] arr = new string[8];
                arr[0] = "Нет";
                while (rd.Read())
                {
                    arr[i] = rd["COLUMN_NAME"].ToString();
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
