using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using FilterWinForms.CLASSES;

namespace FilterWinForms.UTILS
{
    class DataWork
    {
        static string ConnStr = ConnectionString.ConnStr;

        public static DataSet GetProductByPage(string type, int page, string order, bool up, string defStr, string search)
        {
            using (SqlConnection conn = new SqlConnection(ConnStr))
            {
                conn.Open();
                string query = type==defStr? 
                    "select * from demo.products" :
                    "select * from demo.products where [Тип_продукции] = @Type";
                if (!String.IsNullOrEmpty(search))
                {
                    query += type == defStr ? " where" : " and";
                    query += " [Наименование_продукции] like '" + search + "%'";
                }
                query += order == "Отсутствует" ? " order by 'Артикул'" : " order by '"+order+"'";
                if (!up)
                    query += " desc";
                query += " offset @Page rows fetch next 20 rows only";
                SqlDataAdapter ada = new SqlDataAdapter(query, conn);
                if (type != defStr)
                    ada.SelectCommand.Parameters.AddWithValue("Type", type);
                ada.SelectCommand.Parameters.AddWithValue("Page", (page - 1) * 20);
                DataSet ds = new DataSet();
                ada.Fill(ds);
                return ds;
            }
        }

        public static List<ProductClass> GetProductListByPage(string type, int page, string order, bool up, string defStr, string search)
        {
            using (SqlConnection conn = new SqlConnection(ConnStr))
            {
                conn.Open();
                string query = type == defStr ?
                    "select * from demo.products" :
                    "select * from demo.products where [Тип_продукции] = @Type";
                if (!String.IsNullOrEmpty(search))
                {
                    query += type == defStr ? " where" : " and";
                    query += " [Наименование_продукции] like '" + search + "%'";
                }
                query += order == "Отсутствует" ? " order by 'Артикул'" : " order by '" + order + "'";
                if (!up)
                    query += " desc";
                query += " offset @Page rows fetch next 20 rows only";
                List<ProductClass> productArray = new List<ProductClass>();
                SqlCommand cmd = new SqlCommand(query, conn);
                if (type != defStr)
                    cmd.Parameters.AddWithValue("Type", type);
                cmd.Parameters.AddWithValue("Page", (page - 1) * 20);
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    ProductClass product = new ProductClass();
                    product.Name = rd["Наименование_продукции"].ToString();
                    product.PicturePath = rd["Изображение"].ToString();
                    product.MinPrice = decimal.Parse(rd["Минимальная_стоимость_для_агента"].ToString());
                    product.SKU = rd["Артикул"].ToString();
                    product.Price = decimal.Parse(rd["Минимальная_стоимость_для_агента"].ToString());
                    product.Type = rd["Тип_продукции"].ToString();
                    product.Workshop = Int32.Parse(rd["Номер_цеха_для_производства"].ToString());
                    product.Description = rd["Описание"].ToString();
                    product.Workers = Int32.Parse(rd["Количество_человек_для_производства"].ToString());
                    productArray.Add(product);
                }
                return productArray;
            }
        }

        public static List<string> GetTypes(string defStr)
        {
            using (SqlConnection conn = new SqlConnection(ConnStr))
            {
                conn.Open();
                string query = "select [Тип_продукции] from demo.products group by [Тип_продукции]";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader rd = cmd.ExecuteReader();
                int i = 1;
                List<string> arr = new List<string>();
                arr.Add(defStr);
                while (rd.Read())
                {
                    arr.Add(rd["Тип_продукции"].ToString());
                }
                return arr;
            }
        }

        public static List<string> GetColumnsForSort(string defStr)
        {
            using (SqlConnection conn = new SqlConnection(ConnStr))
            {
                conn.Open();
                string query = "  select * from information_schema.columns where table_name like 'products'";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader rd = cmd.ExecuteReader();
                int i = 1;
                List<string> arr = new List<string>();
                arr.Add(defStr);
                while (rd.Read())
                {
                   arr.Add(rd["COLUMN_NAME"].ToString());
                }
                return arr;
            }
        }

        public static int GetMaxPages(string type, string defStr, string search)
        {
            using (SqlConnection conn = new SqlConnection(ConnStr))
            {
                conn.Open();
                string query = type == defStr ?
                    "select * from demo.products" :
                    "select * from demo.products where [Тип_продукции] = @Type";
                if (!String.IsNullOrEmpty(search))
                {
                    query += type == defStr ? " where" : " and";
                    query += " [Наименование_продукции] like '" + search + "%'";
                }
                SqlCommand cmd = new SqlCommand(query, conn);
                if (type != defStr)
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

        public static List<MaterialClass> GetMaterialsList(ProductClass product)
        {
            using (SqlConnection conn = new SqlConnection(ConnStr))
            {
                conn.Open();
                string query = "select demo.materials.* " +
                    "from demo.materials, demo.productMaterials " +
                    "where demo.materials.[ID] = demo.productMaterials.[Material] " +
                    "and demo.productMaterials.[Product] = @SKU";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("SKU", product.SKU);
                SqlDataReader rd = cmd.ExecuteReader();
                List<MaterialClass> list = new List<MaterialClass>();
                while (rd.Read())
                {
                    MaterialClass material = new MaterialClass();
                    material.ID = Int32.Parse(rd["ID"].ToString());
                    material.Name = rd["Наименование_материала"].ToString();
                    material.Price = decimal.Parse(rd["Стоимость"].ToString());
                    material.InPack = Int32.Parse(rd["Количество_в_упаковке"].ToString());
                    material.MinQuantity = Int32.Parse(rd["Минимальный_возможный_остаток"].ToString());
                    material.Quantity = Int32.Parse(rd["Количество_на_складе"].ToString());
                    material.Type = rd["Тип_материала"].ToString();
                    material.Measure = rd["Единица_измерения"].ToString();
                    list.Add(material);
                }
                return list;
            }
        }
    }
}
