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
    class MaterialsDataWork
    {
        static string ConnStr = ConnectionString.ConnStr;
        public static string GetMaterialsList(ProductClass product)
        {
            using (SqlConnection conn = new SqlConnection(ConnStr))
            {
                conn.Open();
                string query = "select [Наименование_материала] " +
                    "from demo.materials, demo.productMaterials, demo.products " +
                    "where demo.materials.[ID] = demo.productMaterials.[Material] and demo.productMaterials.[Product] = @SKU";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("SKU", product.SKU);
                SqlDataReader rd = cmd.ExecuteReader();
                string list = "";
                while (rd.Read())
                {
                    list += " " + rd["Наименование_материала"].ToString() + ",";
                }
                return list;
            }
        }
    }
}
